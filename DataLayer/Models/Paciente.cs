using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public long? Dni { get; set; }

    public string? Domicilio { get; set; }

    public int? IdLocalidad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public long? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Localidad? IdLocalidadNavigation { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
