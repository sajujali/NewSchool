using NewSchool.Api.Subject.Data;
using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Subject.Interfaces;
using NewSchool.Api.Subject.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SubjectApiContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectApiContext") ??
    throw new InvalidOperationException("Connection string 'StudentAPIContext' not found.")));
builder.Services.AddScoped<ISubjectProvider, SubjectProvider>();

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
