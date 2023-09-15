using System;
namespace RestauranteApi.Servicios.Mappers.Dtos
{
	public class OrderDTO
    {
        public int Idorder { get; set; }

        public string NumeroOrder { get; set; } = null!;

        public string ProductoName { get; set; } = null!;

        public int CustomerId { get; set; }
    }
}

