using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.Application.Responses;
using MediatR;

public class GetAllBlogsQuery : IRequest<CommonResponse<IEnumerable<GetBlogAllResult>>>
{
}