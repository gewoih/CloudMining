using CloudMining.Models.Base;
using System.Linq;

namespace CloudMining.Models.DataWorkers.Base
{
	public interface IDataWorker<T> where T: Entity
	{
		T GetById(int id);
		IQueryable<T> GetAll();

		T Create(T entity);

		void Update(int id, T entity);

		void Delete(int id);
	}
}
