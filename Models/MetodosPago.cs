using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class MetodosPago
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
