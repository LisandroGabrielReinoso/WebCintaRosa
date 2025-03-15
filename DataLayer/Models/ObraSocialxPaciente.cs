using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class ObraSocialxPaciente
{
    public int IdPaciente { get; set; }

    public int IdObraSocial { get; set; }

    public virtual ObraSocial IdObraSocialNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
