using System.Collections.Generic;

namespace ArenaGame.Repositories.Contracts
{
	public interface IRepository<T>
	{
		void Add(T item);
		bool Remove(T item);
		T FindByName(string name);
		IReadOnlyCollection<T> GetAll();
	}
}