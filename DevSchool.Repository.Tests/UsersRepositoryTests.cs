using System;
using DevSchool.Model;
using DevSchool.Repository.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevSchool.Repository.Tests
{
	[TestClass]
	public class UsersRepositoryTests
	{
		[TestMethod]
		public void ShouldCreateUser()
		{
			//arrange
			var userRepository = new UsersRepository();
			var user = new User
			{
				Email = "test@test.com",
				FirstName = "name",
				LastName = "lastname",
				Id = Guid.NewGuid()
			};
			//act
			userRepository.Create(user);
			//asserts
			var resultUser = userRepository.Get(user.Id);
			Assert.AreEqual(user.Email, resultUser.Email);
		}
	}
}
