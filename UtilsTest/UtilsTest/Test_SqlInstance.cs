using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptQL;

namespace UtilsTest
{
    [TestClass]
    public class TestSqlInstance
    {
        private SqlInstance _s;
        private CancellationToken _token;

        [TestInitialize]
        public void InitializeServer()
        {
            _s = new SqlInstance("localhost", "", "", true, true);
            _token = new CancellationTokenSource().Token;
            Utils.CreateLocalSettings();
            Utils.WriteLog("Test Started.");
        }

        [TestCleanup]
        private void CleanUp()
        {
            Utils.WriteLog("Test Ended.");
        }


        [TestMethod]
        public void SqlServer_common()
        {
            SqlConnection conn = _s.GetConnection();
            Assert.IsNotNull(conn);
            Assert.IsNull(_s.Instancename);
            Assert.AreEqual(_s.IsBusy, false);
            Assert.IsNull(_s.IsOnline);

            var connection = _s.TestConnectionSync();
            Assert.AreEqual(connection, true);

            _s.GetDbList(true);
            _s.GetDbList(false);

            var wrongName = RandomFactory.GetRandomListOfSpecialString(1, 64)[0];
            var wrongdbcreated = _s.CreateDatabaseSync(wrongName);
            Assert.AreEqual(wrongdbcreated, false);
            wrongdbcreated = _s.CreateDatabase(wrongName).Result;
            Assert.AreEqual(wrongdbcreated, false);

            var goodNames = RandomFactory.GetRandomListOfString(8, 32);
            foreach (var goodName in goodNames)
            {
                var dbcreated = _s.CreateDatabaseSync(goodName);
                Assert.AreEqual(dbcreated, true);
                var deleted = _s.Drop(goodName).Result;
                Assert.AreEqual(deleted, true);
            }
            
            
            _s.GetPaths();
            _s.GetPhysicalFiles();

            Utils.SerializeBinary(new List<SqlInstance>(){_s});
            _s = null;

            _s = Utils.DeserializeBinary()[0];
            Assert.AreNotEqual(_s, null);
        }

    }
}
