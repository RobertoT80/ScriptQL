using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptQL
{
    [Serializable]
    class SqlSystemDatabase : SqlDatabase
    {
        public SqlSystemDatabase(SqlInstance parent, string name, string status, sbyte singleUserAccess) : base(parent, name, status, singleUserAccess)
        {
            // to be implemented
        }
        //internal override void GetSchema()
        //{
           
        //}
    }
}
