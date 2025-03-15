using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class EspecialidadxProfesional
{
    public int? IdProfesional { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }

    public virtual Profesionale? IdProfesionalNavigation { get; set; }
}
