using System;
namespace RestauranteApi.Domain.Repositories
{
	public interface IRepositoryAsync<T> : IDisposable where T : class
	{

		Task<T> Guardar(T entity);
		Task<IEnumerable<T>> GetAll();

	}
}

