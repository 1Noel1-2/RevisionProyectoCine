using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class TiposBoleto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    public virtual ICollection<PreciosFuncion> PreciosFuncions { get; set; } = new List<PreciosFuncion>();
}
