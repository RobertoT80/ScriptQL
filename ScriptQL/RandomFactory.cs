using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptQL
{
    public class RandomFactory
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static List<string> GetRandomListOfString(int listCount, int maxValue)
        {
            Debug.Assert(listCount > 0);

            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < listCount; i++)
            {
                var s = "";
                for (int j = 0; j < maxValue; j++)
                {
                    s += chars[random.Next(chars.Length)];
                }
                list.Add(s);
            }
            return list;
        }

        public static List<string> GetRandomListOfInt(int listCount, int maxValue)
        {
            Debug.Assert(listCount > 0);

            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < listCount; i++)
            {
                var s = "";
                for (int j = 0; j < maxValue; j++)
                {
                    s += random.Next(maxValue);
                }
                list.Add(s);
            }
            return list;
        }

        public static List<string> GetRandomListOfSpecialString(int listCount, int maxValue)
        {
            Debug.Assert(listCount > 0);

            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < listCount; i++)
            {
                string s = null;
                for (int j = 0; j < maxValue; j++)
                {
                    s += chars[random.Next(chars.Length)];
                    s += Utils.patternSpecialChars[random.Next(0, Utils.patternSpecialChars.Length)].ToString();
                }
                list.Add(s);
            }
            return list;
        }
    }
}
