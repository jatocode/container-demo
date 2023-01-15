using System.Net;
using System.Net.Sockets;

// DemoAPI

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials());

// Lite demo-data
var host = Dns.GetHostEntry(Dns.GetHostName());
var ip = host.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork && !x.ToString().StartsWith("127")) ?? new IPAddress(0);
int i = 0;

// Endpoints
app.MapGet("/api/ipaddress", () => ip.ToString() );
app.MapGet("/api/data", () => i++.ToString("X4") );
app.MapGet("/api/crash", () => { Environment.Exit(1); });
app.MapGet("/alive", () => true );

app.Run();

