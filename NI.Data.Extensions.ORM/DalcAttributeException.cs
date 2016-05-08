using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NI.Data.Extensions.ORM
{
	public class DalcAttributeException : Exception {
		public DalcAttributeException(string msg) : base(msg) {
		}
	}
}
