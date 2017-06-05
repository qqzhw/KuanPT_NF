using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	public partial class DataConnection : IDisposable
	{
		private IDbConnection _connection;

		protected IDbConnection Connection
		{
			get {
				if (_connection.State!=ConnectionState.Open)
				{
					_connection.Open();
				}
				return _connection;
			}
		}
		public DataConnection(IDbConnection connection)
		{
			_connection = connection;			
		}
		
		#region IDisposable Support		
		public void Dispose()
		{
			if (_connection!=null&&_connection.State!=ConnectionState.Closed)
			{
				_connection.Close();
			}
		}
		#endregion

	}
}
