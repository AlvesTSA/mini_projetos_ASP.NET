using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _000_dev_backend_2025.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name= "Ano do Modelo")]
        public  int AnoModelo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

    }
}
