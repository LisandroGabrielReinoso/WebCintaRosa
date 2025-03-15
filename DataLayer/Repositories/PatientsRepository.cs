using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly DataCintaRosa1Context context;
        public PatientsRepository(DataCintaRosa1Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAllPatientsAsync()
        {
            return await context.Pacientes
                .Include(P => P.Consulta)
                    .ThenInclude(C=>C.Diagnosticos)
                .Include(P=>P.Consulta)
                    .ThenInclude(C=>C.Antecedentes)
                .Include(P=>P.Consulta)
                    .ThenInclude(C=>C.Tratamientos)
                .Include(P=>P.Consulta)
                    .ThenInclude(C=>C.SignosVitales)
                .Include(P => P.Turnos)
                .ToListAsync();
        }
        public async Task<Paciente> GetOnePatientAsync(int id)
        {
            return await context.Pacientes
                .Include(P => P.Consulta)
                    .ThenInclude(C => C.Diagnosticos)
                .Include(P => P.Consulta)
                    .ThenInclude(C => C.Antecedentes)
                .Include(P => P.Consulta)
                    .ThenInclude(C => C.Tratamientos)
                .Include(P => P.Consulta)
                    .ThenInclude(C => C.SignosVitales)
                .Include(P => P.Turnos)
                .Where(P => P.IdPaciente == id)
                .FirstOrDefaultAsync();
        }
        public async Task CreatePatienteAsync(Paciente patient)
        {
            await context.Pacientes.AddAsync(patient);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePatientAsync(Paciente patient)
        {
            context.Pacientes.Update(patient);
            await context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await GetOnePatientAsync(id);
            if (patient == null)
            {
                // Manejá el error: quizás lanzá una excepción o devolvé un mensaje adecuado
                throw new Exception("No se encontró el paciente con el id especificado.");
            }

            context.Pacientes.Remove(patient);
            await context.SaveChangesAsync();
        }

    }
}
