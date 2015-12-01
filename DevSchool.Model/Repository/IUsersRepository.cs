using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchool.Model.Repository
{
	public interface IUsersRepository
	{
		/// <summary>
		/// Метод создания пользователя
		/// </summary>
		/// <param name="user"></param>
		void Create(User user);
		User Get(Guid id);
		bool Contains(Guid id);
	}
}
