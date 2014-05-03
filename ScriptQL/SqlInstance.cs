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

        public bool IsBusy,
            IsConnecting;
        public bool? IsOnline = null;

        public static List<SqlInstance> ListServers = new List<SqlInstance>();
        public List<SqlDatabase> DatabasesCollection = new List<SqlDatabase>();

        [Category("System Paths"), ReadOnly(true)]
        public string PathData { get; private set; }

        [Category("System Paths"), ReadOnly(true)]
        public string PathLog { get; private set; }

        [Category("System Paths"), ReadOnly(true)]
        public string PathBackup { get; private set; }

        private readonly bool _winAuth;

        [Category("Properties")]
        [ReadOnly(true)]
        public bool WinAuth
        {
            get { return _winAuth; }
        }

        [Category("Properties"), ReadOnly(true)]
        public string Hostname { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string Machinename { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string Collation { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string Service { get; set; }

        [Category("Properties"), ReadOnly(true)]
        public string Instancename { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string Productversion { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public string Edition { get; private set; }

        [Category("Features"), ReadOnly(true)]
        public int Isclustered { get; private set; }

        [Category("Features"), ReadOnly(true)]
        public int Isfulltextinstalled { get; private set; }

        [Category("Properties"), ReadOnly(true)]
        public int Isintegratedsecurityonly { get; private set; }

        [Category("Size (GB)"), ReadOnly(true)]
        public decimal TotalDataSize { get; set; }

        [Category("Size (GB)"), ReadOnly(true)]
        public decimal TotalLogSize { get; set; }

        public static string[] SystemNames ={"msdb", "master", "model", "tempdb", "distribution", "resource"};


        public SqlInstance(string instance, string user, string password, bool winAuth, bool doNotConnect = false)
        {
            _instance = instance;
            _user = user;
            _password = password;
            _winAuth = winAuth;

            if (doNotConnect) return;
            GetPaths();
            GetProperties();
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
            return string.Concat(Machinename, Instancename).GetHashCode();
        }

        private void GetProperties()
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
                Hostname = rdr.GetString(0); //hostname
                Machinename = rdr.GetString(1); //machinename
                Service = rdr.GetString(2);  //servicename            
                Instancename = !rdr.IsDBNull(3) ? rdr.GetString(3) : "Default";
                Collation = rdr.GetString(4);  //collation
                Productversion = rdr.GetString(5); //productversion
                Edition = rdr.GetString(6);//edition
                Isclustered = rdr.GetInt32(7);//isclustered
                Isfulltextinstalled = rdr.GetInt32(8);//isfulltextinstalled
                Isintegratedsecurityonly = rdr.GetInt32(9);//isintegratedsecurityonly
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

        public void GetPaths()
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
                PathData = rdr.GetString(0);
                PathLog = rdr.GetString(1);
                PathBackup = rdr.GetString(2);
            }
            catch (Exception ex)
            {
                Utils.WriteLog("GetPaths Exception : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            GetProperties();
        }

        public List<string> GetPhysicalFiles()
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
            sb.Replace("@winauth", WinAuth.ToString());
            sb.Replace("@user", _user);
            sb.Replace("@password", _password);

            var conn = new SqlConnection(sb.ToString());
            return conn;
        }

        public async Task<bool> TestConnection(CancellationToken token)
        {
            IsConnecting = true;
            var conn = GetConnection();
            var connection = Task.Run(() => conn.OpenAsync(token));
            try
            {
                await connection;
                if (token.IsCancellationRequested)
                {
                    IsOnline = null;
                    token.ThrowIfCancellationRequested();
                }
                IsOnline = true;
                return true;
            }
            catch (OperationCanceledException)
            {
                IsOnline = null;
                return false;
            }
            catch (Exception)
            {
                IsOnline = false;
                return false;
            }
            finally
            {
                conn.Close();
                IsConnecting = false;
            }
        }

        public bool TestConnectionSync()
        {
            var conn = GetConnection();
            try
            {
                conn.Open();
                IsOnline = true;
                return true;
            }
            catch (SqlException ex)
            {
                Utils.WriteLog("Connection to " + _instance + "failed: \n" + ex.Message);
                MessageBox.Show(ex.Message);
                IsOnline = false;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetDbList(bool systemdbEnabled)
        {
            if (IsOnline != true)
            {
                MessageBox.Show("Can't connect now to " + _instance + ", please try again.");
                return;
            }
            DatabasesCollection = new List<SqlDatabase>();
            const string qry = @"SELECT name, state_desc, user_access, 
                            CASE is_distributor
	                            WHEN 1 then 'true'
	                            ELSE 'false'
                            END
                            FROM sys.databases ORDER BY name";

            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(qry, conn))
                {
                    try
                    {
                        conn.Open();
                        var rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {

                            var name = rdr.GetString(0);
                            var status = rdr.GetString(1);
                            var userAccess = (sbyte)rdr.GetByte(2);
                            var distributor = bool.Parse(rdr.GetString(3));

                            if (SystemNames.Any(name.Contains) || distributor)
                            {
                                if (systemdbEnabled && name != "tempdb")
                                {
                                    var oDatabase = new SqlSystemDatabase(this, name, status, userAccess);
                                    DatabasesCollection.Add(oDatabase);
                                }

                            }
                            else
                            {
                                var oDatabase = new SqlDatabase(this, name, status, userAccess);
                                DatabasesCollection.Add(oDatabase);
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
            }
        }

        private bool DbnameCheck(string dbname)
        {
            if (!Utils.IsStringValid(dbname))
            {
                MessageBox.Show(dbname + " is not a valid name.");
                return false;
            }
            if (DatabasesCollection.FirstOrDefault(s => s.Name == dbname) != null)
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

        public bool CreateDatabaseSync(string dbname)
        {
            // create for attach (ldf is optional).
            // Invoked by the create form and the main function that restores a database collection.
            if (!DbnameCheck(dbname)) return false;

            var sbCreate = new StringBuilder();
            sbCreate.Append("CREATE DATABASE [@dbname] ");
            sbCreate.Replace("@dbname", dbname);

            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(sbCreate.ToString(), conn))
                {
                    try
                    {
                        conn.Open();
                        int databaseCreated = cmd.ExecuteNonQuery();
                        if (databaseCreated == -1)
                        {
                            var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0);
                            DatabasesCollection.Add(oDatabase);
                            return true;
                        }
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public async Task<bool> CreateDatabase(string dbname, FileInfo mdf, FileInfo ldf = null)
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
                var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0);
                DatabasesCollection.Add(oDatabase);
            }
            return createDatabase.Result;
        }

        public async Task<bool> CreateDatabase(string dbname, string mdf, string[] ndfArray = null, string[] ldfArray = null)
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
            var oDatabase = new SqlDatabase(this, dbname, "ONLINE", 0);
            DatabasesCollection.Add(oDatabase);
            return createDatabase.Result;
        }

        public async Task<bool> ExecuteNonQueryAsync(string query, sbyte commandTimeout = 0)
        {
            Debug.Assert(!string.IsNullOrEmpty(query));
            Debug.Assert(commandTimeout >= 0);

            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(query, conn) {CommandTimeout = commandTimeout})
                {
                    
                    try
                    {
                        conn.Open();
                        var execution = Task.Run(() => cmd.ExecuteNonQueryAsync());
                        Debug.Assert(conn.State == ConnectionState.Open);
                        await execution;
                        return (execution.Result == -1);
                    }
                    catch (SqlException ex)
                    {
                        Utils.WriteLog(cmd.CommandText + "\nSqlException: " + ex.Message + "\n" + ex.InnerException);
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
                }
            }
        }

        public async Task<bool> ExecuteNonQueryAsync(string query, CancellationToken token, sbyte commandTimeout = 0)
        {
            Debug.Assert(!string.IsNullOrEmpty(query));
            Debug.Assert(token != null);
            Debug.Assert(commandTimeout >= 0);

            using (SqlConnection conn = GetConnection())
            {
                using (var cmd = new SqlCommand(query, conn) {CommandTimeout = commandTimeout})
                {
                    
                    try
                    {
                        conn.Open();
                        var execution = Task.Run(() => cmd.ExecuteNonQueryAsync(token));
                        Debug.Assert(conn.State == ConnectionState.Open);
                        await execution;
                        if (token.IsCancellationRequested)
                        {
                            throw new OperationCanceledException();
                        }
                        Utils.WriteLog(cmd.CommandText + "\n" + execution.Result);
                        return (execution.Result == -1);
                    }
                    catch (OperationCanceledException)
                    {
                        Utils.WriteLog(cmd.CommandText + "\nCanceled");
                        throw;
                    }
                    catch (SqlException ex)
                    {
                        Utils.WriteLog(cmd.CommandText + "\nSqlException: "+ ex.Message +"\n" + ex.InnerException);
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
                    catch (Exception ex)
                    {
                        Utils.WriteLog(cmd.CommandText + "\nException: "+ ex.Message +"\n" + ex.InnerException);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public bool KillAllConnections(string dbname)
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

            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(sb.ToString(), conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public async Task<bool> ExecuteSp(CancellationToken token, string command, IEnumerable<string[]> sqlParams = null)
        {
            using (var conn = GetConnection())
            {
                using(var cmd = new SqlCommand{Connection = conn,CommandText = command,CommandType = CommandType.StoredProcedure})
                {
                   
                    if (sqlParams != null)
                        foreach (var p in sqlParams)
                        {
                            cmd.Parameters.AddWithValue(p[0], p[1]);
                        }
                    try
                    {
                        conn.Open();
                        var result = Task.Run(() => cmd.ExecuteNonQueryAsync(), token);
                        await result;
                        if (token.IsCancellationRequested)
                        {
                            token.ThrowIfCancellationRequested();
                        }
                        return result.Result == -1;
                    }
                    catch (OperationCanceledException)
                    {
                        Utils.WriteLog("ExecuteSP canceled: " + cmd.CommandText);
                        throw;
                    }
                    catch (SqlException ex)
                    {
                        Utils.WriteLog("ExecuteSP sql exception: " + cmd.CommandText + "\n" + ex.Message + "\n" +
                                       ex.InnerException);
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
                    catch (Exception ex)
                    {
                        Utils.WriteLog("ExecuteSP exception: " + cmd.CommandText + "\n" + ex.Message + "\n" +
                                       ex.InnerException);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            } 
        }
    }
}
