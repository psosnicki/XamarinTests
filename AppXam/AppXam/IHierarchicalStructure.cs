using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public interface IHierarchicalStructure
    {
        public IList<BaseStructure> Childs { get; set; }
    }
}
