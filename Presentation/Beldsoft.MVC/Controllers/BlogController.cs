using AutoMapper;
using Beldsoft.Application.Features.Blogs.Commands.CreateBlog;
using Beldsoft.Application.Features.Blogs.Commands.DeleteBlog;
using Beldsoft.Application.Features.Blogs.Commands.UpdateBlog;
using Beldsoft.Application.Features.Blogs.Queries.GetAllBlogs;
using Beldsoft.Application.Features.Blogs.Queries.GetBlogById;
using Beldsoft.MVC.ViewModels.Blog;
using Beldsoft.MVC.ViewModels.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Beldsoft.MVC.Controllers
{
    [Route("blogs")] // Controller bazlı route ekledik
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // Blog listesi
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            // Query çalıştırılıyor
            var response = await _mediator.Send(new GetAllBlogsQuery());
            Console.WriteLine("Result JSON: " + JsonSerializer.Serialize(response));

            if (response.Succeeded)
            {
                var model = _mapper.Map<List<BlogListViewModel>>(response.Data);
                return View(model);
            }
            else
            {
                // Hata varsa mesajları ViewBag veya TempData ile gönderebilirsin
                ViewBag.Errors = response.Errors;
                return View(new List<BlogListViewModel>()); // boş liste dön
            }
        }


        // Blog detay
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _mediator.Send(new GetBlogByIdQuery { BlogId = id });
            var model = _mapper.Map<BlogEditViewModel>(blog);
            return View(model);
        }

        // Yeni blog sayfası
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BlogCreateViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            var command = _mapper.Map<CreateBlogCommand>(model);
            var result =await _mediator.Send(command);
            Console.WriteLine("Result JSON: " + JsonSerializer.Serialize(result));
            return RedirectToAction(nameof(Index));
        }

        // Blog güncelle
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _mediator.Send(new GetBlogByIdQuery { BlogId = id });
            var model = _mapper.Map<BlogEditViewModel>(blog);
            return View(model);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(BlogEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = _mapper.Map<UpdateBlogCommand>(model);
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        // Blog sil
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogCommand { BlogId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
