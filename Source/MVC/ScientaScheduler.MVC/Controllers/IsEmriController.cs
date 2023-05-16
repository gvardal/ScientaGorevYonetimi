using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Library;
using ScientaScheduler.MVC.Library.Dtos;
using ScientaScheduler.MVC.Library.Models;

namespace ScientaScheduler.MVC.Controllers
{
    public class IsEmriController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public IsEmriController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            List<UYIsEmriDto> isEmriDtoList = new();

            isEmriDtoList = await (from isemri in dbContext.UYIsEmri
                          join durum in dbContext.P_UYIsEmriDurumu on isemri.IsEmriDurumId equals durum.IsEmriDurumID
                          where (isemri.IsEmriDurumId !=  7 && isemri.IsEmriDurumId != 8) 
                          select new UYIsEmriDto
                          {
                              IsEmriID = (long)isemri.IsEmriId!,
                              IsEmriKodu = isemri.IsEmriKodu!,
                              IsEmriDurum = durum.Durum.Replace("Açık-",""),
                              UretimMiktari = isemri.UretimMiktari,
                              BaslangicTarihi = isemri.BaslangicTarihi,
                              BitisTarihi = isemri.BitisTarihi
                          }).OrderBy(o=> o.BaslangicTarihi).ToListAsync();

            ViewBag.IsEmri = isEmriDtoList;

            return View();
        }
    }
}
