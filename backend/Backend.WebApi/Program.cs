using System.Text;
using Backend.Application.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Utilities;
using DotNetEnv;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Environment Variables

Env.Load();

var jwtSecretKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL")!;
var corsPolicy = bool.Parse(Environment.GetEnvironmentVariable("IS_IN_DEVELOPMENT")!) ? CorsPolicy.AllowAny : CorsPolicy.AllowFrontend;

#endregion

#region Services

builder.Services.AddControllers(o => o.Filters.Add<ExceptionFilter>());
builder.Services.AddControllers();
builder.Services.AddInfrastructure(new JwtConfig(jwtSecretKey, jwtIssuer, jwtAudience), connectionString, frontendUrl);
builder.Services.AddApplication();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
// builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseCors(corsPolicy.ToString());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();