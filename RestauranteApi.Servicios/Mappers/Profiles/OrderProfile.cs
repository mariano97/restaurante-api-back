using System;
using AutoMapper;
using RestauranteApi.Datos.Models;
using RestauranteApi.Servicios.Mappers.Dtos;

namespace RestauranteApi.Servicios.Mappers.Profiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{

			CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

        }
	}
}

