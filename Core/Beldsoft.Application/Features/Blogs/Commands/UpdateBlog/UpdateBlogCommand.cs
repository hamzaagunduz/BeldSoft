using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<CommonResponse<bool>>
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
