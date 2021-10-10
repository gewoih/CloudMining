using CloudMining.Data;
using CloudMining.Models.Base;
using System;
using System.Linq;

namespace CloudMining.Models.DataWorkers.Base
{
	public abstract class BaseDataWorker<T> : IDataWorker<T> where T : Entity
	{
		private readonly BaseDataContext DBContext = new BaseDataContext();

		public virtual IQueryable<T> GetAll()
		{
			return DBContext.Set<T>();
		}

		public T GetById(int id)
		{
			return GetAll().FirstOrDefault(item => item.Id == id);
		}

		public T Create(T entity)
		{
			DBContext.Set<T>().Add(entity);
			DBContext.SaveChanges();

			return GetById(entity.Id);
		}

		public void Update(int id, T entity)
		{
			DBContext.Set<T>().Update(entity);
			DBContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = GetById(id);
			DBContext.Set<T>().Remove(entity);

			DBContext.SaveChanges();
		}
	}
}
