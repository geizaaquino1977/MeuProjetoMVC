namespace Uc_4_Antonia_Clinica.Models
{
    public class Consulta
    {

        public int ConsultaId { get; set; }

        public DateTime DataConsulta { get; set; }

        public Decimal Valor_Consulta { get; set; } 

        // 🔗 FK Paciente
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // 🔗 FK Médico
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        // 🔗 FK Funcionário
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }

    }
}
