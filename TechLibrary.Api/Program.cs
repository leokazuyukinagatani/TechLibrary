using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

// Adicionando injeção de dependência
builder.Services.AddApplication();

// Adicionando filtro para erros conhecidos
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
