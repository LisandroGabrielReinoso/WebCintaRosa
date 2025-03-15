using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Antecedente
{
    public int IdAntecedentes { get; set; }

    public int? IdConsultas { get; set; }

    public string? APersonales { get; set; }

    public string? AEnfermedad { get; set; }

    public string? AInternaciones { get; set; }

    public string? AMotivoConsulta { get; set; }

    public string? NotasAdicionales { get; set; }

    public virtual Consultum? IdConsultasNavigation { get; set; }
}
