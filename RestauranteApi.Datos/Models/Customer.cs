using System;
using System.Collections.Generic;

namespace RestauranteApi.Datos.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public int? NumeroCelular { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
