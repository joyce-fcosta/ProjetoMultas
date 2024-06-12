using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
	[ApiController]
	public class UsuarioController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public UsuarioController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("/api/AdicionarUsuario")]
		public async Task<IActionResult> AdicionarUsuario([FromBody] CadastroUsuario cadastro)
		{
			if (string.IsNullOrWhiteSpace(cadastro.Nome) || string.IsNullOrWhiteSpace(cadastro.Email) || string.IsNullOrWhiteSpace(cadastro.Senha))
			{
				return Ok("Falta alguns dados.");
			}

			var user = new ApplicationUser
			{
				Email = cadastro.Email,
				UserName = cadastro.Email,
				Nome = cadastro.Nome,
				TipoUsuario = TipoUsuario.Comum
			};

			var result = await _userManager.CreateAsync(user, cadastro.Senha);

			if (result.Errors.Any())
			{
				return Ok(result.Errors);
			}

			//Geração de confirmação de email

			var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

			//retorno do email
			code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

			var response_Retorn = await _userManager.ConfirmEmailAsync(user, code);

			if (response_Retorn.Succeeded)
			{

				//IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "User");

				return Ok("Usuário adicionado!");
			}
			else
			{
				return Ok("Erro ao cadastrar de usuário!");
			}
		}
	}
}
