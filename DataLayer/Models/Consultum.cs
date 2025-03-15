using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Consultum
{
    public int IdConsulta { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdProfesional { get; set; }

    public int? IdServicio { get; set; }

    public DateOnly? FechaConsulta { get; set; }

    public TimeOnly? HoraConsulta { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Antecedente> Antecedentes { get; set; } = new List<Antecedente>();

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Profesionale? IdProfesionalNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }

    public virtual ICollection<SignosVitale> SignosVitales { get; set; } = new List<SignosVitale>();

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
