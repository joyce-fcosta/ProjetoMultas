using Domain.Interfaces;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Infra.Repository
{
	public class RepositoryGenerics<T> : IGenerics<T> where T : class
	{
		private readonly DbContextOptions<ContextBase> _optionsBuilder;

		public RepositoryGenerics()
		{
			_optionsBuilder = new DbContextOptions<ContextBase>();
		}
		public async Task<int> Add(T objeto)
		{
			using (var data = new ContextBase(_optionsBuilder))
			{
				await data.Set<T>().AddAsync(objeto);
				return await data.SaveChangesAsync();
			}
		}

		public async Task Delete(T objeto)
		{
			using (var data = new ContextBase(_optionsBuilder))
			{
				data.Set<T>().Remove(objeto);
				await data.SaveChangesAsync();
			}
		}

		public Task<T> GetEntityById(int id)
		{
			throw new NotImplementedException();
		}

		
		public async Task<List<T>> List()
		{
			using (var data = new ContextBase(_optionsBuilder))
			{
				return await data.Set<T>().AsNoTracking().ToListAsync();
			}
		}

		public async Task Uppdate(T objeto)
		{
			using (var data = new ContextBase(_optionsBuilder))
			{
				data.Set<T>().Update(objeto);
				await data.SaveChangesAsync();
			}
		}
	}
}
