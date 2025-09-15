using System.Security.Claims;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, JwtConfig jwtConfig, string connectionString, string frontendUrl)
    {
        services.AddDbContext<DatabaseContext>(contextOptionsBuilder =>
        {
            contextOptionsBuilder.UseSqlServer(connectionString, s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            services.AddJwtAuthentication(jwtConfig.Key, jwtConfig.Issuer, jwtConfig.Audience);
            services.AddCorsSupport(frontendUrl);
        });
    }
    
    private static void AddJwtAuthentication(this IServiceCollection services, byte[] key, string issuer, string audience)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
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

    private static void AddCorsSupport(this IServiceCollection services, string frontendUrl)
    {
        services.AddCors(corsOptions =>
        {
            corsOptions.AddPolicy(nameof(CorsPolicy.AllowFrontend), p => p.WithOrigins(frontendUrl).AllowAnyHeader().AllowAnyMethod());
            corsOptions.AddPolicy(nameof(CorsPolicy.AllowAny), p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }
}