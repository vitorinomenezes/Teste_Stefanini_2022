using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Generic
{
    public interface INterfaceGenericApp<T> where T : class
    {
        Task<int> Add(T Objeto);
        Task<int> Update(T Objeto);

        Task<int> Delete(T Objeto);

        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        Task<int> Save(T model);
    }
}
