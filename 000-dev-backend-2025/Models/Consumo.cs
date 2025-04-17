using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _000_dev_backend_2025.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data de consumo é obrigatória!")]
        [Display(Name = "Data de consumo")]
        public DateTime DataConsumo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor total é obrigatório!")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "A quilometragem é obrigatória!")]
        public int Km { get; set; }

        [Display(Name = "Tipo de combustível")]
        public TipoCombustivel Tipo { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "O veículo é obrigatório!")]
        public int IdVeiculo { get; set; }

        [ForeignKey("IdVeiculo")]
        public Veiculo Veiculo { get; set; }

        public enum TipoCombustivel
        {
            Gasolina,
            Etanol, 
        }
    }
}
