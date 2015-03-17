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
    public class DocumentSearchViewModel
    {
        public IList<Document> FoundDocuments { get; set; }
        public ObservableCollection<Suggestion> Suggestions { get; set; }

        public ICommand AddFavoriteCmd { get; set; }
        public DocumentSearchViewModel()
        {
            FoundDocuments = new List<Document>() {  
                new Document{ DisplayName = "Display 1 name"},
                new Document{ DisplayName = "Display 2 name" , IsFavorite = true}
            };

            Suggestions = new ObservableCollection<Suggestion>();
            this.AddFavoriteCmd = new Command<Document>((a) => { 

            });
        }
    }
}
