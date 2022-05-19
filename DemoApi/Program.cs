
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

int i = 0;
app.MapGet("/Fryken", () => {
    return Results.Json("Fryken " + i++);
});
app.MapGet("/Gapern", () => "Gapern");

app.UseSwaggerUI();

app.Run();
