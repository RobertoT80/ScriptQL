﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace ScriptQL
{
    [Serializable]
    public class SqlDatabase
    {
        private readonly string _name;
        [Category("Properties"), ReadOnly(true)]
        public string name
        {
            get { return _name; }
        }

        private string _status;

        [Category("Properties"), ReadOnly(true)]
        public string status
        {
            get { return _status; }
        }

        private readonly sbyte _singleUserAccess;

        [Category("Properties"), ReadOnly(true)]
        public string access
        {
            get { return _singleUserAccess == 0 ? "multi" : "single"; }
        }

        private readonly bool _sysDb;

        [Description("True if the database is a system one.")]
        [Category("Properties")]
        [ReadOnly(true)]
        public bool sysDb
        {
            get { return _sysDb; }
        }

        private DateTime _created;

        [Category("Properties")]
        [ReadOnly(true)]
        public DateTime created
        {
            get { return _created; }
        }

        private DateTime? _lastBackup;

        [Category("Properties")]
        [ReadOnly(true)]
        public DateTime? lastBackup
        {
            get { return _lastBackup; }
        }

        [Category("Properties"), ReadOnly(true)]
        public int id { get; private set; }

        [Category("Size (MB)"), ReadOnly(true)]
        public decimal rowsSize { get; private set; }

        [Category("Size (MB)"), ReadOnly(true)]
        public decimal logSize { get; private set; }

        [Category("Size (MB)"), ReadOnly(true)]
        public decimal totalSize { get; private set; }

        public SqlInstance parent;

        

        [Category("Properties"), ReadOnly(true)]
        public string recovery { get; private set; }

        private string _collation;

        [Category("Properties"), ReadOnly(true)]
        public string collation
        {
            get { return _collation; }
        }

       
        [Category("Data Files")]
        [ReadOnly(true)]
        public string datafilePrimaryLogical { get; set; }

        [Category("Data Files")]
        [ReadOnly(true)]
        public string datafilePrimaryPhysical { get; set; }

        [Category("Data Files")]
        [ReadOnly(true)]
        public string datafileLogLogical { get; set; }

        [Category("Data Files")]
        [ReadOnly(true)]
        public string datafileLogPhysical { get; set; }

        [Category("Data Files")]
        [ReadOnly(true)]

        public List<string[]> datafileDataSecondary { get; set; }

        [Category("Data Files")]
        [ReadOnly(true)]
        public List<string[]> datafileLogSecondary { get; set; }

        private List<string> dbPhysicalFiles;

        public bool isBusy;

        public List<SqlSchema> listSchema = new List<SqlSchema>();

        //List<Table> listTables = new List<Table>();

        public SqlDatabase(SqlInstance parent, string name, string status, sbyte singleUserAccess, bool sysDb)
        {
            this.parent = parent;
            _name = name;
            _status = status;
            _singleUserAccess = singleUserAccess;
            _sysDb = sysDb;

            //getPaths();
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(Object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public void getDatabaseProperties()
        {
            var sb = new StringBuilder();
            sb.Append(@"SELECT create_date, collation_name, state_desc, recovery_model_desc,
                            (SELECT CONVERT( SmallDateTime , MAX(Backup_Finish_Date)) FROM msdb.dbo.backupset WHERE type = 'd' AND database_name = '@dbname') AS last_backup,
                            database_id,
                            is_auto_create_stats_on,
                            is_auto_update_stats_on,
                            is_auto_update_stats_async_on,
                            is_fulltext_enabled,
                            is_broker_enabled
                            FROM sys.databases where name = '@dbname';");
            sb.Replace("@dbname", name);

            var conn = parent.GetConnection();
            var cmd = new SqlCommand(sb.ToString(), conn);
            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                rdr.Read();
                _created = rdr.GetDateTime(0); //create_date
                _status = rdr.GetString(2); //state_desc
                recovery = rdr.GetString(3); //recovery_model_desc

                if (!rdr.IsDBNull(4))
                {
                    _lastBackup = rdr.GetDateTime(4);
                }

                id = (int) rdr.GetSqlInt32(5);
                GetSize();
                if (_status != "ONLINE") return;
                if (!rdr.IsDBNull((1)))
                    // If AUTO_CLOSE is ON the query retrieves null, it's a instance-side issue http://technet.microsoft.com/en-us/library/ms178534.aspx
                {
                    _collation = rdr.GetString(1);
                }
                //if (_singleUserAccess == 0 && _status == "ONLINE")
                if (_status == "ONLINE")
                {
                    getPaths();    
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
        }


        private void getPaths()
        {
            var conn = parent.GetConnection();
            var cmd = new SqlCommand {Connection = conn};
            var sb = new StringBuilder("select name, physical_name, file_id, type from [@dbname].sys.database_files ORDER BY file_id;");
            sb.Replace("@dbname", _name);
            cmd.CommandText = sb.ToString();
     
            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    switch (rdr["file_id"].ToString())
                    {
                        case "1":
                            datafilePrimaryLogical = rdr.GetString(0); // primary logical file
                            datafilePrimaryPhysical = rdr.GetString(1); // primary physical file
                            break;
                        case "2":
                            datafileLogLogical = rdr.GetString(0); // log logical file
                            datafileLogPhysical = rdr.GetString(1); // log physical file
                            break;
                        default:
                            datafileDataSecondary = new List<string[]>();
                            datafileLogSecondary = new List<string[]>();
                            if (rdr["Type"].ToString() == "D")
                            {
                                datafileDataSecondary.Add(new[]
                                {(rdr["name"].ToString()), (rdr["physical_name"].ToString())});
                            }
                            else if (rdr["Type"].ToString() == "L")
                            {
                                datafileLogSecondary.Add(new[] {(rdr["name"].ToString()), (rdr["physical_name"].ToString())});
                            }
                            break;
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
            // the collection will be useful to delete the original files if the database got corrupted (i.e. stuck in restoring status)
            dbPhysicalFiles = new List<string> { datafilePrimaryPhysical, datafileLogPhysical };
            if (datafileDataSecondary != null && datafileDataSecondary.Count > 0)
            {
                dbPhysicalFiles.AddRange(from arr in datafileDataSecondary from s in arr select s);
            }
            if (datafileLogSecondary != null && datafileLogSecondary.Count > 0)
            {
                dbPhysicalFiles.AddRange(from arr in datafileLogSecondary from s in arr select s);
            }
        }

        private void GetSize()
        {
            var conn = parent.GetConnection();
            var cmd = new SqlCommand {Connection = conn};
            var sb = new StringBuilder();
            sb.Append(@"SELECT 
	                        log_size_mb = CAST(SUM(CASE WHEN type_desc = 'LOG' THEN size END) * 8. / 1024 AS DECIMAL(8,2)),
                            row_size_mb = CAST(SUM(CASE WHEN type_desc = 'ROWS' THEN size END) * 8. / 1024 AS DECIMAL(8,2)),
                            total_size_mb = CAST(SUM(size) * 8. / 1024 AS DECIMAL(8,2))
                        FROM sys.master_files WITH(NOWAIT)
                        WHERE database_id = '@database_id'");
            sb.Replace("@database_id", id.ToString(CultureInfo.InvariantCulture));
            cmd.CommandText = sb.ToString();
            try
            {
            conn.Open();
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            logSize = decimal.Parse(rdr["log_size_mb"].ToString());
            rowsSize = decimal.Parse(rdr["row_size_mb"].ToString());
            totalSize = decimal.Parse(rdr["total_size_mb"].ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void bindData()
        {
            getSchema();
        }

        private void getSchema()
        {
            var conn = parent.GetConnection();
            var cmd = new SqlCommand();

            var sb =
                new StringBuilder(
                    "USE [@dbname] SELECT DISTINCT table_schema FROM INFORMATION_SCHEMA.TABLES ORDER BY table_schema");
            sb.Replace("@dbname", name);
            cmd.Connection = conn;
            cmd.CommandText = sb.ToString();

            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (_sysDb == false)
                    {
                        string s = rdr.GetString(0);
                        var oSchema = new SqlSchema(this, s);
                        AddSchemaToDatabase(oSchema);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddSchemaToDatabase(SqlSchema oSchema)
        {
            if (oSchema != null)
            {
                listSchema.Add(oSchema);
            }
        }

        //public bool AlterSync(string command, sbyte commandTimeout = 5, List<string[]> sqlParams = null, bool withRoolbackImmediate = false)
        //{
        //    var sb = new StringBuilder("ALTER DATABASE [@dbname] @command ");
        //    sb.Replace("@dbname", name);
        //    sb.Replace("@command", command);

        //    if (sqlParams != null)
        //    {
        //        foreach (var par in sqlParams)
        //        {
        //            sb.Replace(par[0], par[1]);
        //        }
        //    }

        //    if (withRoolbackImmediate)
        //    {
        //        sb.Append("WITH ROLLBACK IMMEDIATE");
        //    }
        //    return parent.ExecuteNonQuerySync(sb.ToString(), commandTimeout);
        //}

        public async Task<bool> Alter(string command, CancellationToken token, sbyte commandTimeout = 10, List<string[]> sqlParams = null,bool withRoolbackImmediate = false)
        {
            var sb = new StringBuilder("ALTER DATABASE [@dbname] @command ");
            sb.Replace("@dbname", name);
            sb.Replace("@command", command);

            if (sqlParams != null)
            {
                foreach (var par in sqlParams)
                {
                    sb.Replace(par[0], par[1]);
                }
            }

            if (withRoolbackImmediate)
            {
                sb.Append("WITH ROLLBACK IMMEDIATE");
            }
            var executeAlter = Task.Run(() => parent.ExecuteNonQueryAsync(sb.ToString(), token, commandTimeout));
            try
            {
                await executeAlter;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                Utils.WriteLog("executeAlter result: " + executeAlter.Result);
                return true;

            }
            catch (OperationCanceledException)
            {
                throw new OperationCanceledException();
            }
        }

        public async Task<bool> BackupAsync(List<string> par, CancellationToken token)
        {      
            if (status != "ONLINE") { return false; }

            var backupFile = Path.Combine(parent.pathBackup + Path.DirectorySeparatorChar + name + ".bak");
            var sb = new StringBuilder("BACKUP DATABASE [@dbname] TO DISK='@backupfile'");
            sb.Replace("@dbname", name);
            sb.Replace("@backupfile", backupFile);

            if (par.Count > 0)
            {
                sb.Append(" WITH ");
                foreach (var p in par)
                {
                    sb.Append(p);
                    sb.Append(",");
                }
                var s = sb.ToString();
                sb.Clear();
                sb.Append(s.Substring(0, s.Length - 1));
            }

            var backup = Task.Run(() => parent.ExecuteNonQueryAsync(sb.ToString(), token));
            try
            {
                
                await backup;
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                return backup.Result;
            }
            catch(OperationCanceledException)
            {
                throw new OperationCanceledException();
            }
        }

        public static async Task<bool> VerifyBackup(SqlInstance instance, string filename, CancellationToken token)
        {
            var sb = new StringBuilder("RESTORE VERIFYONLY FROM DISK='@filename'");
            sb.Replace("@filename", filename);

            var verify = Task.Run(() => instance.ExecuteNonQueryAsync(sb.ToString(), token));

            await verify;
            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
            return verify.Result;
        }

        private string restoreLogicalFilenames(string filename)
        {
            // Get backup logical names
            var sb = new StringBuilder("RESTORE FILELISTONLY FROM DISK='@filename'");
            sb.Replace("@filename", filename);

            var mdfLogicalBackup = "";
            var ldfLogicalBackup = "";
            var ndfSecondary_logical_Backup = new List<string[]>();
            var ldfSecondary_logical_Backup = new List<string[]>();

            var conn = parent.GetConnection(); 
            var cmd = new SqlCommand(sb.ToString(), conn);

            try
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read()) // TODO: handle rdr["FileGroupName"]
                {
                    switch (rdr["FileId"].ToString())
                    {
                        case "1":
                            mdfLogicalBackup = rdr["LogicalName"].ToString();
                            break;
                        case "2":
                            ldfLogicalBackup = rdr["LogicalName"].ToString();
                            break;
                        default:
                            switch (rdr["Type"].ToString())
                            {
                                case "D":
                                    ndfSecondary_logical_Backup.Add(new[] {rdr["LogicalName"].ToString(), rdr["PhysicalName"].ToString()});
                                    break;
                                case "L":
                                    ldfSecondary_logical_Backup.Add(new[] {rdr["LogicalName"].ToString(), rdr["PhysicalName"].ToString()});
                                    break;
                            }
                            break;
                    }
                }
            }
            //catch (SqlException)
            //{

            //}
            finally
            {
                conn.Close();
            }
            
            // Restore with replace
            sb.Clear();
            sb.Append("RESTORE DATABASE [@dbname] FROM DISK = '@filename' ");
            sb.Append("WITH REPLACE, MOVE '@mdf_logical_backup' TO '@mdf_physical',");
            sb.Append("MOVE '@ldf_logical_backup' TO '@ldf_physical'");
            sb.Replace("@dbname", _name);
            sb.Replace("@filename", filename);
            sb.Replace("@mdf_logical_backup", mdfLogicalBackup);
            sb.Replace("@mdf_physical", datafilePrimaryPhysical);
            sb.Replace("@ldf_logical_backup", ldfLogicalBackup);
            sb.Replace("@ldf_physical", datafileLogPhysical);

            if (ndfSecondary_logical_Backup.Count > 0)
            {
                var count = 0;
                foreach (var s in ndfSecondary_logical_Backup)
                {
                    sb.Append(", MOVE '@logical_ndf' TO '@datafile'");
                    sb.Replace("@logical_ndf", ndfSecondary_logical_Backup[count][0]);
                    sb.Replace("@datafile", Path.Combine(parent.pathData + ndfSecondary_logical_Backup[count][0] + ".ndf"));
                    count++;
                }
            }
            return sb.ToString();
        }

        public async Task<bool> RestoreAsync(string filename, CancellationToken token)
        {
            var sb = restoreLogicalFilenames(filename);
            var restore = Task.Run(() => parent.ExecuteNonQueryAsync(sb, token));
            await restore;
            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
            return restore.Result;
        }


        public async Task<bool> Detach(CancellationToken token)
        {
            var sqlParams = new List<string[]> { new[] { "@dbname", name } };
            var detach = Task.Run(() => parent.ExecuteSp(token, "SP_DETACH_DB", sqlParams));

            if (_status != "ONLINE")
            {
                await Alter("SET ONLINE", token, 5, null, true);
            }
            if (_singleUserAccess != 1)
            {
                await Alter("SET SINGLE_USER", token, 5, null, true);
            }

            await detach;
            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
            Utils.WriteLog("detach result: " + detach.Result);
            return detach.Result;
        }


        public async Task<bool> check(CancellationToken token)
        {
            var sb = new StringBuilder();
            sb.Append("dbcc checkdb([@dbname]) ");
            sb.Append("WITH NO_INFOMSGS, ALL_ERRORMSGS");
            sb.Replace("@dbname", _name);
            var check = Task.Run(() => parent.ExecuteNonQueryAsync(sb.ToString(), token));

            await check;
            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
            return check.Result;
 
        }
    }
}

