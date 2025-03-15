using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Profesionale
{
    public int IdProfesional { get; set; }

    public string? NombreProfesional { get; set; }

    public string? ApellidoProfesional { get; set; }

    public long? Dni { get; set; }

    public long? Telefono { get; set; }

    public string? Email { get; set; }

    public int? IdRoles { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Role? IdRolesNavigation { get; set; }
}
