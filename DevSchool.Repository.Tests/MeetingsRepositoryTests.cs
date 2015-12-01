using System;
using System.Security.Cryptography.X509Certificates;
using DevSchool.Model;
using DevSchool.Model.Repository;
using DevSchool.Repository.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevSchool.Repository.Tests
{
	[TestClass]
	public class MeetingsRepositoryTests
	{
		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void ShouldCheckOwnerInUsers()
		{
			//arrange
			var owner = new User
			{
				Id = Guid.NewGuid()
			};
			var usersRepositoryMock = new Moq.Mock<IUsersRepository>();
			usersRepositoryMock.Setup(x => x.Contains(owner.Id)).Returns(false);
			var meetingsRepository = new MeetingsRepository(usersRepositoryMock.Object);
			meetingsRepository.Create(new Meeting
			{
				Owner = owner
			});
			throw new Exception("error");
		}
	}

	public class UserRepositoryFake : IUsersRepository
	{
		public void Create(User user)
		{
			throw new NotImplementedException();
		}

		public User Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool Contains(Guid id)
		{
			return false;
		}
	}
}
