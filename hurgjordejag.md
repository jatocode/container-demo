# API

## Installerade 
> dotnet new web -o DemoAPI
> dotnew new gitignore
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

# FrontEnd

## Installerade

 > npx create-react-app client --template typescript

## Ändrade lite kod i App.tsx

Hämtade data från min backend

## cors-fel så la till i API:
builder.Services.AddCors();

app.UseCors(c => c.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

## react strict.mode runt app gjorde att det renderades dubbelt

# Docker

## API

La till Dockerfile manuellt
Pekar på min DLL
docker build -t api:latest .
docker run -p 5111:80 api:latest

## Client

La till Dockerfile manuellt
docker build -t frontend:latest .

docker run -p 3000:3000 client:latest
