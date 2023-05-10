using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Data;
using ScientaScheduler.MVC.Models.Domain;
using ScientaScheduler.MVC.Models.ViewModels;

namespace ScientaScheduler.MVC.Pages.WorkManagement.WorkOrder
{
    public class WorkOrderListModel : PageModel
    {
        private readonly ScientaDbContext scientaDb;
        private readonly IMapper mapper;

        public WorkOrderListModel(ScientaDbContext scientaDb, IMapper mapper)
        {
            this.scientaDb = scientaDb;
            this.mapper = mapper;
        }

        public List<UYIsEmriDTO> orderDto { get; set; } = new();

        public async Task OnGet()
        {
            var orders = await scientaDb.UYIsEmri.Take(100).ToListAsync();
            orderDto = mapper.Map<List<UYIsEmri>, List<UYIsEmriDTO>>(orders);
        }
    }
}
