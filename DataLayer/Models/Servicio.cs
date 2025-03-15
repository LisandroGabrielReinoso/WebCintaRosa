using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Servicio
{
    public int IdServicios { get; set; }

    public string? NombreServicio { get; set; }

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual Sala? Sala { get; set; }
}
