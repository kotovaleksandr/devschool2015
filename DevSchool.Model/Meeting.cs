using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchool.Model
{
	public class Meeting
	{
		public IEnumerable<User> Participents { get; set; }
		public User Owner { get; set; }
		public Guid Id { get; set; }
		public string Title { get; set; }
		public Place Place { get; set; }
	}
}
