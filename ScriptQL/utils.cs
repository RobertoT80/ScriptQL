using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ScriptQL
{
    public class Utils
    {
        internal static string appPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), typeof(Program).Assembly.GetName().Name);
        internal static string logTxt = Path.Combine(appPath, "log.txt");
        private static readonly string serializedInstances = Path.Combine(appPath, "instances.dat");

        internal const string SPECIALCHARS = "[~#%&* {}/;:<>?|\"-]";

        public static void WriteLog(string text)
        {
            using (var oFileStream = new FileStream(logTxt, FileMode.Open, FileAccess.Write))
            {
                using (var oStreamWriter = new StreamWriter(oFileStream))
                {
                    lock (logTxt)
                    {
                        oFileStream.Seek(0, SeekOrigin.End);
                        oStreamWriter.WriteLine("{0}\t{1}", DateTime.Now, text);
                    }
                        
                }
            }
        }

        public static void SerializeBinary(List<SqlInstance> instanceList)
        {
            using (var fs = new FileStream(serializedInstances, FileMode.OpenOrCreate))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, instanceList);
                WriteLog("Data saved.");
            }
        }

        public static List<SqlInstance> DeserializeBinary()
        {
            if (!File.Exists(serializedInstances)) return null;

            using (var fs = new FileStream(serializedInstances, FileMode.Open))
            {
                var bf = new BinaryFormatter();
                try
                {
                    var serverList = (List<SqlInstance>)bf.Deserialize(fs);
                    foreach (var s in serverList)
                    {
                        s.isBusy = false;
                        s.isConnecting = false;
                        s.isOnline = null;
                    }
                    return serverList;
                }
                catch (Exception ex)
                {
                    WriteLog("Error loading instances.dat: " + ex.Message);
                    return null;
                }             
            }
        }

        public static void CreateLocalSettings()
        {
            Directory.CreateDirectory(appPath);
            if (!File.Exists(logTxt)) File.Create(logTxt).Dispose();
        }
       
        public static bool IsStringValid(string s)
        {
            Debug.Assert(s.Any());
            return SPECIALCHARS.All(cp => s.All(cs => cp != cs));
        }
    }
}
