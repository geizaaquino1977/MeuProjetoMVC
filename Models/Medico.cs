using System.ComponentModel.DataAnnotations;

namespace Uc_4_Antonia_Clinica.Models
{
    public class Medico
    {


        public int MedicoId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Especialidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        public string CRM{ get; set; } = string.Empty;

        // Relacionamento
        public ICollection<Consulta>? Consultas { get; set; }

    }
}
