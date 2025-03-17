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
    public class HospitalRepository : IHospitalRepository
    {
        private readonly DataCintaRosa1Context context;
        public HospitalRepository(DataCintaRosa1Context context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Servicio>> GetServiciosRelationsAsync()
        {
            return await context.Servicios
                .Include(S => S.Sala)
                    .ThenInclude(SA => SA.Camas)
                   .ToListAsync();
                
        }

        public async Task<Servicio> GetServicioByIdRelationsAsync(int id)
        {
            return await context.Servicios
                .Include(S => S.Sala)
                    .ThenInclude(SA => SA.Camas)
                .Where(S => S.IdServicios == id)
                .FirstOrDefaultAsync();

               
        }

        public async Task<IEnumerable<PacientesCama>> GetPacientesCamasRelationsAsync()
        {
            return await context.PacientesCamas
                .Include(PC => PC.IdPacienteNavigation)
                    .ThenInclude(P => P.IdLocalidadNavigation)
                .Include(PC => PC.NroCamaNavigation)
                    .ThenInclude(C => C.IdSalasNavigation)
                .ToListAsync();
        }

        public async Task<PacientesCama> GetPacientesCamaByIdRelationsAsync(int id)
        {
            return await context.PacientesCamas
               .Include(PC => PC.IdPacienteNavigation)
                   .ThenInclude(P => P.IdLocalidadNavigation)
               .Include(PC => PC.NroCamaNavigation)
                   .ThenInclude(C => C.IdSalasNavigation)
                .Where(PC => PC.IdPaciente == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EspecialidadxProfesional>> GetProfesionalRelationsAsync()
        {
            return await context.EspecialidadxProfesionals
                .Include(EP => EP.IdEspecialidadNavigation)
                .Include(EP => EP.IdProfesionalNavigation)
                    .ThenInclude(P => P.IdRolesNavigation)
                .ToListAsync();
        }
        public async Task<EspecialidadxProfesional> GetProfisionalByIdRelationsAsync(int id)
        {
            return await context.EspecialidadxProfesionals
                .Include(EP => EP.IdEspecialidadNavigation)
                .Include(EP => EP.IdProfesionalNavigation)
                    .ThenInclude(P => P.IdRolesNavigation)
                .Where(EP => EP.IdProfesional == id)
                .FirstOrDefaultAsync();
        }
    }
}
