using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<CommonResponse<int>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
