using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int? ReservaId { get; set; }

    public int? MetodoPagoId { get; set; }

    public string? Detalle { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public string? Referencia { get; set; }

    public virtual MetodosPago? MetodoPago { get; set; }

    public virtual Reserva? Reserva { get; set; }
}
