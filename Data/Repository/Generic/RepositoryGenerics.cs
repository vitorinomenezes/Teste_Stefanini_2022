using Data.Configuration;
using Domain.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;


namespace Data.Repository.Generic
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Configuration.Context> _options;

        public RepositoryGenerics()
        {
            _options = new DbContextOptions<Configuration.Context>();
        }
        public async Task<int> Add(T Objeto)
        {
            using (var data = new Configuration.Context(_options))
            {
                await data.Set<T>().AddAsync(Objeto);
                try
                {
                    return await data.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        public async Task<int> Delete(T Objeto)
        {
            using (var data = new Configuration.Context(_options))
            {
                object p = data.Set<T>().Remove(Objeto);
                return await data.SaveChangesAsync();
            }
        }

        public async Task<int> Update(T Objeto)
        {
            using (var data = new Configuration.Context(_options))
            {
                try
                {
                    data.Set<T>().Update(Objeto);
                    return await data.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }


        
        public async Task<List<T>> GetAll()
        {
            using (var data = new Configuration.Context(_options))
            {
                try
                {
                    return await EntityFrameworkQueryableExtensions.AsNoTracking<T>(data.Set<T>()).ToListAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new Configuration.Context(_options))
            {
                return await data.Set<T>().FindAsync((object)id);
            }
        }


        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }

        public Task<int> Save( T model)
        {
            throw new NotImplementedException();
        }
    }
}
