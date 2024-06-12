using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });

	//Ao especificar a defini��o de seguran�a, o Swagger levar� em considera��o que dever� adicionar o recurso de autoriza��o.
	//Este recurso consiste em um bot�o �Autorizar� no topo da p�gina que definir� o cabe�alho de autoriza��o. 
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = string.Format(@"JWT Authorization header using the Bearer scheme.
									  Enter 'Bearer'[space] and then your token in the text input below.
									  Exemplo: Bearer 12345abcdef"),

	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
						{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
					  });
});

builder.Services.AddDbContext<ContextBase>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<ApplicationUser>(option => option.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ContextBase>();

//Inje��o de depend�ncia
builder.Services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IMulta, RepositoryMulta>();
builder.Services.AddSingleton<IServiceMulta, ServiceMultas>();


builder.Services.Configure<IdentityOptions>(options =>
{
	// Default Password settings.
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;
});

//Token JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(option =>
	{
		option.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,

			ClockSkew = TimeSpan.Zero,
			ValidIssuer = "Teste.Security.Bearer",
			ValidAudience = "Teste.Security.Bearer",
			IssuerSigningKey = JwtSecurityKey.Create("this is my custom Secret key for authentication") //Metodo que foi criado
		};

		option.Events = new JwtBearerEvents
		{
			OnAuthenticationFailed = context =>
			{
				Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
				return Task.CompletedTask;
			},

			OnTokenValidated = context =>
			{
				Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
				return Task.CompletedTask;
			}
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}

var devClient = "http://localhost:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run("http://localhost:5018");
