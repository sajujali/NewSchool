using NewSchool.Api.Assessment.Interfaces;
using NewSchool.Api.Assessment.Providers;
using Microsoft.EntityFrameworkCore;
using NewSchool.Api.Assessment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAssessmentProvider, AssessmentProvider>();
builder.Services.AddDbContext<AssessmentApiContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("AssessmentApiContext") ??
    throw new InvalidOperationException("Connection string 'AssessmentApiContext' not found.")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
            builder =>
            {
                builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
            });
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
