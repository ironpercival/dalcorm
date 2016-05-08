using System;

namespace NI.Data.Extensions.ORM
{
	[AttributeUsage(AttributeTargets.Class)]
	public class DalcDbTableName : Attribute {
		private string name;
		public string Name => name;
		public DalcDbTableName(string name) {
			this.name = name;
		}
	}
}