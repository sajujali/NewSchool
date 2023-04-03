using NewSchool.Api.Student.Data;
using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Student.Interfaces;
using NewSchool.Api.Student.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentsProvider, StudentsProvider>();
builder.Services.AddDbContext<StudentApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentApiContext") ?? 
    throw new InvalidOperationException("Connection string 'StudentAPIContext' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
