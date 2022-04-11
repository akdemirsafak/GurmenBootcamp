using Bootcamp.API.DTOs;
using Bootcamp.API.Filters;
using Bootcamp.API.Middlewares;
using Bootcamp.API.Models;
using Microsoft.AspNetCore.Diagnostics;
using Bootcamp.API;
using Bootcamp.API.Middlewares;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Data;
using Npgsql;
using Bootcamp.API.Repositories;
using Bootcamp.API.Seed;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(option => option.Filters.Add(new ValidateFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.Configure<ApiBehaviorOptions>(option =>
{

    option.SuppressModelStateInvalidFilter = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DI Container
builder.Services.AddScoped<NotFoundProductFilter>();



builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgresql")));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IDbTransaction>(sp =>
{

    var connection = sp.GetRequiredService<IDbConnection>();
    connection.Open();
    return connection.BeginTransaction();


});


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbConnection = scope.ServiceProvider.GetRequiredService<IDbConnection>();

    dbConnection.Open();
    await Seed.Create(dbConnection);
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<IPAddressControlMiddleware>();


app.UseGlobalExceptionMiddleware();






//http://www.myap.com/api/products=> : 880 https :443  SLL => private key public key url
app.UseHttpsRedirection();


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before  MW1\n");
//    await next();
//    await context.Response.WriteAsync("After  MW1\n");

//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Before  MW2\n");
//    await next();
//    await context.Response.WriteAsync("After  MW2\n");

//});

//app.Run(async context =>
//{

//    await context.Response.WriteAsync("Terminal MW\n");

//});



app.UseAuthentication(); // kimlik doğrulama => Token ömrünü,imzasını,token'ı kim dağıtmış //  => 401
                         // kimlik yetkilendirme => 403
app.UseAuthorization();
app.MapControllers();

app.Run();
