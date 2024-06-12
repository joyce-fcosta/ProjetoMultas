using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Authorize]
	[ApiController]
	public class MultasController : Controller
	{
		public readonly IServiceMulta _serviceMulta;
		public readonly UserManager<ApplicationUser> _userManager;
		public MultasController(IServiceMulta serviceMulta, UserManager<ApplicationUser> userManager)
		{
			_serviceMulta = serviceMulta;
			_userManager = userManager;
		}

		[HttpGet]
		[Route("/api/Lista")]
		[Produces("application/json")]
		public async Task<object> ListaMultas()
		{
			return await _serviceMulta.ListaMultas();
		}

		[HttpPost]
		[Route("/api/AdicionaProdutos")]
		public async Task<object> AdicionaProduto([FromBody] Multa multa)
		{
			try
			{
				await _serviceMulta.AdicionaMulta(multa);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
			}
			return Task.FromResult(true);
		}


		[HttpPut]
		[Route("/api/EditaProduto")]
		public async Task<object> EditaProduto([FromBody] Multa multa)
		{
			try
			{
				await _serviceMulta.AtualizaMulta(multa);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
			}
			return Task.FromResult(true);
		}

		[HttpDelete]
		[Route("/api/DeletaProduto/{id}")]
		public async Task<object> DeletaProduto(int id)
		{
			try
			{
				await _serviceMulta.DeletaMulta(id);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
			}
			return Task.FromResult(true);
		}
	}
}
