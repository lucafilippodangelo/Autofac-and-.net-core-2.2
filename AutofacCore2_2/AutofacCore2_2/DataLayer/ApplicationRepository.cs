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
    }


    public class GenericApplicationRepository<T> : IGenericApplicationRepository<T> where T : class
    {

        private ApplicationDbContext dbContext;
        protected IDbFactory DbFactory { get; private set; }


        /// <summary>
        /// Constructor. Initialization of DbContext
        /// </summary>
        /// <param name="dbFactory"></param>
        public GenericApplicationRepository(IDbFactory dbFactory)
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
    }
}