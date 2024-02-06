using Microsoft.EntityFrameworkCore;
using WebAPI.Cidades.DataContext;
using WebAPI.Cidades.Models;

namespace WebAPI.Cidades.Service.CidadeService
{
    public class CidadeService : ICidadeInterface
    {
        private readonly ApplicationDbContext _context;
        public CidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CidadeModel>>> DeleteCidade(int id)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = new ServiceResponse<List<CidadeModel>>();

            try
            {
                CidadeModel cidade = _context.Cidades.FirstOrDefault(x => x.Id == id);
                
                if (cidade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cidade não localizada!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cidades.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CidadeModel>>> CreateCidade(CidadeModel novaCidade)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = new ServiceResponse<List<CidadeModel>>();
            try
            {
                if (novaCidade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }
                _context.Add(novaCidade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cidades.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CidadeModel>> GetCidadeById(int id)
        {
            ServiceResponse<CidadeModel> serviceResponse = new ServiceResponse<CidadeModel>();
            try
            {
                CidadeModel cidade = _context.Cidades.FirstOrDefault(s => s.Id == id);

                if (cidade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cidade não localizada!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Dados = cidade;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CidadeModel>>> GetCidades()
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = new ServiceResponse<List<CidadeModel>>();
            try
            {
                serviceResponse.Dados = _context.Cidades.ToList();
                if(serviceResponse.Dados.Count == 0) 
                {
                    serviceResponse.Mensagem = "Nenhuma dado encontrada!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CidadeModel>>> UpdateCidade(CidadeModel alteraCidade)
        {
            ServiceResponse<List<CidadeModel>> serviceResponse = new ServiceResponse<List<CidadeModel>>();
            try
            {
                CidadeModel cidade = _context.Cidades.AsNoTracking().FirstOrDefault(x => x.Id == alteraCidade.Id);

                if (cidade == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cidade não localizada!";
                    serviceResponse.Success = false;
                }

                _context.Cidades.Update(alteraCidade);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cidades.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }

    /*public async Task<ServiceResponse<List<CidadeModel>>> InativaCidade(int id)
    {
        ServiceResponse<List<CidadeModel>> serviceResponse = new ServiceResponse<List<CidadeModel>>();
        try
        {
            CidadeModel cidade = _context.Cidades.FirstOrDefault(x => x.Id == id);
            if (cidade == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar dados!";
                serviceResponse.Success = false;

                return serviceResponse;
            }
            cidade.Ativo = false;
            _context.Update(cidade);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Cidades.ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Success = false;
        }
        return serviceResponse;
    }
}*/
}
