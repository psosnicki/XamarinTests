using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXam
{
     public class InfiniteListView : ListView
     {
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create<InfiniteListView, ICommand>(bp => bp.LoadMoreCommand, default(ICommand));
        public static readonly BindableProperty ItemTappedCommandProperty = BindableProperty.Create<InfiniteListView, ICommand>(bp => bp.ItemTappedCommand, default(ICommand));
 
        public ICommand LoadMoreCommand
        {
            get { return (ICommand) GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }
 
        public InfiniteListView()
        {
            ItemAppearing += InfiniteListView_ItemAppearing;
            //ItemTapped +=InfiniteListView_ItemTapped;
        }

        private void InfiniteListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
             if (e.Item != null && ItemTappedCommand != null && ItemTappedCommand.CanExecute(e.Item))
                    ItemTappedCommand.Execute(e.Item);
        }
 
        void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;
 
            if (items != null && e.Item == items[items.Count - 1])
            {
                if(LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    LoadMoreCommand.Execute(null);
            }
        }
     }
}
