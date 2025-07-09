using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class Pelicula
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Genero { get; set; }

    public int? Duracion { get; set; }

    public string? Clasificacion { get; set; }

    public string? Idioma { get; set; }

    public string? Sinopsis { get; set; }

    public string? Imagen { get; set; }

    public bool? Activa { get; set; }

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();
}