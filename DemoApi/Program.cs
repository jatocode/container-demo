using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Fryken", () => "Fryken endpoint");
app.MapGet("/Gapern", () => "Gapern endpoint");

app.UseSwaggerUI();

app.Run();
