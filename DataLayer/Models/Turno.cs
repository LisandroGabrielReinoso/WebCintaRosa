using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Turno
{
    public int IdTurnos { get; set; }

    public string? TipoDeConsulta { get; set; }

    public DateOnly? FechaTurno { get; set; }

    public bool EsPacienteRegistrado { get; set; }

    public string? DatosPacienteNoRegistrado { get; set; }

    public int? IdPaciente { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
