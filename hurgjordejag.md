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