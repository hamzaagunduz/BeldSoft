using Beldsoft.Application.Interfaces.INotificationService;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Commands.NotifyParent
{

    public class NotifyParentCommandHandler : IRequestHandler<NotifyParentCommand>
    {
        private readonly INotificationService _notificationService;

        public NotifyParentCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(NotifyParentCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.NotifyChildExpiredAsync(request.ChildId, request.ChildName);
        }
    }
}
