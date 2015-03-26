using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class BaseStructure : INotifyPropertyChanged
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
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string LastModified { get { return ModifiedDate.ToString(); } }
        public DateTime ModifiedDate { get; set; }
        public string Extension { get; set; }

        public string ImgSource { get; set; }

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
