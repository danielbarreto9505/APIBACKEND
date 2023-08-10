using Microsoft.EntityFrameworkCore;
using APIBACKEND.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PruebafiContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
builder.Services.AddControllers();

var app = builder.Build();

// Enable CORS (Cross-Origin Resource Sharing)
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();
app.Run();


