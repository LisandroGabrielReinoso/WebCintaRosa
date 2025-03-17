using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IHospitalRepository 
    {
        Task<IEnumerable<Servicio>> GetServiciosRelationsAsync();
        Task<Servicio> GetServicioByIdRelationsAsync(int id);
        Task<IEnumerable<PacientesCama>> GetPacientesCamasRelationsAsync();
        Task<PacientesCama> GetPacientesCamaByIdRelationsAsync(int id);
        Task<IEnumerable<EspecialidadxProfesional>> GetProfesionalRelationsAsync();
        Task<EspecialidadxProfesional> GetProfisionalByIdRelationsAsync(int id);

    }
}
