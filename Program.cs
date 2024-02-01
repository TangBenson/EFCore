using EFCore;
using EFCore.Repository;
using EFCore.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICrudService, CrudService>();
builder.Services.AddScoped<IRepository, Repository>();
//註冊efcore
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(@"Server=127.0.0.1,1433;Database=RentCarDB;User Id=sa;Password=Aa111111;TrustServerCertificate=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
