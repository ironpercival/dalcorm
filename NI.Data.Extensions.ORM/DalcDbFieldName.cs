using System;

namespace NI.Data.Extensions.ORM
{
	[AttributeUsage(AttributeTargets.Property)]
	public class DalcDbFieldName : Attribute {
		private string name;
		public string Name => name;
		public DalcDbFieldName(string name) {
			this.name = name;
		}
	}
}