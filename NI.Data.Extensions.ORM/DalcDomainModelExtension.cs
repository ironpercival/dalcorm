using System;
using System.Linq;

namespace NI.Data.Extensions.ORM {
	/// <summary>
	/// Simple ORM-style extension for NI.Data.DataRowDalcMapper. Provides 4 additional methods to load, create, update, delete a domain entity.
	/// </summary>
	public static class DalcDomainModelExtension {
		
		public static T LoadEntity<T>(this DataRowDalcMapper dbMgr, params object[] pk) where T : class, new() {
			return dbMgr.GetObjectDalcMapper<T>().Load(pk);
		}

		public static T LoadEntity<T>(this DataRowDalcMapper dbMgr, Query q) where T : class, new() {
			return dbMgr.GetObjectDalcMapper<T>().Load(q);
		}

		public static void AddEntity<T>(this DataRowDalcMapper dbMgr, T entity) where T : class, new() {
			dbMgr.GetObjectDalcMapper<T>().Add(entity);
		}

		public static void UpdateEntity<T>(this DataRowDalcMapper dbMgr, T entity, bool createNew = false) where T : class, new() {
			dbMgr.GetObjectDalcMapper<T>().Update(entity, createNew);
		}

		public static void DeleteEntity<T>(this DataRowDalcMapper dbMgr, T entity) where T : class, new() {
			dbMgr.GetObjectDalcMapper<T>().Delete(entity);
		}

		private static ObjectDalcMapper<T> GetObjectDalcMapper<T>(this DataRowDalcMapper dbMgr) where T : class, new() {

			var attrs = Attribute.GetCustomAttributes(typeof(T));
			var tblName = attrs.OfType<DalcDbTableName>().FirstOrDefault()?.Name;

			if (string.IsNullOrEmpty(tblName))
				throw new DalcAttributeException("Domain entity class must have table name attribute specified");

			var dalcMappedProperties =
				typeof(T).GetProperties().Where(p => Attribute.GetCustomAttributes(p).OfType<DalcDbFieldName>().Any()).ToArray();

			if (!dalcMappedProperties.Any())
				throw new DalcAttributeException("Domain entity class must have at least one property mapped to a DB table field");

			var colNameToProperty = dalcMappedProperties.ToDictionary(p => Attribute.GetCustomAttributes(p).OfType<DalcDbFieldName>().First().Name,
				p => p.Name);

			return new ObjectDalcMapper<T>(dbMgr, tblName, colNameToProperty);
		}
	}
}