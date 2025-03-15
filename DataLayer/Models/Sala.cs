using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Sala
{
    public int IdSalas { get; set; }

    public int? IdServicios { get; set; }

    public string? NombreSala { get; set; }

    public virtual ICollection<Cama> Camas { get; set; } = new List<Cama>();

    public virtual Servicio IdSalasNavigation { get; set; } = null!;
}
