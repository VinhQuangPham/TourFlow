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
var app = builder.Build();
 

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
 