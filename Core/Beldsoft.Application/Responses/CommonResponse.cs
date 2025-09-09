using System.Collections.Generic;
using System.Linq;

namespace Beldsoft.Application.Responses
{
    public class CommonResponse<T>
    {
        public bool Succeeded { get; private set; }
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = new();

        public CommonResponse() { }

        // Başarılı response
        public static CommonResponse<T> Success(T data)
        {
            return new CommonResponse<T>
            {
                Succeeded = true,
                Data = data
            };
        }

        // Başarısız response
        public static CommonResponse<T> Fail(IEnumerable<string> errors)
        {
            return new CommonResponse<T>
            {
                Succeeded = false,
                Errors = errors.ToList()
            };
        }
    }
}
