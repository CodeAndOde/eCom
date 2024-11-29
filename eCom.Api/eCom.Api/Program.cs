using eCom.Api.Middleware;
using eCom.eCom.Core;
using eCom.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
