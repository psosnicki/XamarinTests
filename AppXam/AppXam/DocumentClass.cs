using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class DocumentClass
    {
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public IList<IndexField> Indexes {get;set;}

        public DocumentClass()
        {
            Indexes = new List<IndexField>();
        }

    }
}
