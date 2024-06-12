using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IServiceMulta
	{
		Task AdicionaMulta(Multa multa);

		Task AtualizaMulta(Multa multa);

		Task DeletaMulta(int id);

		Task<List<Multa>> ListaMultas();

	}
}
