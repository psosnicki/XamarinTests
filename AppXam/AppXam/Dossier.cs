using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class Dossier : BaseStructure, IHierarchicalStructure
    {
        public IList<BaseStructure> Childs { get; set; }

        public Dossier()
        {
            ImgSource = "dossier.png";
            Childs = new List<BaseStructure>();
        }
    }
}
