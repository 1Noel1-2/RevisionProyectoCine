using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyecto_Cine.Models
{
    public partial class Funcione
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La película es obligatoria")]
        public int? PeliculaId { get; set; }

        [Required(ErrorMessage = "La sala es obligatoria")]
        public int? SalaId { get; set; }

        public int? SucursalId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateOnly? Fecha { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        public TimeOnly? HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria")]
        public TimeOnly? HoraFin { get; set; }

        [Required(ErrorMessage = "El idioma es obligatorio")]
        public string? Idioma { get; set; }

        [Required(ErrorMessage = "El formato es obligatorio")]
        public string? Formato { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string? Estado { get; set; }

        [ValidateNever]
        public virtual ICollection<AsientosFuncion> AsientosFuncions { get; set; } = new List<AsientosFuncion>();

        [ValidateNever]
        public virtual Pelicula Pelicula { get; set; } = null!;

        [ValidateNever]
        public virtual ICollection<PreciosFuncion> PreciosFuncions { get; set; } = new List<PreciosFuncion>();

        [ValidateNever]
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        [ValidateNever]
        public virtual Sala? Sala { get; set; }

        [ValidateNever]
        public virtual Sucursale? Sucursal { get; set; }
    }
}