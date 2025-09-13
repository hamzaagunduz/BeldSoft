using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Interfaces.IChildExpirationService
{
    public interface IChildExpirationService
    {
        Task CheckAndMarkExpiredAsync(CancellationToken cancellationToken = default);
    }
}
