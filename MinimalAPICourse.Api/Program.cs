using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalAPICourse.Api.Extentions;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Application.Posts.Queries;
using MinimalAPICourse.Domain.Models;


var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.Use(async (ctx, next) =>
{
	try
	{
		await next();
	}
	catch (Exception)
	{
		ctx.Response.StatusCode = 500;
		await ctx.Response.WriteAsync("An error ocurred");
	}
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();
