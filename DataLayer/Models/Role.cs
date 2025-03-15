using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Profesionale> Profesionales { get; set; } = new List<Profesionale>();
}
