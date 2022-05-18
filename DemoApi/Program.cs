
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

app.UseSwagger();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Fryken", () => {
    return Results.Json("Fryken");
});
app.MapGet("/Gapern", () => "Gapern");

app.UseSwaggerUI();

app.Run();
