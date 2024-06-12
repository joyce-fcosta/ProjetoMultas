using Domain.Interfaces;
using Entities.Entities;

namespace Domain.Services
{
	public class ServiceMultas : IServiceMulta
	{
		private readonly IMulta _multa;

		public ServiceMultas(IMulta multa)
		{
			_multa = multa;
		}

		public async Task AdicionaMulta(Multa multa)
		{
			await _multa.Add(multa);
		}

		public async Task AtualizaMulta(Multa multa)
		{
			await _multa.Uppdate(multa);
		}

		public async Task<Multa> BuscarMulta(int id)
		{
			return await _multa.GetEntityById(id);
		}

		public async Task DeletaMulta(int id)
		{
			var multa = await _multa.GetEntityById(id);
			await _multa.Delete(multa);
		}

		public async Task<List<Multa>> ListaMultas()
		{
			return await _multa.List();
		}
	}
}
