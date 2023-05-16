﻿using AutoMapper;
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
            List<UYIsEmri> isEmriList = new();
            List<UYIsEmriDto> isEmriDtoList = new();

            isEmriList = await dbContext.UYIsEmri
                .Where(x=> x.IsEmriDurumId != 7 && x.IsEmriDurumId != 8)
                //.Take(50).OrderBy(o => o.BaslangicTarihi)
                .ToListAsync();

            isEmriDtoList = mapper.Map<List<UYIsEmri>, List<UYIsEmriDto>>(isEmriList);

            ViewBag.IsEmri = isEmriDtoList;

            return View();
        }
    }
}