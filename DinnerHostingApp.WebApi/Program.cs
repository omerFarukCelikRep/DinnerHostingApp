using DinnerHostingApp.Application;
using DinnerHostingApp.Infrastructure;
using DinnerHostingApp.WebApi.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory, DinnerHostingAppProblemDetailsFactory>();

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
