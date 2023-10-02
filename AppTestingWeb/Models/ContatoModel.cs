using System.ComponentModel.DataAnnotations;

namespace AppTestingWeb.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato!")]
        [EmailAddress(ErrorMessage = "o email digitado está inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato!")]
        [Phone(ErrorMessage = "O número celular digitado está inválido!")]
        public string Celular { get; set; }
    }
}
