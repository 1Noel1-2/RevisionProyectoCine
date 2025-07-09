using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Asiento
{
    public int Id { get; set; }

    public int? SalaId { get; set; }

    public string? Fila { get; set; }

    public int? Numero { get; set; }

    public virtual Sala? Sala { get; set; }
}
