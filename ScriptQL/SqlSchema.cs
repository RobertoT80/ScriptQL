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

        public void BindData()
        {
            GetTables();
            //this.getViews();
        }

        private void GetTables() // unificate with getViews
        {
            var sb = new StringBuilder();
            sb.Append("USE [@dbname] SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ");
            sb.Append("WHERE TABLE_SCHEMA = '@tablename' AND TABLE_TYPE = 'BASE TABLE' ");
            sb.Append("ORDER BY TABLE_NAME");
           
            sb.Replace("@dbname", parent.Name);
            sb.Replace("@tablename", name);
                
            var conn = parent.Parent.GetConnection();
            var cmd = new SqlCommand(sb.ToString(), conn);
 
            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string s = rdr[0].ToString();
                    var oSqlTable = new SqlTable(this, s);
                    AddTableToSchema(oSqlTable);
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

        private void AddTableToSchema(SqlTable table)
        {
            if (table != null)
            {
                listTables.Add(table);
            }

        }


    }
}

