using FCG.Application;
using FCG.Application.Configuration;
using FCG.Infrastructure;
using FCG.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FCG.Application.Validators.Jogos;
using System.Text.Json.Serialization;
using FCG.Presentation.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(
                namingPolicy: null,
                allowIntegerValues: true));
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<EnumSchemaFilter>();
});
// Adiciona validação automática usando FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CriarJogoValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<FcgDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();