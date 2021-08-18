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
    public abstract class Repository<TEntity,ApplicationDbContext> : IRepository<TEntity> 
        where TEntity : class
        where ApplicationDbContext : DbContext
    {


        protected readonly ApplicationDbContext _dbContext; //giving protected to provide access to the childs

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GetAll
        public virtual ServiceResponse<IEnumerable<TEntity>> GetDetailsAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TEntity>>();
            try
            {
                serviceResponse.Data = _dbContext.Set<TEntity>().ToList();
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
        public virtual ServiceResponse<TEntity> GetDetailsById(int? id)
        {
            var serviceResponse = new ServiceResponse<TEntity>();
            try
            {
                serviceResponse.Data = _dbContext.Set<TEntity>().Find(id);
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

        //ADD
        public virtual ServiceResponse<TEntity> AddDetails(TEntity unit)
        {
            var serviceResponse = new ServiceResponse<TEntity>();
            try
            {
                /*unit.GetType().GetProperty("Id")?.SetValue(unit, 0);*/
                serviceResponse.Data = unit;
                     _dbContext.Set<TEntity>().Add(serviceResponse.Data);
                     _dbContext.SaveChanges();
                    serviceResponse.Message = "Unit created successfully in DB";
                
            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing action failed in the database for given unit\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return  serviceResponse;
        }


        //UpdateDetails
        public virtual ServiceResponse<TEntity> UpdateDetails(TEntity unit)
        {
            var serviceResponse = new ServiceResponse<TEntity>();
            try
            {
                if (unit is TEntity)
                {
                    serviceResponse.Data = _dbContext.Set<TEntity>().Update(unit) as TEntity;
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
        public virtual ServiceResponse<TEntity> UpdateDetails(int id, TEntity unit)
        {
            var serviceResponse = new ServiceResponse<TEntity>();
            int UnitId = (int)unit.GetType().GetProperty("Id").GetValue(unit);

            var p = _dbContext.Set<TEntity>().Find(id);
            if (id != UnitId)
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




        public virtual ServiceResponse<TEntity> DeleteDetails(TEntity unit)
        {
            var ServiceResponse = new ServiceResponse<TEntity>();
            throw new NotImplementedException();
        }






        public virtual ServiceResponse<TEntity> DeleteDetailsConfirmedById(int id)
        {
            var ServiceResponse = new ServiceResponse<TEntity>();

            try
            {
                ServiceResponse.Data = _dbContext.Set<TEntity>().Find(id);
                if(ServiceResponse.Data==null)
                {
                    ServiceResponse.Message = $"{id} no id do not found to delete ";
                    ServiceResponse.Success = false;
                }
                else
                {
                    _dbContext.Set<TEntity>().Remove(ServiceResponse.Data);
                    _dbContext.SaveChanges();
                    ServiceResponse.Message = "Deleting details by id";
                }
            }
            catch (Exception)
            {
                ServiceResponse.Message = $"{id} no id is a bad request ";
                ServiceResponse.Success = false;
            }
            
            
            return ServiceResponse;
            
        }   
       
    }

        
}