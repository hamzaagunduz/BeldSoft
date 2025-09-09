using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, CommonResponse<bool>>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<CommonResponse<bool>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
     
                var blog = await _blogRepository.GetByIdAsync(request.BlogId);

                if (blog == null)
                    return CommonResponse<bool>.Fail(new[] { "Blog bulunamadı." });

                blog.Title = request.Title;
                blog.Content = request.Content;
                blog.UpdatedAt = DateTime.UtcNow;

                await _blogRepository.UpdateAsync(blog);

                return CommonResponse<bool>.Success(true); // Başarı durumu
       
        }
    }
}
