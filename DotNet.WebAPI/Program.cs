using DotNet.WebAPI.Utility;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//var schoolSettings = new SchoolSettings();
//builder.Configuration.GetSection("SchoolSettings").Bind(schoolSettings);
//builder.Services.AddSingleton(schoolSettings);
builder.Services.Configure<SchoolSettings>(builder.Configuration.GetSection("SchoolSettings"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Swagger Demo"));
//app.UseSwaggerUI //(o=>o.swa Endpoints("/openapi/v1.json","Swagger Demo");
app.UseAuthorization();

app.MapControllers();

app.Run();
