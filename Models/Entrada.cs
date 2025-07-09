using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Entrada
{
    public int Id { get; set; }

    public int? ReservaId { get; set; }

    public int? TipoBoletoId { get; set; }

    public int? AsientoId { get; set; }
    public virtual Asiento? Asiento { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Reserva? Reserva { get; set; }

    public virtual TiposBoleto? TipoBoleto { get; set; }
}
