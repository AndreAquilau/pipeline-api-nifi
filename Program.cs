using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UsePathBase("/api/v1");

int status = 1;

app.MapPost("/login", (HttpContext context) =>
{

    Thread.Sleep(5000);

    Console.WriteLine("");

    Console.WriteLine("login: " + DateTime.Now.ToString());

    foreach (var item in context.Request.Form)
    {
        Console.WriteLine(item);
    }

    foreach (var head in context.Request.Headers)
    { 
        Console.WriteLine(head); 
    }

    Console.WriteLine("");

    var token = Guid.NewGuid().ToString();
    return new { token };

})
.Accepts<string>("application/x-www-form-urlencoded");

app.MapPut("/apply", (HttpContext context) =>
{

    Thread.Sleep(5000);

    Console.WriteLine("");

    Console.WriteLine("apply: " + DateTime.Now.ToString());

    foreach (var item in context.Request.Form)
    {
        Console.WriteLine(item);
    }

    foreach (var head in context.Request.Headers)
    {
        Console.WriteLine(head);
    }

    Console.WriteLine("");

    var code = new Random().Next(0, 100000);
    return new { code };
})
.Accepts<string>("application/x-www-form-urlencoded");

app.MapPut("/running", (HttpContext context) =>
{
    Thread.Sleep(5000);

    Console.WriteLine("");

    Console.WriteLine("running: " + DateTime.Now.ToString());

    foreach (var item in context.Request.Form)
    {
        Console.WriteLine(item);
    }

    foreach (var head in context.Request.Headers)
    {
        Console.WriteLine(head);
    }

    Console.WriteLine("");

    var code = new Random().Next(0, 100000);
    return new { code };
})
.Accepts<string>("application/x-www-form-urlencoded");

app.MapGet("/status", (HttpContext context) =>
{
    Thread.Sleep(5000);

    Console.WriteLine("");

    var res = (status % 5 == 0 ? 'F' : 'R');

    Console.WriteLine($"status[{status}]: {res} -" + DateTime.Now.ToString());

    foreach (var head in context.Request.Headers)
    {
        Console.WriteLine(head);
    }

    Console.WriteLine("");


    status++;

    return new { status = res };
});

app.MapPost("/logout", (HttpContext context) =>
{
    Thread.Sleep(5000);

    Console.WriteLine("");


    Console.WriteLine("logout: " + DateTime.Now.ToString());

    foreach (var item in context.Request.Form)
    {
        Console.WriteLine(item);
    }

    foreach (var head in context.Request.Headers)
    {
        Console.WriteLine(head);
    }

    Console.WriteLine("");

    return "";
})
.Accepts<string>("application/x-www-form-urlencoded");

app.Run();

