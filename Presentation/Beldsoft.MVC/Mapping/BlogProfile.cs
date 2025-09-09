using AutoMapper;
using Beldsoft.Application.Features.Blogs.Commands.CreateBlog;
using Beldsoft.Application.Features.Blogs.Commands.UpdateBlog;
using Beldsoft.Application.Features.Blogs.Results.BlogResults;
using Beldsoft.MVC.ViewModels.Blog;
using Beldsoft.MVC.ViewModels.Blogs;

namespace Beldsoft.MVC.Mapping
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            // Query Results -> ViewModels
            CreateMap<GetBlogAllResult, BlogListViewModel>();
            CreateMap<GetBlogByIdResult, BlogEditViewModel>();

            // ViewModels -> Commands
            CreateMap<BlogCreateViewModel, CreateBlogCommand>();
            CreateMap<BlogEditViewModel, UpdateBlogCommand>();
        }
    }
}
