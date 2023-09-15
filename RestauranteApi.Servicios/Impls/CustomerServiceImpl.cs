using System;
using AutoMapper;
using RestauranteApi.Datos.Models;
using RestauranteApi.Domain.Repositories;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios.Impls
{
	public class CustomerServiceImpl : ICustomerService
    {

        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerServiceImpl(IRepositoryAsync<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var lista = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(lista);
        }

        public async Task<CustomerDTO> Guardar(CustomerDTO customerDTO)
        {
            var entity = _mapper.Map<Customer>(customerDTO);
            entity = await _repository.Guardar(entity);
            return _mapper.Map<CustomerDTO>(entity);
        }
    }
}

