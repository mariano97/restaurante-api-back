using System;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios
{
	public interface IOrderService
	{

		Task<OrderDTO> Guardar(OrderDTO orderDTO);
        Task<IEnumerable<OrderDTO>> GetAll();

    }
}

