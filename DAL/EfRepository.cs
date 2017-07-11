using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
//using Dapper.Contrib.Extensions;
using DapperExtensions;
namespace IMCustSys.DAL
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : DataConnection,IRepository<T> where T : class
	{ 
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbConnection context):base(context)
        {
			 
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(Exception exc)
        {
            var msg = string.Empty; 
                 
            return exc.Message;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        { 
            return  Connection.Get<T>(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
             try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                  Connection.Insert(entity);                 
            }
            catch (Exception dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                  Connection.Insert(entity);  
            }
            catch (Exception dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
				Connection.Update(entity); 
            }
            catch (Exception dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
				foreach (var entity in entities)
					Connection.Update(entity); 
            }
            catch (Exception dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
				Connection.Delete(entity); 
            }
            catch (Exception dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
				foreach (var entity in entities)
					Connection.Delete(entity); 
            }
            catch (Exception dbEx)
            { 
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        } 

		#endregion

		#region Properties

		/// <summary>
		/// Gets a table
		/// </summary>
		public virtual IEnumerable<T> GetAll()
        { 
             return Connection.GetList<T>();
        }
        public virtual IEnumerable<T> GetList(object predicate=null,IList<ISort> sort=null)
        {
            return Connection.GetList<T>(predicate,sort);
        }
        public IEnumerable<dynamic>  GetList(string sql)
		{ 
			var list=Connection.Query<dynamic>(sql);
			return list; 		   
		}
        public IEnumerable<T> GetList<T1, T2>(string sql)
        {
            var list = Connection.Query<T1, T2, T>(sql, (t1, t2) => { return null; });
            return list;
        }
        public IEnumerable<T> GetList<T1,T2,T3>(string sql)
		{
			var list = Connection.Query<T1,T2,T3,T>(sql,(t1,t2,t3)=> { return null; });
			return list;            
		}

        public IList<T> GetPageData(string fields="", string orderField="", int pageIndex=0,
            int pageSize=int.MaxValue, string whereStr=""  )
        {             
            var result = new List<T>();  
            string sql = string.Format("SELECT {0} FROM (SELECT ROW_NUMBER() OVER (ORDER BY {1}) AS ROWID, "
                + "{0} FROM {2} where 1=1 {3} ) AS t WHERE ROWID BETWEEN {4} AND {5}",
                fields,
                orderField,
                 "",
                whereStr,
                (pageIndex - 1) * pageSize + 1,
                pageIndex * pageSize);
            result =  Connection.Query<T>(sql).AsList();
            return result; 
        }

        #region 获取分页数据  
        /// <summary>  
        /// 获取分页数据  
        /// </summary>  
        /// <param name="fields">字段,如*或逗号分隔</param>  
        /// <param name="orderField">排序,如id desc</param>  
        /// <param name="pageIndex">当前页码</param>  
        /// <param name="pageSize">每页条数</param>  
        /// <param name="whereStr">条件</param>  
        /// <param name="totalRecord">总记录数</param>  
        /// <param name="totalPage">总页数</param>  
        /// <returns></returns>   
        public IList<T> GetPageData(string tableName, string orderField, out int totalRecord, out int totalPage,
            string fields = "", string whereStr = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
            totalRecord = Connection.ExecuteScalar<int>(string.Format("SELECT count(1) FROM " + tableName + " where 1=1 {0}", whereStr));
            totalPage = (totalRecord % pageSize != 0) ? (totalRecord / pageSize + 1) : totalRecord / pageSize;
            string sql = string.Format("SELECT {0} FROM (SELECT ROW_NUMBER() OVER (ORDER BY {1}) AS ROWID, "
                + "{0} FROM {2} where 1=1 {3} ) AS t WHERE ROWID BETWEEN {4} AND {5}",
                fields,
                orderField,
                tableName,
                whereStr,
                (pageIndex) * pageSize + 1,
                (pageIndex + 1) * pageSize);
            var result = Connection.Query<T>(sql).AsList();

            return result;
        }
        #endregion


        public virtual string Database
        {
            get
            {
				return Connection.Database;
            }
        }

		public IDbConnection DbContext {
        
            get{return Connection;}
        }  

		#endregion
	}
}