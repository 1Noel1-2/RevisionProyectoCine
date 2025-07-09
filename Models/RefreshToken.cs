using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? Token { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public bool? Valido { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
