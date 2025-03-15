using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Cama
{
    public int NroCama { get; set; }

    public int? IdSalas { get; set; }

    public virtual Sala? IdSalasNavigation { get; set; }
}
