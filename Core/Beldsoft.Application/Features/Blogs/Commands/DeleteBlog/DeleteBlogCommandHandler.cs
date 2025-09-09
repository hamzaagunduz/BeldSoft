using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, CommonResponse<bool>>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var blog = await _blogRepository.GetByIdAsync(request.BlogId);

                if (blog == null)
                    return CommonResponse<bool>.Fail(new[] { "Blog bulunamadı." });

                await _blogRepository.RemoveAsync(blog);

                return CommonResponse<bool>.Success(true); // Başarı durumunu dön
            }
            catch (Exception ex)
            {
                return CommonResponse<bool>.Fail(new[] { $"Blog silinirken hata oluştu: {ex.Message}" });
            }
        }
    }
}
