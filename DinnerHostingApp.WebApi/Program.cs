using DinnerHostingApp.Application;
using DinnerHostingApp.Infrastructure;
using DinnerHostingApp.WebApi.Errors;
using DinnerHostingApp.WebApi.Filters;
using DinnerHostingApp.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory, DinnerHostingAppProblemDetailsFactory>();

var app = builder.Build();

// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
