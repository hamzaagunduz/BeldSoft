using Beldsoft.Application.Interfaces.IBlogRepository;
using Bedldsoft.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Beldsoft.Application.Responses;

namespace Beldsoft.Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CommonResponse<int>>
    {
        private readonly IBlogRepository _blogRepository;

        public CreateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _blogRepository.AddAsync(blog);

            return CommonResponse<int>.Success(blog.BlogId);
        }
    }
}
