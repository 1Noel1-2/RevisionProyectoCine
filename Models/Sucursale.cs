using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Sucursale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
