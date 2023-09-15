using System;
namespace RestauranteApi.Servicios.Mappers.Dtos
{
	public class CustomerDTO
	{
        public int IdCustomer { get; set; }

        public string Nombre { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public int? NumeroCelular { get; set; }
    }
}

