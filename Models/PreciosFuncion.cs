using System;
using System.Collections.Generic;

namespace Proyecto_Cine.Models;

public partial class PreciosFuncion
{
    public int FuncionId { get; set; }

    public int TipoBoletoId { get; set; }

    public decimal? Precio { get; set; }

    public virtual Funcione Funcion { get; set; } = null!;

    public virtual TiposBoleto TipoBoleto { get; set; } = null!;
}
