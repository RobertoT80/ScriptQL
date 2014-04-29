using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ScriptQL
{
    [Serializable]
    public class SqlTable
    {
        readonly SqlSchema parent;
        public string name { get; private set; }
        public List<Column> listColumn = new List<Column>();

        public SqlTable(SqlSchema parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        public DataTable SelectFromTable(int rowsNumber, string column, string sortorder, int commandTimeout)
        {
            var conn = parent.parent.parent.GetConnection();
            var sb = new StringBuilder();
            sb.Append("SET ROWCOUNT @rowcount").Replace("@rowcount", rowsNumber.ToString(CultureInfo.InvariantCulture));
            sb.Append("USE [@dbname] ").Replace("@dbname", parent.parent.name);
            sb.Append("SELECT * FROM [@schema].[@table]").Replace("@schema", parent.name).Replace("@table", name);
            sb.Append("ORDER BY [@column] @sortorder").Replace("@column", column).Replace("@sortorder", sortorder);

            var da = new SqlDataAdapter(sb.ToString(), conn);
            da.SelectCommand.CommandTimeout = commandTimeout;

            var dt = new DataTable(name);

            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;


        }

        void AddColumnToTable(Column column)
        {
            listColumn.Add(column);
        }


        public void bindData()
        {
            getColumns();
        }

        private void getColumns() // unificate with getViews
        {
            var sb = new StringBuilder();
            sb.Append("USE [@dbname] ");
            sb.Append("SELECT COLUMN_NAME FROM [@dbname].INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '@schema' ");
            sb.Append("AND DATA_TYPE NOT IN('TEXT', 'NTEXT', 'IMAGE') AND TABLE_NAME = '@table' "); // not sortable data types
            sb.Append("ORDER BY COLUMN_NAME");

            sb.Replace("@dbname", parent.parent.name);
            sb.Replace("@schema", parent.name);
            sb.Replace("@table", name);

            SqlConnection conn = parent.parent.parent.GetConnection();
            var cmd = new SqlCommand(sb.ToString(), conn);

            try
            {
                conn.Open();
                Utils.WriteLog("executing : " + cmd.CommandText);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var s = rdr.GetString((0));
                    var column = new Column(this, s);
                    AddColumnToTable(column);
                } 
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
        public class SqlView : SqlTable
        {
            public SqlView(SqlSchema parent, string name) : base(parent, name)
            {

            }
        }
        [Serializable]
        public class Column
        {
            SqlTable parent;
            public string name { get; set; }
            public Column(SqlTable parent, string name)
            {
                this.parent = parent;
                this.name = name;
            }

        }
    }
}
