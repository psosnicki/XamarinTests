using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class Document : BaseStructure
    {
        public string DocumentClassName { get; set; }
        public IList<IndexField> Indexes { get; set; }

        public Document()
        {
            Indexes = new List<IndexField>();
        }
    }
}
