using Api_GetData.ViewModel;
using DTO.GetData;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helper.CommonModel;
using Service_layer.Interface;

namespace Api_GetData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        public readonly IGetData _getData;
        public GetDataController(IGetData getData)
        {
            _getData = getData;
        }

        [HttpGet]
       
        public async Task<CommomResponse> GetAll()
        {
            CommomResponse response = new CommomResponse();
            try
            {
                response = await _getData.GetAll();
            }
            catch { throw; }
            return response;
        }

    }
}
