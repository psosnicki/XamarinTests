using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class IndexesViewModel : BaseViewModel
    {
        private IArchiveRepository _archiveRepository;
        public ObservableCollection<IndexField> Indexes { get; set; }

        public IndexesViewModel(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
        }
    }
}
