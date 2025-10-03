using System.Security.Claims;
using Application.Interfaces.Services;
using Core.Interfaces.Repositories;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Services;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, JwtConfig jwtConfig, string connectionString)
    {
        services
            .AddScoped<IItemRepository, ItemRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IShippingRepository, ShippingRepository>()
            .AddScoped<IModelRepository, ModelRepository>()
            .AddScoped<IBrandRepository, BrandRepository>()
            .AddScoped<IColorRepository, ColorRepository>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IOwnershipService, OwnershipService>()
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddSingleton<ITokenService, TokenService>()
            .AddDbContext<DatabaseContext>(d =>
            {
                d.UseSqlServer(connectionString,
                    s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            })
            .AddCorsSupport()
            .AddJwtAuthentication(jwtConfig.Key, jwtConfig.Issuer, jwtConfig.Audience);
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

    private static IServiceCollection AddCorsSupport(this IServiceCollection services)
    {
        return services.AddCors(o =>
        {
            o.AddPolicy(
                "AllowFrontend", 
                p => p.WithOrigins("http://localhost:5173/").AllowAnyHeader().AllowAnyMethod());

            o.AddPolicy(
                "AllowAny", 
                p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
    }
}