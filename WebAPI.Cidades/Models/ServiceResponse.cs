namespace WebAPI.Cidades.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public bool Success { get; set; } = true;
    }
}
