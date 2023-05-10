using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScientaScheduler.MVC.Data;
using ScientaScheduler.MVC.Models.Domain;

namespace ScientaScheduler.MVC.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public List<BlogPost> BlogPosts = new();

        public ListModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public void OnGet()
        {
            ViewData["mesaj1"] = "ViewData mesajý";

            TempData["mesaj3"] = "TempData Mesaj";

            BlogPosts = bloggieDbContext.BlogPosts.ToList();
        }
    }
}
