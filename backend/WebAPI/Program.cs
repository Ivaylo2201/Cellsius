using System.Text;
using Application;
using Application.CQRS.Users.Validators;
using DotNetEnv;
using FluentValidation;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.Database.Seed;
using Infrastructure.Utilities;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var jwtSecretKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
var isInDevelopment = bool.Parse(Environment.GetEnvironmentVariable("IS_IN_DEVELOPMENT")!);

builder.Services.AddControllers(o => o.Filters.Add<ExceptionFilter>());
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(new JwtConfig(jwtSecretKey, jwtIssuer, jwtAudience), connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

if (args.Contains("seed"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    var seeder = new Seeder(context);
    await seeder.Run();
    return;
}

app.UseRouting();
app.UseCors(isInDevelopment ? "AllowAny" : "AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();