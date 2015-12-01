using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSchool.Model
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class User : ICloneable
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public override string ToString()
		{
			return $"Email: {Email}";
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}
	}
}
