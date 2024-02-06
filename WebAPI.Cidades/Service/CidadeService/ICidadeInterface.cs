using WebAPI.Cidades.Models;

namespace WebAPI.Cidades.Service.CidadeService
{
    public interface ICidadeInterface
    {
        Task<ServiceResponse<List<CidadeModel>>> GetCidades();
        Task<ServiceResponse<List<CidadeModel>>> CreateCidade(CidadeModel novaCidade);
        Task<ServiceResponse<CidadeModel>> GetCidadeById(int id);
        Task<ServiceResponse<List<CidadeModel>>> UpdateCidade(CidadeModel alteraCidade);
        Task<ServiceResponse<List<CidadeModel>>> DeleteCidade(int id);
        //Task<ServiceResponse<List<CidadeModel>>> InativaCidade(int id);
    }
}
