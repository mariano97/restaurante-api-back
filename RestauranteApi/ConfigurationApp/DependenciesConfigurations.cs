using System;
using Microsoft.EntityFrameworkCore;
using RestauranteApi.Datos.Models;
using AutoMapper;
using RestauranteApi.Servicios.Mappers.Profiles;
using RestauranteApi.Domain.Repositories;
using RestauranteApi.Domain.Repositories.Impl;
using RestauranteApi.Servicios.Impls;
using RestauranteApi.Servicios;

namespace RestauranteApi.ConfigurationApp
{
	public static class DependenciesConfigurations
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{

			var dataBaseConnection = configuration.GetConnectionString("MySqlConnection");
			services.AddDbContext<DataBaseContext>(opt =>
			{
				opt.UseMySql(dataBaseConnection, ServerVersion.AutoDetect(dataBaseConnection));
			});


			services.AddScoped<IRepositoryAsync<Customer>, RepositoryAsyncImpl<Customer>>();
            services.AddScoped<IRepositoryAsync<Order>, RepositoryAsyncImpl<Order>>();

			services.AddScoped<ICustomerService, CustomerServiceImpl>();
			services.AddScoped<IOrderService, OrderServiceImpl>();


            services.AddAutoMapper(typeof(OrderProfile));
            services.AddAutoMapper(typeof(CustomerProfile));

            return services;
		}
	}
}

