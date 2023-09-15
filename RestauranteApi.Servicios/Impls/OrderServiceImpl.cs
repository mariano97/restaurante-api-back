using System;
using AutoMapper;
using RestauranteApi.Datos.Models;
using RestauranteApi.Domain.Repositories;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios.Impls
{
	public class OrderServiceImpl : IOrderService
    {

        private readonly IRepositoryAsync<Order> _repository;
        private readonly IMapper _mapper;

		public OrderServiceImpl(IRepositoryAsync<Order> repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var lista = await _repository.GetAll();
            return _mapper.Map<IEnumerable<OrderDTO>>(lista);
        }

        public async Task<OrderDTO> Guardar(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order = await _repository.Guardar(order);
            return _mapper.Map<OrderDTO>(order);
        }
    }
}

