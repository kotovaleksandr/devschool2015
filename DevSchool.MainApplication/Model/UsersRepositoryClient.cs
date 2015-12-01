using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevSchool.Model;

namespace DevSchool.MainApplication.Model
{
	public class UsersRepositoryClient
	{
		public async Task<User> GetUser(Guid id)
		{
			using (var client = new HttpClient
			{
				BaseAddress = new Uri(@"http://localhost:25889/")
			})
			{
				var response = client.GetAsync("api/users/" + id).Result;
				return await response.Content.ReadAsAsync<User>();
			}
		}
	}
}
