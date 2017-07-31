using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IMCustSys.DAL
{
	public partial class DataConnection : IDisposable
	{
		private IDbConnection _connection;
        private static string sqlcon = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        protected IDbConnection Connection
		{
            
			get {
                
                    //if (_connection.State != ConnectionState.Open)
                    //{
                    //    _connection.Open();
                    //} 
                    //    _connection = new SqlConnection(sqlcon); 
                   
                    return _connection;
                
			}
		}
		public DataConnection(IDbConnection connection)
		{
			_connection = new SqlConnection(sqlcon); 			
		}
		
		#region IDisposable Support		
		public void Dispose()
		{
            lock (_connection)
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
		}
		#endregion

	}
}
