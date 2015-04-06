using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppXam.Repositories
{
    public interface IArchiveRepository
    {
        BaseStructure GetHomeFolder();
        BaseStructure GetStructure(string id);
        IList<DocumentClass> GetDocumentClasses();
    }
}
