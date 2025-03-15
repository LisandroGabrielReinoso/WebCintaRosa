using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class SignosVitale
{
    public int IdSigno { get; set; }

    public int? IdConsulta { get; set; }

    public decimal? Sistolica { get; set; }

    public decimal? Diastolica { get; set; }

    public decimal? Peso { get; set; }

    public decimal? FrecuenciaCardiaca { get; set; }

    public decimal? FrecuenciaRespiratoria { get; set; }

    public decimal? Diuresis { get; set; }

    public virtual Consultum? IdConsultaNavigation { get; set; }
}
