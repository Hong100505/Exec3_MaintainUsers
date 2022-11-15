using ISPan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbHelper = new SqlDbHelper("default");

			string sql = @" SELECT　ID ,Name,Height,DateOfBirthd From Userstable WHERE Id > @Id order by Id desc ";



			try
			{
				var parameters = new SqlParametersBuider().AddInt("id", 0).Build();
				DataTable news = dbHelper.Select(sql, parameters);
				foreach (DataRow row in news.Rows)
				{
					int id = row.Field<int>("id");
					

					string Name = row.Field<string>("Name");
					int Height = row.Field<int>("Height");
					DateTime DateOfBirthd = row.Field<DateTime>("DateOfBirthd");
					Console.WriteLine($"id ={id},Name = {Name},Height={Height},DateOfBirthd={DateOfBirthd}");
				}

				Console.WriteLine("紀錄已更新");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因:{ex.Message}");
			}
		}


	}
}
