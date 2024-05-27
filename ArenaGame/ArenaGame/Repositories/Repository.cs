using System.Collections.Generic;
using ArenaGame.Repositories.Contracts;

namespace ArenaGame.Repositories
{
	public class Repository<T> : IRepository<T>
	{
		private readonly List<T> items;

		public Repository()
		{
			items = new List<T>();
		}

		public void Add(T item)
		{
			items.Add(item);
		}

		public bool Remove(T item)
		{
			return items.Remove(item);
		}

		public T FindByName(string name)
		{
			return items.Find(item => (item as IHero)?.Name == name);
		}

		public IReadOnlyCollection<T> GetAll()
		{
			return items.AsReadOnly();
		}
	}
}
