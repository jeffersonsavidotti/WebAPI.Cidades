using System.ComponentModel.DataAnnotations;

namespace WebAPI.Cidades.Models
{
    public class CidadeModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Estado { get; set;}

    }
}
