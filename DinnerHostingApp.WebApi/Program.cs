using DinnerHostingApp.Application;
using DinnerHostingApp.Infrastructure;
using DinnerHostingApp.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
