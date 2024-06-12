using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Token
{
	//Chave relacionada ao jwt
	public class JwtSecurityKey
	{
		public static SymmetricSecurityKey Create(string secret)
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
		}
	}
}
