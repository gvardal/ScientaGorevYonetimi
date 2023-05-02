using ScientaScheduler.Library.DTO;
using ScientaScheduler.Library.Responses;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface IScientaRestService
    {
        Task<ScientaResponse<AktifGorevResponse>> ProjectList(ScieantaRestDTO restDTO);
    }
}
