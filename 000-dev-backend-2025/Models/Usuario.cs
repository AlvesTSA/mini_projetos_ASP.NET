using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _000_dev_backend_2025.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "O perfil é obrigatório!")]
        public PerfilUsuario Perfil { get; set; }

        public enum PerfilUsuario
        {
            Administrador,
            Usuario
        }
    }
}
