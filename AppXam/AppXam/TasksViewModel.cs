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
            LoadTasks();
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
            await Task.Delay(3000);
            return await Task.Run<IList<EcmTask>>(() => {
                return new List<EcmTask> { 
                    
                    new EcmTask{ TaskName="task1 invoice", WorkflowName="Invoice workflow2", EndDate =DateTime.Now, StartDate = DateTime.Now },
                    new EcmTask{ TaskName="task2 invoice", WorkflowName="Invoice workflow3", EndDate =DateTime.Now.AddDays(1), StartDate = DateTime.Now },
                    new EcmTask{ TaskName="task3 invoice", WorkflowName="Invoice workflow1", EndDate =DateTime.Now.AddDays(3), StartDate = DateTime.Now },
                    new EcmTask{ TaskName="task4 invoice", WorkflowName="Invoice workflow2", EndDate =DateTime.Now.AddDays(2), StartDate = DateTime.Now }
                };
            });
        }
    }
}
