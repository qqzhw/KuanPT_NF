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
		 
        private static string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        public virtual IDbConnection Connection()
        {
            return new SqlConnection(connectionString);
        }
        public DataConnection()
		{ 

		}
		
		#region IDisposable Support		
		public void Dispose()
		{ 
            GC.Collect(); 
		}
		#endregion

	}
}
