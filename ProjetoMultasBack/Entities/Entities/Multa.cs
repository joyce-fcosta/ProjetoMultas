using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
	public class Multa
	{
		
		public int Id { get; set; }

		[Column(TypeName = "varchar(12)")]
		public string AIT { get; set; }

		[Column(TypeName = "varchar(8)")]
		public string Data { get; set; }

		[Column(TypeName = "varchar(4)")]
		public string Hora { get; set; }

		[Column(TypeName = "varchar(12)")]
		public string CodigoInfracao { get; set; }

		[Column(TypeName = "varchar(8)")]
		public string PlacaVeiculo { get; set; }

		[ForeignKey("ApplicationUser")]
		[Column(Order = 1)]
		public string UserId {  get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }	
	}
}
