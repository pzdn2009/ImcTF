using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Core
{
    public class RunOnce
    {
        private static object lockObject = new object();
        private static List<string> list = new List<string>();

        public static void Add(string key)
        {
            lock (lockObject)
            {
                if (!list.Contains(key))
                    list.Add(key);
            }
        }

        public static bool Exist(string key)
        {
            lock (lockObject)
            {
                return list.Contains(key);    
            }
            
        }

        public static void Remove(string key)
        {
            lock (lockObject)
            {
                if (Exist(key))
                    list.Remove(key);
            }
        }
    }
}
