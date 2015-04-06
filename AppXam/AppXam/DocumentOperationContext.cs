using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class DocumentOperationContext : IOperationContext<Document>
    {
        public Document Context { get; set; }

        public void RenewContext()
        {
            Context = new Document();
        }
    }
}
