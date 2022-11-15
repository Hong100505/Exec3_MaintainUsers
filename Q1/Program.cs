using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPan.Utility;

namespace Q1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbHelper = new SqlDbHelper("default");
			

			string sql = "INSERT INTO　Userstable(Name,Account,Password,DateOfBirthd,Height)" +
				                      "Values(@Name,@Account,@Password,@DateOfBirthd,@Height)";

			try
			{
				var parameters = new SqlParametersBuider().AddNVarchar("Name", 50, "H.Name")
														  .AddNVarchar("Account", 3000, "H.Account")
														  .AddNVarchar("Password", 3000, "H.Password")
														  .AddDate("DateOfBirthd", new DateTime(2022, 10, 10))
														  .AddInt("Height",20)
														  .Build();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("紀錄已新增");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因:{ex.Message}");
			}

		}
	}
}
