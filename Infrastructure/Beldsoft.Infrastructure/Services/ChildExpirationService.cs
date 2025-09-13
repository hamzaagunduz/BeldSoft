using Beldsoft.Application.Features.Child.Commands.NotifyParent;
using Beldsoft.Application.Interfaces.IChildExpirationService;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Infrastructure.Services
{
    public class ChildExpirationService : BackgroundService, IChildExpirationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ChildExpirationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckAndMarkExpiredAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        public async Task CheckAndMarkExpiredAsync(CancellationToken cancellationToken = default)
        {

            using var scope = _serviceProvider.CreateScope();

            // Repository üzerinden veri çek
            var childRepo = scope.ServiceProvider.GetRequiredService<IChildRepository>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var now = DateTime.UtcNow;

            var allChildren = await childRepo.GetChildrenForTodayAsync(); // tüm kayıtları al
            var expiredChildren = allChildren
                .Where(c => (c.IsExpired ?? false) == false)
                .Where(c => c.ExpirationTime.HasValue && c.ExpirationTime.Value <= DateTime.Now)
                .ToList();


            foreach (var child in expiredChildren)
            {
                child.IsExpired = true;
                await mediator.Send(new NotifyParentCommand(child.Id, $"{child.FirstName} {child.LastName}"), cancellationToken);
                await childRepo.UpdateAsync(child);
            }

            Console.WriteLine($"{DateTime.Now}: CheckAndMarkExpiredAsync çalıştı. Bulunan süresi dolmuş çocuk sayısı: {expiredChildren.Count}");

        }
    }
}
