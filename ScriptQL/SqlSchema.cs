using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ScriptQL
{
        [Serializable]
        public class SqlSchema
        {
        public SqlDatabase parent;
        public string name { get; set; }

        public List<SqlTable> listTables = new List<SqlTable>();
        //public List<SqlView> listViews = new List<SqlView>();

        public SqlSchema(SqlDatabase parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public void bindData()
        {
            getTables();
            //this.getViews();
        }

        private void getTables() // unificate with getViews
        {
            var sb = new StringBuilder();
            sb.Append("USE [@dbname] SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ");
            sb.Append("WHERE TABLE_SCHEMA = '@tablename' AND TABLE_TYPE = 'BASE TABLE' ");
            sb.Append("ORDER BY TABLE_NAME");
           
            sb.Replace("@dbname", parent.name);
            sb.Replace("@tablename", name);
                
            var conn = parent.parent.GetConnection();
            var cmd = new SqlCommand(sb.ToString(), conn);
 
            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string s = rdr[0].ToString();
                    var oSqlTable = new SqlTable(this, s);
                    addTableToSchema(oSqlTable);
                }
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

        //private void getViews() // unificate with getViews
        //{
        //    SqlConnection conn = parent.parent.GetConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "USE " + this.parent.name + Environment.NewLine +
        //                      "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = " + "'" + this.name + "'" + Environment.NewLine +
        //                      "AND TABLE_TYPE = 'VIEW' ORDER BY TABLE_SCHEMA";

        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            string name = rdr[0].ToString();
        //            SqlView oSqlView = new SqlView(this, name);
        //            this.addViewToSchema(oSqlView);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        utils.WriteLog(ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        private void addTableToSchema(SqlTable table)
        {
            if (table != null)
            {
                listTables.Add(table);
            }

        }


    }
}

