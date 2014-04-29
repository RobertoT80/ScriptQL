using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace ScriptQL
{
    class SqlTimeoutException : Exception
    {
        public SqlTimeoutException() : base("Query timeout.")
        {
        }
        public SqlTimeoutException(string message) : base(message)
        {
        }

        public SqlTimeoutException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    [Serializable] 
    public class SqlInstance
    {
        private readonly string _instance,
            _user,
            _password;

        public bool isBusy,
            isConnecting;
        public bool? isOnline = null;

        public static List<SqlInstance> listServers = new List<SqlInstance>();
        public List<SqlDatabase> databasesCollection = new List<SqlDatabase>();

        [Category("System Paths"), ReadOnly(true)]
        public string pathData { get; private set; }

        [Category("System Paths"), ReadOnly(true)]
        public string pathLog { get; private set; }

        [Category("System Paths"), ReadOnly(true)]
        public string pathBackup { get; private set; }

        private readonly bool _winAuth;

        [Category("Properties")]
        [ReadOnly(true)]
        public bool winAuth
        {
            get { return _winAuth; }
        }

        [Category("Properties"), ReadOnly(true)]
        public string hostname { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string machinename { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string collation { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string service { get; set; }

        [Category("Properties"), ReadOnly(true)]
        public string instancename { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string productversion { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string edition { get; private set; }

        [Category("Features"), ReadOnly(true)]
        public int isclustered { get; private set; }

        [Category("Features"), ReadOnly(true)]
        public int isfulltextinstalled { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public int isintegratedsecurityonly { get; private set; }

        [Category("Size (GB)"), ReadOnly(true)]
        public decimal totalDataSize { get; set; }

        [Category("Size (GB)"), ReadOnly(true)]
        public decimal totalLogSize { get; set; }

        public static string[] systemNames ={"msdb", "master", "model", "tempdb", "distribution", "resource"};


        public SqlInstance(string instance, string user, string password, bool winAuth, bool doNotConnect = false)
        {
            _instance = instance;
            _user = user;
            _password = password;
            _winAuth = winAuth;

            if (doNotConnect) return;
            getPaths();
            getProperties();
        }

        public override string ToString()
        {
            return _instance;
        }
        public override bool Equals(object obj)
        {
            var server = obj as SqlInstance;
            if (server == null) return false;
            // return machinename + instancename== server.machinename + server.instancename;
            return ToString() == server.ToString();
        }

        public override int GetHashCode()
        {
            return string.Concat(machinename, instancename).GetHashCode();
        }

        public void getProperties()
        {
            const string qry = @"SELECT @@servername as hostname, SERVERPROPERTY('MachineName') as machinename, @@SERVICENAME as servicename,
                SERVERPROPERTY('InstanceName') as instancename, SERVERPROPERTY('Collation') as collation, 
                SERVERPROPERTY('ProductVersion') as productversion, SERVERPROPERTY('Edition') as edition, 
                SERVERPROPERTY('IsClustered') as isclustered, SERVERPROPERTY('IsFullTextInstalled') as isfulltextinstalled, SERVERPROPERTY('IsIntegratedSecurityOnly') as isintegratedsecurityonly";

            var conn = GetConnection();
            var cmd = new SqlCommand(qry, conn);
            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                rdr.Read();
                hostname = rdr.GetString(0); //hostname
                machinename = rdr.GetString(1); //machinename
                service = rdr.GetString(2);  //servicename            
                instancename = !rdr.IsDBNull(3) ? rdr.GetString(3) : "Default";
                collation = rdr.GetString(4);  //collation
                productversion = rdr.GetString(5); //productversion
                edition = rdr.GetString(6);//edition
                isclustered = rdr.GetInt32(7);//isclustered
                isfulltextinstalled = rdr.GetInt32(8);//isfulltextinstalled
                isintegratedsecurityonly = rdr.GetInt32(9);//isintegratedsecurityonly
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void getPaths()
        {
            var qry = @"declare @DefaultData nvarchar(512) " + Environment.NewLine +
            @"exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultData', @DefaultData output" + Environment.NewLine +

            @"declare @DefaultLog nvarchar(512)" + Environment.NewLine +
            @"exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultLog', @DefaultLog output" + Environment.NewLine +

            @"declare @DefaultBackup nvarchar(512)" + Environment.NewLine +
            @"EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer',N'BackupDirectory' , @DefaultBackup output" + Environment.NewLine +

            @"select" + Environment.NewLine +
                @"@DefaultData as 'Data'," + Environment.NewLine +
                @"@DefaultLog as 'Log'," + Environment.NewLine +
                @"@DefaultBackup as 'Backup'";

            var conn = GetConnection();
            var cmd = new SqlCommand(qry, conn);
            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                rdr.Read();
                pathData = rdr.GetString(0);
                pathLog = rdr.GetString(1);
                pathBackup = rdr.GetString(2);
            }
            catch (Exception ex)
            {
                Utils.WriteLog("GetPaths Exception : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> getPhysicalFiles()
        {
            const string qry = @"select m.physical_name
                        from sys.master_files m 
                        inner join sys.databases d 
                        on (m.database_id = d.database_id) 
                        order by 1";

            var files = new List<string>();

            var conn = GetConnection();
            var cmd = new SqlCommand(qry, conn);
            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        files.Add(rdr.GetString(0));
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return files;
        }


        public SqlConnection GetConnection(string database = "master")
        {
            var sb = new StringBuilder();
            sb.Append("server=@server;database=@database;Integrated Security=@winauth;User ID=@user;Password=@password;timeout=10");
            sb.Replace("@server", _instance);
            sb.Replace("@database", database);
            sb.Replace("@winauth", winAuth.ToString());
            sb.Replace("@user", _user);
            sb.Replace("@password", _password);

            var conn = new SqlConnection(sb.ToString());
            return conn;
        }

        public async Task<bool> TestConnection(CancellationToken token)
        {
            isConnecting = true;
            var conn = GetConnection();
            var connection = Task.Run(() => conn.OpenAsync(token));
            try
            {
                await connection;
                if (token.IsCancellationRequested)
                {
                    isOnline = null;
                    token.ThrowIfCancellationRequested();
                }
                isOnline = true;
                return true;
            }
            catch (OperationCanceledException)
            {
                isOnline = null;
                return false;
            }
            catch (Exception)
            {
                isOnline = false;
                return false;
            }
            finally
            {
                conn.Close();
                isConnecting = false;
            }
        }

        public bool TestConnectionSync()
        {
            var conn = GetConnection();
            try
            {
                conn.Open();
                isOnline = true;
                return true;
            }
            catch (SqlException ex)
            {
                Utils.WriteLog("Connection to " + _instance + "failed: \n" + ex.Message);
                MessageBox.Show(ex.Message);
                isOnline = false;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public void getDbList(bool systemdbEnabled)
        {
            //var connectionWorking = TestConnectionSync();
            //if (!connectionWorking)
            if (isOnline != true)
            {
                MessageBox.Show("Can't connect now to " + _instance + ", please try again.");
                return;
            }
            databasesCollection.Clear();
            const string qry = @"SELECT name, state_desc, user_access, 
                            CASE owner_sid
	                            WHEN 0x01 then 'true'
	                            ELSE 'false'
                            END
                            FROM sys.databases ORDER BY owner_sid, name";

            var conn = GetConnection();
            var cmd = new SqlCommand(qry, conn);

            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    var name = rdr.GetString(0);
                    var status = rdr.GetString(1);
                    var user_access = (sbyte) rdr.GetByte(2);
                    var sysdb = bool.Parse(rdr.GetString(3));
                    if (!systemdbEnabled)
                    {
                        if (systemNames.Any(name.Contains) || name.StartsWith("ReportServer"))
                        {
                            continue;
                        }
                        var oDatabase = new SqlDatabase(this, name, status, user_access, sysdb);
                        databasesCollection.Add(oDatabase);
                        //oDatabase.getDatabaseProperties(); // to get size
                    }
                    else
                    {
                        if (name != "tempdb")
                        {
                            var oDatabase = new SqlDatabase(this, name, status, user_access, sysdb);
                            databasesCollection.Add(oDatabase);
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                Utils.WriteLog(ex.Message);
            }
            catch (Exception ex)
            {
                Utils.WriteLog(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private bool DbnameCheck(string dbname)
        {
            if (!Utils.IsStringValid(dbname))
            {
                MessageBox.Show(dbname + " is not a valid name.");
                return false;
            }
            if (databasesCollection.FirstOrDefault(s => s.name == dbname) != null)
            {
                MessageBox.Show(dbname + " exists yet.");
                return false;
            }
            return true;
        }

        public async Task<bool> Drop(string name, CancellationToken token)
        {
            var sb = new StringBuilder("DROP DATABASE [@dbname] ").Replace("@dbname", name);
            return await ExecuteNonQueryAsync(sb.ToString(), token);

        }

        public async Task<bool> Drop(string name)
        {
            var sb = new StringBuilder("DROP DATABASE [@dbname] ").Replace("@dbname", name);
            return await ExecuteNonQueryAsync(sb.ToString());
        }

        public async void Drop(List<string> names)
        {
            foreach (string s in names)
            {
                await ExecuteNonQueryAsync("DROP DATABASE " + s);
            }
        }

        public bool createDatabaseSync(string dbname)
        {
            // create for attach (ldf is optional).
            // Invoked by the create form and the main function that restores a database collection.
            if (!DbnameCheck(dbname)) return false;

            var sbCreate = new StringBuilder();
            sbCreate.Append("CREATE DATABASE [@dbname] ");
            sbCreate.Replace("@dbname", dbname);
            var conn = GetConnection();
            var cmd = new SqlCommand(sbCreate.ToString(), conn);
            try
            {
                conn.Open();
                int databaseCreated = cmd.ExecuteNonQuery();
                if (databaseCreated == -1)
                {
                    var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0, false);
                    databasesCollection.Add(oDatabase);
                    return true;
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<bool> createDatabase(string dbname)
        {
            // create for attach (ldf is optional).
            // Invoked by the create form and the main function that restores a database collection.
            if (!DbnameCheck(dbname)) return false;

            var sbCreate = new StringBuilder();
            sbCreate.Append("CREATE DATABASE [@dbname] ");
            sbCreate.Replace("@dbname", dbname);

            var createDatabase = Task.Run(() => ExecuteNonQueryAsync(sbCreate.ToString()));
            await createDatabase;
            if (createDatabase.Result)
            {
                var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0, false);
                databasesCollection.Add(oDatabase);
            }
            return createDatabase.Result;
        }


        public async Task<bool> createDatabase(string dbname, FileInfo mdf, FileInfo ldf = null)
        {
            // create for attach (ldf is optional).
            // Invoked by the create form and the main function that restores a database collection.
            if (!DbnameCheck(dbname)) return false;

            var sbCreate = new StringBuilder();
            sbCreate.Append("CREATE DATABASE [@dbname] ");
            sbCreate.Replace("@dbname", dbname);

            if (mdf != null) // it's for attach
            {
                sbCreate.Append("ON (FILENAME='@mdf')");
                sbCreate.Replace("@mdf", mdf.FullName);
                if (ldf != null)
                {
                    sbCreate.Append(",(FILENAME='@ldf')");
                    sbCreate.Replace("@ldf", ldf.FullName);
                }
                sbCreate.Append(" FOR ATTACH ");
            }

            var createDatabase = Task.Run(() => ExecuteNonQueryAsync(sbCreate.ToString(), 15));
            await createDatabase;
            if (createDatabase.Result)
            {
                var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0, false);
                databasesCollection.Add(oDatabase);
            }
            return createDatabase.Result;
        }

        public async Task<bool> createDatabase(string dbname, string mdf, string[] ndfArray = null, string[] ldfArray = null)
        {   // Create with attach multiple secondary ldf and ndf files 
            if (!DbnameCheck(dbname)) return false;

            var sbCreate = new StringBuilder();
            sbCreate.Append("CREATE DATABASE [@dbname] ");
            sbCreate.Replace("@dbname", dbname);

            sbCreate.Append("ON ");
            sbCreate.Append("(FILENAME='@mdf'),");
            sbCreate.Replace("@mdf", mdf);


            if (ndfArray == null && ldfArray == null)
            {   // Remove comma at end
                var s = sbCreate.ToString();
                sbCreate.Clear();
                sbCreate.Append(s.Substring(0, s.Length - 1));
            }
            else
            {
                if (ndfArray != null)
                    foreach (var ndf in ndfArray)
                    {
                        sbCreate.Append("(FILENAME='@ndf'),");
                        sbCreate.Replace("@ndf", ndf);
                    }

                if (ldfArray != null)
                {
                    foreach (var ldf in ldfArray)
                    {
                        sbCreate.Append("(FILENAME='@ldf'),");
                        sbCreate.Replace("@ldf", ldf);
                    }
                }
                var s = sbCreate.ToString();
                sbCreate.Clear();
                sbCreate.Append(s.Substring(0, s.Length - 1));
            }
            sbCreate.Append(" FOR ATTACH ");

            var createDatabase = Task.Run(() => ExecuteNonQueryAsync(sbCreate.ToString(), 15));
            await createDatabase;
            var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0, false);
            databasesCollection.Add(oDatabase);
            return createDatabase.Result;
        }

        public async Task<bool> ExecuteNonQueryAsync(string query, sbyte commandTimeout = 0)
        {
            Debug.Assert(!string.IsNullOrEmpty(query));
            Debug.Assert(commandTimeout >= 0);
            var conn = GetConnection();
            var cmd = new SqlCommand(query, conn) { CommandTimeout = commandTimeout };
            Utils.WriteLog("ExecuteNonQueryAsync(" + query + ", " + commandTimeout + ")");
            var result = Task.Run(() => cmd.ExecuteNonQueryAsync());

            try
            {
                conn.Open();
                Debug.Assert(conn.State == ConnectionState.Open);
                await result;
                //conn.Close();
                return (result.Result == -1);
            }
            catch (SqlException ex)
            {
                Utils.WriteLog("ExecuteNonQueryAsync sql exception: " + cmd.CommandText + "\n" + ex.Message + "\n" + ex.InnerException);
                if (ex.Message.Contains("Operation cancelled by user"))
                {
                    throw new OperationCanceledException();
                }
                else if (ex.Number == -2) // Timeout or "general network error"
                {
                    throw new SqlTimeoutException();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Utils.WriteLog("ExecuteNonQueryAsync exception: " + cmd.CommandText + "\n" + ex.Message + "\n" + ex.InnerException);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public async Task<bool> ExecuteNonQueryAsync(string query, CancellationToken token, sbyte commandTimeout = 0)
        {
            Debug.Assert(!string.IsNullOrEmpty(query));
            Debug.Assert(token != null);
            Debug.Assert(commandTimeout >= 0);

            var conn = GetConnection();
            var cmd = new SqlCommand(query, conn) { CommandTimeout = commandTimeout };

            Utils.WriteLog("ExecuteNonQueryAsync: " + cmd.CommandText);

            try
            {
                conn.Open();
                Debug.Assert(conn.State == ConnectionState.Open);
                var result = Task.Run(() => cmd.ExecuteNonQueryAsync(token));
                await result;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                return (result.Result == -1);
            }
            catch (OperationCanceledException)
            {
                Utils.WriteLog("ExecuteNonQueryAsync canceled: " + cmd.CommandText);
                throw;
            }
            catch (SqlException ex)
            {
                Utils.WriteLog("ExecuteNonQueryAsync sql exception: " + cmd.CommandText + "\n" + ex.Message + "\n" + ex.InnerException);
                if (ex.Message.Contains("Operation cancelled by user"))
                {
                    throw new OperationCanceledException();
                }
                else if (ex.Number == -2) // Timeout or "general network error"
                {
                    throw new SqlTimeoutException();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Utils.WriteLog("ExecuteNonQueryAsync exception: " + cmd.CommandText + "\n" + ex.Message + "\n" + ex.InnerException);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public async Task<bool> ExecuteNonQueryAsyncNEW(string query, CancellationToken token, sbyte commandTimeout = 0)
        {
            var conn = GetConnection();
            var cmd = new SqlCommand(query, conn) { CommandTimeout = commandTimeout };

            var executeQuery = Task.Run(() => cmd.ExecuteNonQueryAsync(token));
            Utils.WriteLog(_instance + "[" + executeQuery.Id + "][S] " + cmd.CommandText);
            try
            {
                conn.Open();
                Debug.Assert(conn.State == ConnectionState.Open);
                await executeQuery;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                Utils.WriteLog(_instance + "[" + executeQuery.Id + "][R]" + executeQuery.Result);
                return (executeQuery.Result == -1);
            }
            catch (OperationCanceledException)
            {
                Utils.WriteLog(_instance + "[" + executeQuery.Id + "][C]");
                throw;
            }
            catch (SqlException ex)
            {
                Utils.WriteLog(_instance + "[" + executeQuery.Id + "][SQL_EX]" + "\n" + ex.Message + "\n" + ex.InnerException);
                if (ex.Message.Contains("Operation cancelled by user"))
                {
                    throw new OperationCanceledException();
                }
                else if (ex.Number == -2) // Timeout or "general network error"
                {
                    throw new SqlTimeoutException();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Utils.WriteLog(_instance + "[" + executeQuery.Id + "][EX]" + "\n" + ex.Message + "\n" + ex.InnerException);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<bool> KillAllConnections(string dbname)
        {
            var sb = new StringBuilder();
            sb.Append(@" DECLARE @spid int
                        SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id('@dbname')
                        WHILE @spid IS NOT NULL
                        BEGIN
                        EXECUTE ('KILL ' + @spid)
                        SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id('@dbname') AND spid > @spid
                        END");
            sb.Replace("@dbname", dbname);

            var result = await ExecuteNonQueryAsync(sb.ToString());
            Utils.WriteLog("kill all result: " + result);
            return result;


        }
        public async Task<bool> ExecuteSp(CancellationToken token, string command, IEnumerable<string[]> sqlParams = null)
        {
            var conn = GetConnection();
            var cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = command,
                CommandType = CommandType.StoredProcedure
            };
            if (sqlParams != null)
                foreach (var p in sqlParams)
                {
                    cmd.Parameters.AddWithValue(p[0], p[1]);
                    Utils.WriteLog(string.Format("Appended parameter {0} with value {1}", p[0], p[1]));
                }

            var result = Task.Run(() => cmd.ExecuteNonQueryAsync(), token);
            try
            {
                conn.Open();
                await result;
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
            catch (SqlException ex)
            {
                Utils.WriteLog("Executesp sql exception: " + ex.Message + "\n" + ex.InnerException);
                if (ex.Message.Contains("Operation cancelled by user"))
                {
                    throw new OperationCanceledException();
                }
                if (ex.Number == -2) // Timeout or "general network error"
                {
                    throw new SqlTimeoutException();
                }
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result.Result == -1;
        }
    }
}
