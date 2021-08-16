using Microsoft.EntityFrameworkCore;
using StudentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _dbContext; //giving public to provide access to the childs

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CREATE
        public virtual ServiceResponse<T> CreateDetails(T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                if(unit is T)
                {
                    serviceResponse.Data = _dbContext.Set<T>().Add(unit) as T;
                    _dbContext.SaveChanges();
                    serviceResponse.Message = "Unit created successfully in DB";
                }
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing action failed in the database for given unit\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public virtual ServiceResponse<T> DeleteDetails(T unit)
        {
            var ServiceResponse = new ServiceResponse<T>();
            throw new NotImplementedException();
        }

        public virtual ServiceResponse<T> DeleteDetailsConfirmedById(int id)
        {
            var ServiceResponse = new ServiceResponse<T>();
            throw new NotImplementedException();
        }


        //GetAll
        public virtual ServiceResponse<IEnumerable<T>> GetDetailsAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {
                serviceResponse.Data =  _dbContext.Set<T>().ToList();
                serviceResponse.Message = "Data loaded in ServiceResponse.Data Successfully";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Error occurred while loading data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
           
            return serviceResponse;
        }

        //GetById
        public virtual ServiceResponse<T> GetDetailsById(int? id)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                serviceResponse.Data = _dbContext.Set<T>().Find(id);
                if (id != null)
                {
                    if (serviceResponse.Data == null)
                    {
                        serviceResponse.Message = "Bad request occured for given id";
                        serviceResponse.Success = false;
                    }
                    else serviceResponse.Message = "Data  with the given id was found & loaded " +
                            "in serviceResponse.Data";
                }
                else
                {
                    serviceResponse.Message = "Bad request occured for null id";
                    serviceResponse.Success = false;
                }
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Error occurred while loading data." +
                    "\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        
        //UpdateDetails
        public virtual ServiceResponse<T> UpdateDetails(T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                if (unit is T)
                {
                    serviceResponse.Data = _dbContext.Set<T>().Update(unit) as T;
                    _dbContext.SaveChanges();
                    serviceResponse.Message = "Unit Updated successfully in DB";
                }
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Updating action failed in the database for given unit\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //UpdateDetails
        public virtual ServiceResponse<T> UpdateDetails(int id, T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            int UnitId = (int)unit.GetType().GetProperty("Id").GetValue(unit);
            
            var p = _dbContext.Set<T>().Find(id);
            if (id!=UnitId)
            {
                serviceResponse.Data = unit;
                serviceResponse.Message = "Bad update request!!!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            else
            {
                /*if (unit.GetType().GetProperties().Id)*/
                    _dbContext.Entry(unit).State = EntityState.Modified;
                _dbContext.SaveChanges();
                serviceResponse.Data = unit;
                serviceResponse.Message = "Update Success!!!";
            }
            return serviceResponse;

        }
    }

        
}