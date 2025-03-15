using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Localidad
{
    public int IdLocalidad { get; set; }

    public string? NombreLocalidad { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
