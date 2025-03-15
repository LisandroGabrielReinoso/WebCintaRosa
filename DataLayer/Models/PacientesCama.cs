using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class PacientesCama
{
    public int? IdPaciente { get; set; }

    public int? NroCama { get; set; }

    public DateTime? FechaOcupacion { get; set; }

    public DateTime? FechaEgreso { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Cama? NroCamaNavigation { get; set; }
}
