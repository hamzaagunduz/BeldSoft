using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Interfaces.INotificationService
{
    public interface INotificationService
    {
        Task NotifyChildExpiredAsync(int childId, string childName);
    }
}
