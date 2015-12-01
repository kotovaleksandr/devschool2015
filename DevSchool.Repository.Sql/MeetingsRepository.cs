using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSchool.Model;
using DevSchool.Model.Repository;

namespace DevSchool.Repository.Sql
{
	public class MeetingsRepository : IMeetingsRepository
	{
		private readonly IUsersRepository _usersRepository;

		public MeetingsRepository(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public void Create(Meeting meeting)
		{
			if (!_usersRepository.Contains(meeting.Owner.Id))
				throw new Exception(string.Format("Пользователь {0} не найден", meeting.Owner.Id));
			//код создания встречи
		}
	}
}
