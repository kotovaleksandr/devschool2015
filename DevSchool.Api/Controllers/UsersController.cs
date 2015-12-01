using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevSchool.Model;
using DevSchool.Model.Repository;
using DevSchool.Repository.Sql;
using NLog;

namespace DevSchool.Api.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IUsersRepository _repository = new UsersRepository();
		private NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

		[HttpPost]
		public User Post(User user)
		{
			using (new LogWrapper(_log, "create user " + user.Id))
			{
				user.Id = Guid.NewGuid();
				_repository.Create(user);
			}
			return _repository.Get(user.Id);
		}

		[HttpGet]
		public User Get(Guid id)
		{
			return new User
			{
				Email = "afafa@gmail.com"
			};
		}

		[HttpGet]
		[Route("api/bla/{id}/vbal/{i}")]
		public User Get(Guid id, int i)
		{
			return new User
			{
				Email = "afafa@gmail.com"
			};
		}
	}

	public struct LogWrapper : IDisposable
	{
		private readonly Logger _logger;
		private readonly string _message;

		public LogWrapper(Logger logger, string message)
		{
			_logger = logger;
			_message = message;
			_logger.Debug("Begin {0}", message);
		}

		public void Dispose()
		{
			_logger.Debug("End {0}", _message);
		}
	}
}
