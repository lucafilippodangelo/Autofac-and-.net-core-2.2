using Microsoft.EntityFrameworkCore;
using System;using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacCore2_2.DataLayer
{

    /// <summary>
    /// "IGenericApplicationRepository" interface defines the behaviour -> Returns all the instances of the input class by method "GetAll()"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericApplicationRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        /*
            void Add(T entity);
            void Remove(T entity);
            List<T> Get();
            T FindById(int id);
            int SaveChanges();
            void Dispose(); 
         */
    }

    //The type argument must be a reference type. In this case the constraint is a class.
    public class GenericApplicationRepository<T> : IGenericApplicationRepository<T> where T : class
    {

        private ApplicationDbContext dbContext;
        protected IDbContextFactory DbFactory { get; private set; }


        /// <summary>
        /// Constructor. Initialization of DbContext
        /// </summary>
        /// <param name="dbFactory"></param>
        public GenericApplicationRepository(IDbContextFactory dbFactory)
        {
            dbContext = dbFactory.Init();
        }

        /// <summary>
        /// Concrete Implementation of "GetAll"
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }
        /*
            public void Add(T item)
            {
                Context.Set<T>().Add(item);
            }

            public void Remove(T item)
            {
                Context.Set<T>().Remove(item);
            }
         */
    }
}