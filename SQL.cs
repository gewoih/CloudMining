using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace CloudMining
{
	class SQL
	{
		private string connectionString;
		private SqlConnection connection;
		private SqlCommand command;

		public SQL()
		{
			this.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ranenko\Desktop\Проекты\CloudMining\CloudMiningDB.mdf;Integrated Security=True;Connect Timeout=30";
			this.connection = new SqlConnection(this.connectionString);
			this.connection.Open();
		}

		~SQL()
		{
			this.connection.Close();
		}

		public SqlDataReader Execute(string _command, bool _isStoredProcedure = false, List<SqlParameter> _parameters = null)
		{
			this.command = new SqlCommand(_command, connection);
			if (_isStoredProcedure == true)
			{
				this.command.CommandType = System.Data.CommandType.StoredProcedure;
				if (_parameters != null)
				{
					foreach (var item in _parameters)
						SetParameters(item.ParameterName, item.Value);
				}
			}
			return this.command.ExecuteReader();
		}

		private void SetParameters(string parameter, object value)
		{
			this.command.Parameters.Add(new SqlParameter(parameter, value));
		}
	}
}