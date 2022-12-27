using System;
using System.Threading.Tasks;

namespace IQHotel.Helper
{
    public interface IBackgroundTaskQueue
    {
        void QueueBackgroundWorkItem(Func<Task> workItem);

        Task<Func<Task>> DequeueAsync();
    }
}
