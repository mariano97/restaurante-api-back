using System;
using System.Collections.Generic;

namespace RestauranteApi.Datos.Models;

public partial class Order
{
    public int Idorder { get; set; }

    public string NumeroOrder { get; set; } = null!;

    public string ProductoName { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
