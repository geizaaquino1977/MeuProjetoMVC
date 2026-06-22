using System.ComponentModel.DataAnnotations;

namespace Uc_4_Antonia_Clinica.Models
{
    public class Paciente
    {


        public int PacienteId { get; set; }

        
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        public DateTime Data_Nascimento { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Telefone { get; set; } = string.Empty;

        

        // Relacionamento
        public ICollection<Consulta>? Consultas { get; set; }

    }
}
