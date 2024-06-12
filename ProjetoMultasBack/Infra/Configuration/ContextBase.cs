using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infra.Configuration
{
	public class ContextBase : IdentityDbContext<ApplicationUser>
	{
		public ContextBase() { }

		public ContextBase(DbContextOptions<ContextBase> options) : base(options)
		{

		}

		public DbSet<Multa> Multa { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(ObterStringConexao());
				base.OnConfiguring(optionsBuilder);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
			base.OnModelCreating(builder);
		}

		public string ObterStringConexao()
		{
			return "Data source=JOYCE\\SQLECOMMERCE; Initial Catalog = projetoMulta; Integrated Security=True; TrustServerCertificate=True";
		}
	}
}
