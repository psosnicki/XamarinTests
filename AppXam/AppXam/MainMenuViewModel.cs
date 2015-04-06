using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class MainMenuViewModel : BaseViewModel
    {
        private ITaskRepository _taskRepository;
        public IList<MenuItem> MenuItems { get; set; }

        public MainMenuViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new TasksMenuItem { DeadlineTasks = 10, OverdueTasks = 5, NormalTasks = 2, ImageSource = ImageCache.GetImageFromFileName("tasknormal.png"), Title = "Tasks", TargetType = typeof(TasksView) });
            MenuItems.Add(new MenuItem { ImageSource = ImageCache.GetImageFromFileName("favorites.png"), Title = "Favorites" });
            MenuItems.Add(new MenuItem { ImageSource = ImageCache.GetImageFromFileName("search.png"), Title = "Search" });
        }
    }
}
