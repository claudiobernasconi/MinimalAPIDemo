var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/sum", (int? n1, int? n2) => n1 + n2);

app.Run();
