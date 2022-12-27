using System;
using System.Threading.Tasks;

namespace IQHotel.Helper
{
    public interface ILoggerRepository
    {
        public void Write(Exception exception, string message);
        public Task WriteAsync(Exception exception, string message);
    }
}
