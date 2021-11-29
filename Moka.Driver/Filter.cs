using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Filter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public Filter(string field, string value)
        {
            Field = field;
            Value = value;
        }
    }
    public class Update
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public Update(string field, string value)
        {
            Field = field;
            Value = value;
        }
    }
}
