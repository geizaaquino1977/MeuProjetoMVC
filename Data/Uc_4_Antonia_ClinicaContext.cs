using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uc_4_Antonia_Clinica.Models;

namespace Uc_4_Antonia_Clinica.Data
{
    public class Uc_4_Antonia_ClinicaContext : DbContext
    {
        public Uc_4_Antonia_ClinicaContext (DbContextOptions<Uc_4_Antonia_ClinicaContext> options)
            : base(options)
        {
        }

        public DbSet<Uc_4_Antonia_Clinica.Models.Consulta> Consulta { get; set; } = default!;
        public DbSet<Uc_4_Antonia_Clinica.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Uc_4_Antonia_Clinica.Models.Medico> Medico { get; set; } = default!;
        public DbSet<Uc_4_Antonia_Clinica.Models.Paciente> Paciente { get; set; } = default!;
    }
}
