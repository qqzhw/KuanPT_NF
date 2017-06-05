using System.Collections.Generic;


namespace  DAL
{
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>    
         TEntity Set<TEntity>() where TEntity : class;
        
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : class, new();

      
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

     
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
          
    }
}
