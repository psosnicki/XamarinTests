using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace AppXam
{
    public class RepositoryViewModel : BaseViewModel
    {
        private IArchiveRepository _archiveRepository;
        public ICommand LoadItemsCmd { get; set; }
        public ICommand ItemSelectedCmd { get; set; }
        public ICommand GoUpCmd { get; set; }
        public BaseStructure CurrentSelectedItem { get; set; }
        public ObservableCollection<BaseStructure> Structures { get; set; }
        public IHierarchicalStructure Structure { get; set; }

        string _currentPath;
        public string CurrentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; 
                    OnPropertyChanged();
            }
        }

        public RepositoryViewModel(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
            LoadItemsCmd = new Command(LoadMoreItems);
            ItemSelectedCmd = new Command(OnItemTapped);
            Structures = new ObservableCollection<BaseStructure>();
            GetHomeStructure();
        }

        private async void GetHomeStructure()
        {
            try
            {
                IsLoading = true;
                await Task.Delay(1000);
                Structure = (IHierarchicalStructure)await GetHomeFolderAsync();
                foreach (var c in Structure.Childs)
                    Structures.Add(c);

                CurrentPath = GetCurrentPath();
            }
            catch
            {

            }
            finally
            {
                IsLoading = false;
            }
        }

        

        private async Task<BaseStructure> GetStructureAsync(string id)
        {
            return await Task.Run<BaseStructure>(() => { return _archiveRepository.GetStructure(id); });
        }

        private async Task<BaseStructure> GetHomeFolderAsync()
        {
            return await Task.Run<BaseStructure>(() => { return _archiveRepository.GetHomeFolder(); });
        }

        private async void OnItemTapped()
        {
            try
            {
                if (CurrentSelectedItem != null)
                {

                    Structures.Clear();
                    
                    IsLoading = true;



                    IHierarchicalStructure structure =null;

                    if (CurrentSelectedItem is EmptyStructure)
                    {
                        structure = ((IHierarchicalStructure)Structure).Parent;
                    }
                    else
                    {
                        await Task.Delay(1000);
                        structure = (IHierarchicalStructure)await GetStructureAsync(CurrentSelectedItem.Id);
                    }

                    if (!Structures.Any(x => x is EmptyStructure) && structure.Parent!=null)
                        Structures.Insert(0, new EmptyStructure(structure));

                    foreach (var c in structure.Childs)
                        Structures.Add(c);

                    Structure = structure;
                    CurrentPath = GetCurrentPath();
                }
            }
            catch
            {

            }
            finally
            {
                IsLoading = false;
            }

        }

        private string GetCurrentPath()
        {
            CurrentPath = String.Empty;
            string path = ((BaseStructure)Structure).DisplayName;
            var s = Structure;
            while (s.Parent!= null)
            {
                path = ((BaseStructure)s.Parent).DisplayName + @"\" + path;
                s = s.Parent;
            }
            return path;
        }

        private void LoadMoreItems()
        {
            
        }

    }

    public class EmptyStructure : BaseStructure,IHierarchicalStructure
    {
        public IList<BaseStructure> Childs { get; set; }
        public IHierarchicalStructure Parent { get; set; }

        public EmptyStructure(IHierarchicalStructure structure)
        {
            DisplayName = @"\...";
            AreDetailsVisible = false;
            this.ImgSource = "back.png";
        }
    }
}
