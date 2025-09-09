using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, CommonResponse<GetBlogByIdResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<CommonResponse<GetBlogByIdResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {

                var blog = await _blogRepository.GetByIdAsync(request.BlogId);

                if (blog == null)
                    return CommonResponse<GetBlogByIdResult>.Fail(new[] { "Blog bulunamadı." });

                var result = new GetBlogByIdResult
                {
                    BlogId = blog.BlogId,
                    Title = blog.Title,
                    Content = blog.Content,
                    CreatedAt = blog.CreatedAt,
                    UpdatedAt = blog.UpdatedAt
                };

                return CommonResponse<GetBlogByIdResult>.Success(result);
      
        }
    }
}
