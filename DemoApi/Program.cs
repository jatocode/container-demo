using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddCors();

var app = builder.Build();

// Kör vi i Kuberbetes behöver vi inte CORS
// app.UseCors(c => c.AllowAnyHeader()
//         .AllowAnyMethod()
//         .SetIsOriginAllowed(origin => true)
//         .AllowCredentials());

app.UseSwagger();

var host = Dns.GetHostEntry(Dns.GetHostName());
var ip = host.AddressList.FirstOrDefault(x => 
    x.AddressFamily == AddressFamily.InterNetwork && !x.ToString().StartsWith("127"));


int i = 0;
app.MapGet("/api/ipaddress", () =>
{
    return Results.Json(ip?.ToString());
});
app.MapGet("/api/data", () => i++.ToString());

app.MapGet("/api/crash", () => {
    // Exit application with code 1
    Environment.Exit(1);
});


app.UseSwaggerUI();

app.Run();

