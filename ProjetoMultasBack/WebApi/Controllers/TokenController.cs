using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
	[ApiController]
	public class TokenController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		public TokenController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("api/CreateToken")]
		[Produces("application/json")]
		public async Task<IActionResult> CreateToken([FromBody] Login login)
		{
			if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
			{
				return Unauthorized();// retorna não autorizado
			}

			var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: true);

			if (result.Succeeded)
			{
				var user = await _userManager.FindByEmailAsync(login.Email);

				var token = new TokenJWTBuilder()
							.AddSecurityKey(JwtSecurityKey.Create("this is my custom Secret key for authentication"))
							.AddSubject("Projeto Multa")
							.AddIssuer("Teste.Security.Bearer")
							.AddAudience("Teste.Security.Bearer")
							.AddClaims("UsuarioAPINumero", "1")
							.AddExpiryInMinutes(360)
							.Builder();

				var dados = new DadosUsuario()
				{
					Token = token.value,
					Id = user.Id,
					Tipo = user.TipoUsuario,
				};

				return Ok(dados);
			}

			return Unauthorized();

		}
	}
}
