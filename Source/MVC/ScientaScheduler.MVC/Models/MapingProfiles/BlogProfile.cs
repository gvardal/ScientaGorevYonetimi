using AutoMapper;
using ScientaScheduler.MVC.Models.Domain;
using ScientaScheduler.MVC.Models.ViewModels;

namespace ScientaScheduler.MVC.Models.MapingProfiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogPost, AddBlogPost>().ReverseMap();
        }
    }
}
