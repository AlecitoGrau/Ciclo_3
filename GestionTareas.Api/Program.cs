
using FluentValidation.AspNetCore;
using GestionTareas.Core.Interfaces;
using GestionTareas.Core.Services;
using GestionTareas.Infraestructure.Data;
using GestionTareas.Infraestructure.Filters;
using GestionTareas.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Api
{
	public class Program
	{
		[Obsolete]
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			builder.Services.AddControllers(options => 
			{
				options.Filters.Add<GlobalExceptionFilter>();
			});
			//Dependencias

			builder.Services.AddDbContext<PruebaSyspotecContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaSyspotec"))
			);

			builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
			builder.Services.AddTransient<ITareasServices, TareasServices>();
			builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddTransient<ITareasRepository, TareasRepository>();

			builder.Services.AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
