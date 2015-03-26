using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class Folder : BaseStructure , IHierarchicalStructure
    {
        public IList<BaseStructure> Childs { get; set; }
        
        public Folder()
        {
            ImgSource = "folder.png";
            Childs = new List<BaseStructure>();
        }
    }
}
