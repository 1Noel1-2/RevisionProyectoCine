using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class MensajesContacto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? Fecha { get; set; }
}
