using System;
using Microsoft.EntityFrameworkCore;
using RestauranteApi.Datos.Models;

namespace RestauranteApi.Domain.Repositories.Impl
{
	public class RepositoryAsyncImpl<T> : IRepositoryAsync<T> where T : class
    {

        protected readonly DataBaseContext _dataBaseContext;
        private bool dispose = false;

        public RepositoryAsyncImpl(DataBaseContext dataBaseContext)
		{
            _dataBaseContext = dataBaseContext;
		}

        protected DbSet<T> EntitySet
        {
            get
            {
                return _dataBaseContext.Set<T>();
            }
        }

        private void Dispose(bool isDiposing)
        {
            if (!dispose && isDiposing)
            {
                _dataBaseContext.Dispose();
            }
            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> Guardar(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        protected async Task<int> Save()
        {
            return await _dataBaseContext.SaveChangesAsync();
        }
    }
}

