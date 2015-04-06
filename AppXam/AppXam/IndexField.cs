using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppXam
{
    public class IndexField
    {
        public string DisplayName { get; set; }
        public bool Required { get; set; }
        public IndexType Type { get;set;}
        public object Value { get; set; }
    }

    public enum IndexType
    {
        INTEGER,
        DATETIME,
        STRING
    }
}
