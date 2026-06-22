using System.ComponentModel.DataAnnotations;

namespace Uc_4_Antonia_Clinica.Models
{
    public class Funcionario
    {


        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        // Relacionamento
        public ICollection<Consulta>? Consultas { get; set; }

    }
}
