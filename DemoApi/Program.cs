// DemoAPI

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Lite demo-data
var host = Dns.GetHostEntry(Dns.GetHostName());
var ip = host.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork && !x.ToString().StartsWith("127")) ?? new IPAddress(0);
int i = 0;

// Endpoints
app.MapGet("/api/ipaddress", () => ip.ToString() );
app.MapGet("/api/data", () => i++.ToString() );
app.MapGet("/api/crash", () => { Environment.Exit(1); });

app.Run();

