using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public partial class DocumentSearchView : ContentPage
    {
        public DocumentSearchView()
        {
            InitializeComponent();
        }
    }

    public class Document :INotifyPropertyChanged
    {
        private bool _isFavorite;
        public bool IsFavorite 
        {
            get { return _isFavorite; }
            set
            {
                if (value != _isFavorite)
                {
                    _isFavorite = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DisplayName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
