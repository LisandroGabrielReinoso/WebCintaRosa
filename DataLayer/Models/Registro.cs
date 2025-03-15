using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Registro
{
    public int IdRegistros { get; set; }

    public string? TablaAfectada { get; set; }

    public int? IdRegistroAfectado { get; set; }

    public string? Rol { get; set; }

    public string? Operacion { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }
}
