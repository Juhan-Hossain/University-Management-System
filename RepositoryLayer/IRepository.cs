using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository<T> where T : class
    {
        public ServiceResponse<IEnumerable<T>> GetAll();
        public ServiceResponse<T> GetById(int? id);
        public ServiceResponse<T> Add(T unit);
        public ServiceResponse<T> Update(T unit);
        public ServiceResponse<T> Update(int id, T unit);
        public ServiceResponse<T> Delete(T unit);
        public ServiceResponse<T> DeleteById(int id);
        public ServiceResponse<IQueryable<T>> FindDDL(Expression<Func<T, bool>> expression);
    }
}
