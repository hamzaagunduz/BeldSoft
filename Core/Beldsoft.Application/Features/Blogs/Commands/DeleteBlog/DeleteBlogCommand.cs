using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<CommonResponse<bool>>
    {
        public int BlogId { get; set; }
    }
}
