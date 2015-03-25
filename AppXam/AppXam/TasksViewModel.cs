using AppXam.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class TasksViewModel : BaseViewModel
    {
        private ITaskRepository _taskRepository;

        public ObservableCollection<EcmTask> Tasks { get; set; }

        public TasksViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            Tasks = new ObservableCollection<EcmTask>();
        }

        private async void LoadTasks()
        {
            try
            {
                Tasks.Clear();
                IsLoading = true;
                var tasks = await GetUserTasks();
                foreach (var t in tasks)
                    Tasks.Add(t);
            }
            catch { }
            finally { IsLoading = false; }
        }

        private async Task<IList<EcmTask>> GetUserTasks()
        {
            await Task.Delay(2000);
            return await Task.Run<IList<EcmTask>>(() => {
                return new List<EcmTask> { new EcmTask{ Name="task1"} };
            });
        }
    }
}
