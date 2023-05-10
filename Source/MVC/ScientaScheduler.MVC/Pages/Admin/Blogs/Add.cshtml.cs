using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScientaScheduler.MVC.Data;
using ScientaScheduler.MVC.Models.Domain;
using ScientaScheduler.MVC.Models.ViewModels;

namespace ScientaScheduler.MVC.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;
        private readonly IMapper mapper;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; } = new();

        public AddModel(BloggieDbContext bloggieDbContext, IMapper mapper)
        {
            this.bloggieDbContext = bloggieDbContext;
            this.mapper = mapper;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            BlogPost post = mapper.Map<AddBlogPost,BlogPost>(AddBlogPostRequest);

            bloggieDbContext.BlogPosts.Add(post);
            bloggieDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");

        }
    }
}
