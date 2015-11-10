using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevSchool.Model;
using DevSchool.Model.Repository;
using DevSchool.Repository.Sql;

namespace DevSchool.Api.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IUsersRepository _repository = new UsersRepository();

		[HttpPost]
		public User Post(User user)
		{
			user.Id = Guid.NewGuid();
			_repository.Create(user);
			return _repository.Get(user.Id);
		}

		[HttpGet]
		public User Get(Guid id)
		{
			return _repository.Get(id);
		}
	}
}
