using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using TourFlowBE.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.WithOrigins("http://localhost:5173") // Replace with your frontend URL
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

builder.Services.AddDbContext<TourFlowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5175, options =>
    {
        options.Protocols = HttpProtocols.Http1AndHttp2;
    });
});
 
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 5175, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2; 
    });
});
var app = builder.Build();
 

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
 