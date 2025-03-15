using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Tratamiento
{
    public int IdTratmientos { get; set; }

    public int? IdConsulta { get; set; }

    public string? Descripcion { get; set; }

    public virtual Consultum? IdConsultaNavigation { get; set; }
}
