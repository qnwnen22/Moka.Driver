using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class TypeExpansion
    {
        public static string GetClassName(this Type type, string separator = "_")
        {
            List<string> split = type.FullName.Split('+').ToList();
            split.RemoveAt(0);
            return string.Join(separator, split);
        }
    }
}
