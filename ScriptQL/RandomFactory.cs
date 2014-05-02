using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace ScriptQL
{
    public class RandomFactory
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static List<string> GetRandomListOfString(int listCount, int maxValue)
        {
            Debug.Assert(listCount > 0);

            var random = new Random();
            var list = new List<string>();
            for (var i = 0; i < listCount; i++)
            {
                var s = "";
                for (var j = 0; j < maxValue; j++)
                {
                    s += CHARS[random.Next(CHARS.Length)];
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
            for (var i = 0; i < listCount; i++)
            {
                string s = null;
                for (var j = 0; j < maxValue; j++)
                {
                    s += CHARS[random.Next(CHARS.Length)];
                    s += Utils.SPECIALCHARS[random.Next(0, Utils.SPECIALCHARS.Length)].ToString(CultureInfo.InvariantCulture);
                }
                list.Add(s);
            }
            return list;
        }
    }
}
