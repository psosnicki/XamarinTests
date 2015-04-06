using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXam
{
    public class MainMasterViewModel : BaseViewModel
    {
        private ITaskRepository _taskRepository;

        public IList<MenuItem> MenuItems { get; set; }
        public MenuItem CurrentSelectedItem { get; set; }
        public ICommand ItemSelectedCmd { get; set; }

        public MainMasterViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            ItemSelectedCmd = new Command(OnItemSelected);
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new TasksMenuItem { DeadlineTasks = 10, OverdueTasks = 5, NormalTasks =2 ,  ImageSource = ImageCache.GetImageFromFileName("tasknormal.png"), Title ="Tasks" ,TargetType = typeof(TasksView) });
            MenuItems.Add(new MenuItem { ImageSource = ImageCache.GetImageFromFileName("favorites.png"), Title = "Favorites" });
            MenuItems.Add(new MenuItem { ImageSource = ImageCache.GetImageFromFileName("search.png"), Title = "Search" });
        }

        private void OnItemSelected()
        {
            
        }
    }
}
