using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? FuncionId { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public DateTime? FechaReserva { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    public virtual Funcione? Funcion { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }
}
