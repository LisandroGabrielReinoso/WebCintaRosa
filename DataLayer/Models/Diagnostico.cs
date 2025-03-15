using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Diagnostico
{
    public int IdDiagnostico { get; set; }

    public int? IdConsulta { get; set; }

    public string? Descripcion { get; set; }

    public virtual Consultum? IdConsultaNavigation { get; set; }
}
