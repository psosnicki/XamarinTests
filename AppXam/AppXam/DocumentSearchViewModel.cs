using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Platform.Services;

namespace AppXam
{
    public class DocumentSearchViewModel : BaseViewModel
    {
        private bool _isLoading;
        public bool IsLoading 
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Document> FoundDocuments { get; set; }
        public ObservableCollection<Suggestion> Suggestions { get; set; }

        public ICommand AddFavoriteCmd { get; set; }
        public ICommand SuggestionSelectedCmd { get; set; }
        public ICommand LoadItemsCmd { get; set; }
        public ICommand ItemSelectedCmd { get; set; }
        public Document CurrentSelectedItem { get; set; }


        int c = 0;
        private AppNavigationService _navigation;

        public DocumentSearchViewModel(AppNavigationService navigation)
        {
            _navigation = navigation;

            FoundDocuments = new ObservableCollection<Document>();
            for (int i = 0; i < 2000;i++ )
            {
                var doc = new Document { DisplayName = "Display 1 name" + i, ModifiedDate = DateTime.Parse("2014-03-03 17:54"), DocumentClassName = "Invoice",Extension="xlsx" };
                if (i % 2 == 0)
                {
                    doc.Extension = "pdf";
                }
              
                FoundDocuments.Add(doc);
            }

            Suggestions = new ObservableCollection<Suggestion>(GetSuggestions());
            SuggestionSelectedCmd = new Command<Suggestion>(OnSuggestionSelected);
            LoadItemsCmd = new Command(LoadMoreItems);
            ItemSelectedCmd = new Command(OnItemSelected);
        }

        private void OnItemSelected()
        {
            var item = CurrentSelectedItem;
         

        }

        private  async void LoadMoreItems()
        {
                IsLoading = true;
                var result = await LoadItemsAsync();
                //var result = new List<Document>() { new Document { DisplayName = "loaded1" }, new Document { DisplayName = "Loaded2" } }; 
                foreach (var r in result)
                {
                    FoundDocuments.Add(r);
                   // OnPropertyChanged("FoundDocuments");

                }
                IsLoading = false;
        }

        private async Task<IList<Document>> LoadItemsAsync()
        {
          
                await Task.Delay(2000);
                return await Task.Run<IList<Document>>(() =>
                {

                    return new List<Document>() { new Document { DisplayName = c++.ToString() }, new Document { DisplayName = c++.ToString() } };
                });
            
           
        }

        private void OnSuggestionSelected(Suggestion obj)
        {
           
        }

        public IEnumerable<Suggestion> GetSuggestions()
        {
            yield return new Suggestion { Name = "ab" };
            yield return new Suggestion { Name = "abc" };
            yield return new Suggestion { Name = "abcd" };
        }
    }
}

  
