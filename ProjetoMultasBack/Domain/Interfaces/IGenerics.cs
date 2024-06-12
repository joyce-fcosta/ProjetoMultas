namespace Domain.Interfaces
{
	public interface IGenerics<T> where T : class
	{
		Task<int> Add(T objeto);
		Task Uppdate(T objeto);
		Task Delete(T objeto);
		Task<T> GetEntityById(int id);
		Task<List<T>> List();
	}
}
