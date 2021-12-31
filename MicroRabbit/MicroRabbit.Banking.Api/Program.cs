using MediatR;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking Microservice", Version = "v1" }));

builder.Services.AddMediatR(typeof(IStartup));
string connString = builder.Configuration.GetConnectionString("BankingDbConnection");
builder.Services.AddDbContext<BankDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection"));

});

RegisterServices(builder.Services);

void RegisterServices(IServiceCollection services)
{
	DependancyContainer.RegisterServices(services);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
