using System.ComponentModel.DataAnnotations;

namespace StandAutomoveis_1.Models
{
    public class Viatura
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Marca { get; set; }
        public int Ano { get; set; }
        [StringLength(20)]
        public string Loja { get; set; }
    }
}
