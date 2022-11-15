using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPan.Utility
{
	public class SqlParametersBuider
	{

		private List<SqlParameter> parameters = new List<SqlParameter>();
		public SqlParametersBuider AddNVarchar(string name, int lenght, string value)
		{
			var param = new SqlParameter(name, SqlDbType.NVarChar, lenght) { Value = value };
			parameters.Add(param);
			return this;
		}
		public SqlParametersBuider AddInt(string name, int value)
		{
			var param = new SqlParameter(name, SqlDbType.Int) { Value = value };
			parameters.Add(param);
			return this;
		}

		public SqlParametersBuider AddDate(string name, DateTime value)
		{
			var param = new SqlParameter(name,SqlDbType.DateTime) { Value = value };
			parameters.Add(param);
			return this;
		}
		

		public SqlParameter[] Build()
		{
			return parameters.ToArray();
		}

		
	}
}
