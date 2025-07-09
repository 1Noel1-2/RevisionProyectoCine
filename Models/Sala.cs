using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Sala
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public int? Capacidad { get; set; }

    public int? IdSucursal { get; set; }

    public string Estado { get; set; } = "Activa";

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();

    public virtual Sucursale? IdSucursalNavigation { get; set; }
}
