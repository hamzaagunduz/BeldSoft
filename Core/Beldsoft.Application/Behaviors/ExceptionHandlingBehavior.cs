using MediatR;
using Beldsoft.Application.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : CommonResponse<int> // Farklı response türleri için generic yapısını genişletebilirsin
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var response = typeof(TResponse).GetMethod("Fail")
                    .Invoke(null, new object[] { new[] { $"İşlem sırasında hata oluştu: {ex.Message}" } });

                return (TResponse)response;
            }
        }
    }
}
