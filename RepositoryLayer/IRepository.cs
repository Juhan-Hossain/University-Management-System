using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository<T> where T : class
    {
        public ServiceResponse<IEnumerable<T>> GetDetailsAll();
        public ServiceResponse<T> GetDetailsById(int? id);
        public ServiceResponse<T> AddDetails(T unit);
        public ServiceResponse<T> UpdateDetails(T unit);
        public ServiceResponse<T> UpdateDetails(int id, T unit);
        public ServiceResponse<T> DeleteDetails(T unit);
        public ServiceResponse<T> DeleteDetailsConfirmedById(int id);
    }
}
