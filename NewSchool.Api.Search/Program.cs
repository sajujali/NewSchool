using Microsoft.OpenApi.Services;
using NewSchool.Api.Search.Interfaces;
using NewSchool.Api.Search.Service;
using Microsoft.Extensions.Configuration;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("AssessmentService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Services:Assessments"));
});
builder.Services.AddHttpClient("SubjectService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Subjects"]);
    });
// Add services to the container.

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IAssessmentService, AssessmentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
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
