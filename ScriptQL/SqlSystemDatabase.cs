using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptQL
{
    class SqlSystemDatabase : SqlDatabase
    {
        public SqlSystemDatabase(SqlInstance parent, string name, string status, sbyte singleUserAccess, bool sysDb) : base(parent, name, status, singleUserAccess, sysDb)
        {
            // to be implemented
        }
    }
}
