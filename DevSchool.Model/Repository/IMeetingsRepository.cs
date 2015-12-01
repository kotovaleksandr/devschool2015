using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchool.Model.Repository
{
	public interface IMeetingsRepository
	{
		void Create(Meeting meeting);
	}
}
