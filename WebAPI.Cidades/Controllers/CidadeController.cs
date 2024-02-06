using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Cidades.Models;
using WebAPI.Cidades.Service.CidadeService;

namespace WebAPI.Cidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeInterface _cidadeInterface;
        public CidadeController(ICidadeInterface cidadeInterface)
        {
            _cidadeInterface = cidadeInterface;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CidadeModel>>> GetCidadeById(int id)
        {
            ServiceResponse<CidadeModel> serviceResponse = await _cidadeInterface.GetCidadeById(id);

            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CidadeModel>>>> GetCidades()
        {
            return Ok(await _cidadeInterface.GetCidades());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CidadeModel>>>> CreateCidade(CidadeModel novaCidade)
        {
            return Ok(await _cidadeInterface.CreateCidade(novaCidade));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CidadeModel>>>> UpdateCidade(CidadeModel alteraCidade)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = await _cidadeInterface.UpdateCidade(alteraCidade);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<CidadeModel>>>> DeleteCidade(int id)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = await _cidadeInterface.DeleteCidade(id);
            return Ok(serviceResponse);
        }

        /*[HttpPut("{inativaCidade}")]
        public async Task<ActionResult<ServiceResponse<List<CidadeModel>>>> InativaCidade(int id)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = await _cidadeInterface.InativaCidade(id);
            return Ok(serviceResponse);
        }*/
    }
}
