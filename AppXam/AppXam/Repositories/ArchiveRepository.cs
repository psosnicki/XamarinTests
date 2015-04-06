using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam.Repositories
{
    public class ArchiveRepository : IArchiveRepository
    {
        public ArchiveRepository()
        {
           
        }
        Folder hf;
        public BaseStructure GetHomeFolder()
        {
             hf = new Folder { DisplayName = "My home", IsFavorite = true, ModifiedDate = DateTime.Today };
            for (int i = 0; i < 3; i++)
            {
                hf.Childs.Add(new Folder { DisplayName = "Folder " + i , ModifiedDate = DateTime.Now.AddHours(-2),Parent= hf});
                hf.Childs.Add(new Dossier { DisplayName = "Dossier " + i, ModifiedDate = DateTime.Now.AddHours(-3), Parent = hf });
            }
            int k = 0;
            foreach (IHierarchicalStructure c in hf.Childs)
            {
                c.Childs.Add(new Folder { DisplayName = "SubFolder " + k, ModifiedDate = DateTime.Now.AddHours(-4) ,Parent = c});
                c.Childs.Add(new Dossier { DisplayName = "SubDossier " + k, ModifiedDate = DateTime.Now.AddHours(-2), Parent = c });
                k++;
            }
         
            return hf;
        }


        public BaseStructure GetStructure(string id)
        {
            return hf.Childs[0];
        }


        public IList<DocumentClass> GetDocumentClasses()
        {
            return new List<DocumentClass> {
                new DocumentClass{ DisplayName = "Invoice"},
                new DocumentClass{ DisplayName = "Faktura"}
            };
        }
    }
}
