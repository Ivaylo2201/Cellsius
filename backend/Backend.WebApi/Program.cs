using System.Text;
using Backend.Application.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Utilities;
using DotNetEnv;
using FluentValidation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var jwtSecretKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
var isInDevelopment = bool.Parse(Environment.GetEnvironmentVariable("IS_IN_DEVELOPMENT")!);

builder.Services.AddControllers(o => o.Filters.Add<ExceptionFilter>());
builder.Services.AddControllers();
builder.Services.AddInfrastructure(new JwtConfig(jwtSecretKey, jwtIssuer, jwtAudience), connectionString);
builder.Services.AddOpenApi();
builder.Services.AddApplication();
// builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseCors(isInDevelopment ? "AllowAny" : "AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();