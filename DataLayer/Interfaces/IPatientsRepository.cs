using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IPatientsRepository
    {
        Task<IEnumerable<Paciente>> GetAllPatientsAsync();
        Task<Paciente> GetOnePatientAsync(int id);
        Task CreatePatienteAsync(Paciente patient);
        Task UpdatePatientAsync(Paciente patient);
        Task DeletePatientAsync(int id);


    }
}
