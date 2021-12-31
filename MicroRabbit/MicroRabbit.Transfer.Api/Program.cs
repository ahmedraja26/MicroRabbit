using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
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
builder.Services.AddDbContext<TransferDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));

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
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice V1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ConfigureEventBus(app);
 void ConfigureEventBus(IApplicationBuilder app)
{
	var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
	eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler > ();

}

app.Run();
