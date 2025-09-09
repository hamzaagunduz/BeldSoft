using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, CommonResponse<IEnumerable<GetBlogAllResult>>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<CommonResponse<IEnumerable<GetBlogAllResult>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllAsync();
            throw new System.Exception("Bu bir test hatasıdır!");

            var result = blogs.Select(blog => new GetBlogAllResult
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt
            });

            return CommonResponse<IEnumerable<GetBlogAllResult>>.Success(result);
        }
    }
}
