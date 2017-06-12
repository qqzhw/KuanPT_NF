using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : class
    {
         
        T GetById(object id);
		 
		/// <summary>
		/// Insert entity
		/// </summary>
		/// <param name="entity">Entity</param>
		void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);
         
        IList<T> GetPageData(string tableName, string orderField, out int totalRecord, out int totalPage, 
            string fields = "", string whereStr = "",int pageIndex = 0, int pageSize = int.MaxValue);
        /// <summary>
        /// Gets a table
        /// </summary>
        IEnumerable<T> GetAll();

		IEnumerable<dynamic> GetList(string sql);

		/// <summary>
		/// Gets a table  
		/// </summary>
		string Database { get; }
		 
		 IDbConnection DbContext { get; }
    }
}
