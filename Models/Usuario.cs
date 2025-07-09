using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? ContrasenaHash { get; set; }

    public string Rol { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}