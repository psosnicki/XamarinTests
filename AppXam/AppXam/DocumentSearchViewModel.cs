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

        public IList<Document> FoundDocuments { get; set; }
        public ObservableCollection<Suggestion> Suggestions { get; set; }

        public ICommand AddFavoriteCmd { get; set; }
        public ICommand SuggestionSelectedCmd { get; set; }
        public ICommand LoadItemsCmd { get; set; }
        public ICommand ItemSelected { get; set; }

        public DocumentSearchViewModel()
        {
            FoundDocuments = new List<Document>() {  
                new Document{ DisplayName = "Display 1 name"},
                new Document{ DisplayName = "Display 2 name" , IsFavorite = true}
            };

            Suggestions = new ObservableCollection<Suggestion>(GetSuggestions());
            SuggestionSelectedCmd = new Command<Suggestion>(OnSuggestionSelected);
            LoadItemsCmd = new Command(LoadMoreItems);
            ItemSelected = new Command<Document>(OnItemSelected);
        }

        private void OnItemSelected(Document item)
        {
            
        }

        private async void LoadMoreItems()
        {
            _isLoading = true;
            var result = await LoadItemsAsync();
            _isLoading = false;
        }

        private async Task<IList<Document>> LoadItemsAsync()
        {
            await Task.Delay(2000);
            return await Task.Run<IList<Document>>(() => {
                return new List<Document>() { new Document{ DisplayName = "loaded1"}, new Document{DisplayName="Loaded2"} };
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

  
