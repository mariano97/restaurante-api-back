using System;
using AutoMapper;
using RestauranteApi.Datos.Models;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios.Mappers.Profiles
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

        }
	}
}

