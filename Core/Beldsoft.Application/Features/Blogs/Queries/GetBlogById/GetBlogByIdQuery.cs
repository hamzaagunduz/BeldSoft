using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<CommonResponse<GetBlogByIdResult>>
    {
        public int BlogId { get; set; }
    }
}
