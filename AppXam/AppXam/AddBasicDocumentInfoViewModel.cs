using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXam
{
    public class AddBasicDocumentInfoViewModel : BaseViewModel
    {
        IArchiveRepository _archiveRepository;

        public ObservableCollection<DocumentClass> DocClasses { get; set; }
        public ICommand GoNextCmd { get; set; }

        public AddBasicDocumentInfoViewModel(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
            DocClasses = new ObservableCollection<DocumentClass>();
            GoNextCmd = new Command(GoNext);
            GetDocumentClasses();
        }

        private void GoNext()
        {
            AddNewFlow.CreateIndexesView();
        }

        private async void GetDocumentClasses()
        {
            try
            {
                IsLoading = true;
                var classes = await Task.Run<IList<DocumentClass>>(() => { return _archiveRepository.GetDocumentClasses(); });
                foreach (var c in classes)
                    DocClasses.Add(c);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
