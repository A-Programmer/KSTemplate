﻿using KSFramework.GenericRepository;
using KSProject.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KSProject.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<KSProjectDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"),
                x =>
                    x.MigrationsAssembly("KSProject.Infrastructure"));
        });
        services.AddScoped<DbContext, KSProjectDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<KSProjectDbContext>();
        context.Database.Migrate();
        
        return app;
    }
}