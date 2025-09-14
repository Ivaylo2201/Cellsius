using System.Security.Claims;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Utilities;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, JwtConfig jwtConfig, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(contextOptionsBuilder =>
        {
            contextOptionsBuilder.UseSqlServer(
                connectionString,
                s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            
            services.AddJwtAuthentication(jwtConfig.Key, jwtConfig.Issuer, jwtConfig.Audience);
            services.AddCorsSupport();
        });
    }
    
    private static void AddJwtAuthentication(this IServiceCollection services, byte[] key, string issuer, string audience)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        
        services.AddAuthorization();
    }

    private static void AddCorsSupport(this IServiceCollection services)
    {
        Env.Load();
        
        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL")!;
        
        services.AddCors(o =>
        {
            o.AddPolicy(
                "AllowFrontend", 
                p => p.WithOrigins(frontendUrl).AllowAnyHeader().AllowAnyMethod());

            o.AddPolicy(
                "AllowAny", 
                p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }
}