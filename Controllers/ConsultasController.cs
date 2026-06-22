using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uc_4_Antonia_Clinica.Data;
using Uc_4_Antonia_Clinica.Models;

namespace Uc_4_Antonia_Clinica.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Uc_4_Antonia_ClinicaContext _context;

        public ConsultasController(Uc_4_Antonia_ClinicaContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var uc_4_Antonia_ClinicaContext = _context.Consulta.Include(c => c.Funcionario).Include(c => c.Medico).Include(c => c.Paciente);
            return View(await uc_4_Antonia_ClinicaContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Funcionario)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Set<Funcionario>(), "FuncionarioId", "Nome");
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Email");
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Email");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultaId,DataConsulta,Valor_Consulta,PacienteId,MedicoId,FuncionarioId")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Set<Funcionario>(), "FuncionarioId", "Nome", consulta.FuncionarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Email", consulta.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Email", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Set<Funcionario>(), "FuncionarioId", "Nome", consulta.FuncionarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Email", consulta.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Email", consulta.PacienteId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultaId,DataConsulta,Valor_Consulta,PacienteId,MedicoId,FuncionarioId")] Consulta consulta)
        {
            if (id != consulta.ConsultaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.ConsultaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Set<Funcionario>(), "FuncionarioId", "Nome", consulta.FuncionarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Email", consulta.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Email", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Funcionario)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consulta.Any(e => e.ConsultaId == id);
        }


        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var consultas = _context.Consulta
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                consultas = consultas.Where(c =>
                    (c.Paciente != null && c.Paciente.Nome.Contains(searchString)) ||
                    (c.Medico != null && c.Medico.Nome.Contains(searchString))
                );
            }

            return View(await consultas.ToListAsync());
        }


    }
}

