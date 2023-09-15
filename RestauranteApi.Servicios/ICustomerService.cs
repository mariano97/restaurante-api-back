using System;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios
{
	public interface ICustomerService
	{
		Task<CustomerDTO> Guardar(CustomerDTO customerDTO);
		Task<IEnumerable<CustomerDTO>> GetAll();
    }
}

