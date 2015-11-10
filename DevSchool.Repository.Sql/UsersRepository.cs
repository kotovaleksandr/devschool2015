using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSchool.Model;
using DevSchool.Model.Repository;

namespace DevSchool.Repository.Sql
{
	public class UsersRepository : IUsersRepository
	{
		private const string ConnectionString =
			@"Data Source=localhost\sqlexpress;Initial Catalog=DS;Integrated Security=True;Pooling=False";

		public void Create(User user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "insert into [dbo].[User] (Id, FirstName, LastName, Email) values (@Id, @FirstName, @LastName, @Email)";
					command.Parameters.AddWithValue("@id", user.Id);
					command.Parameters.AddWithValue("@firstname", user.FirstName);
					command.Parameters.AddWithValue("@lastname", user.LastName);
					command.Parameters.AddWithValue("@email", user.Email);
					command.ExecuteNonQuery();
				}
			}
		}

		public User Get(Guid id)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "select id, firstname, lastname, email from [dbo].[User] where id = @id";
					command.Parameters.AddWithValue("@id", id);
					using (var reader = command.ExecuteReader())
					{
						reader.Read();
						return new User
						{
							Email = reader.GetString(reader.GetOrdinal("Email"))
						};
					}
				}
			}
		}
	}
}