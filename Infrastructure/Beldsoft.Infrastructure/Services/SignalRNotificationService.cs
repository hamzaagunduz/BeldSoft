using Beldsoft.Application.Interfaces.INotificationService;
using Beldsoft.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Infrastructure.Services
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<ChildHub> _hubContext;

        public SignalRNotificationService(IHubContext<ChildHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyChildExpiredAsync(int childId, string childName)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveChildExpired", childId, childName);
        }
    }
}
