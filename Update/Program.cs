using ISPan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbHelper = new SqlDbHelper("default");

			string sql = @"UPDATE　Userstable set Name = @Name,Password = @Password where id=@id";

			try
			{
				var parameters = new SqlParametersBuider().AddNVarchar("Name",50, "Up.H")
														  .AddNVarchar("Password", 50, "up.password")
														  .AddInt("id",1)
														  .Build();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("紀錄已更新");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因:{ex.Message}");
			}
		}
	}
}
