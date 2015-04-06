using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class IndexesView : ContentPage
    {
        public IndexesView()
        {
            InitializeComponent();
            lstIndexes.ItemsSource = new List<IndexField>
            {
                new IndexField{ Required = false, Type = IndexType.STRING, DisplayName = "Some index1" },
                new IndexField{ Required = true, Type = IndexType.INTEGER, DisplayName = "Some index2" },
                new IndexField{ Required = false, Type = IndexType.DATETIME, DisplayName = "Some index3" }
            
            };
        }
    }
}
