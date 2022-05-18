# API

## Installerade 
> dotnet new web -o DemoAPI
> cd DemoAPI

## La till Swagger
> dotnet add package Swashbuckle.AspNetCore

I koden efter var builder..
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

efter var app
app.UseSwagger();

innan app.run
app.UseSwaggerUI();
