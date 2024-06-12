

using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
	public class ApplicationUser : IdentityUser
	{
		[MaxLength(150)]
		public string Nome { get; set; }

		public TipoUsuario TipoUsuario { get; set; }
	}
}
