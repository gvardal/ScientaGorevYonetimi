using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Library.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IScientaRestService scientaRestService;

        public ProjectsController(IScientaRestService scientaRestService)
        {
            this.scientaRestService = scientaRestService;
        }

        [HttpPost]
        [Route("AktifProjeListesi")]
        public async Task<IActionResult> AktifProjeListesi([FromBody] ScieantaRestDTO restDTO)
        {
            var result = await scientaRestService.ProjectList(restDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
