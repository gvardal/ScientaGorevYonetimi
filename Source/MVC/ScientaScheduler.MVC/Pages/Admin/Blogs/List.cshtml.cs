using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScientaScheduler.MVC.Data;

namespace ScientaScheduler.MVC.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public ListModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public void OnGet()
        {

        }
    }
}
