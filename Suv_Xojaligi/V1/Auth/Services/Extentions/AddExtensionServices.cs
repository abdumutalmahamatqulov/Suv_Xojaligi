using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Suv_Xojaligi.V1.Auth.Services.AuthServices;
using Suv_Xojaligi.V1.Auth.Services.Interfaces;
using Suv_Xojaligi.V1.Auth.TokenGenerators;
using Suv_Xojaligi.V1.FileMetadataFolder.Repositories;
using Suv_Xojaligi.V1.FileMetadataFolder.Repositories.Interfaces;
using Suv_Xojaligi.V1.FileMetadataFolder.Services;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces;

namespace Suv_Xojaligi.V1.Auth.Services.Extentions;

public static class AddExtensionServices
{
    public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IMonitoringRepository, MonitoringRepository>();
        services.AddScoped<IMonitoringService, MonitoringService>();

        services.AddScoped<IFileMetadataRepository, FileMetadataRepository>();
        services.AddScoped<IFileMetadataService, FileMetadataService>();

        services.AddScoped<IAppealRepository, AppealRepository>();
        services.AddScoped<IAppealService, AppealService>();

        services.AddScoped<IEfficiencyRepository, EfficiencyRepository>();
        services.AddScoped<IEfficiencyService, EfficiencyService>();

        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IReportService, ReportService>();
        return services;
    }
    public static void AddSwaggerService(
    this IServiceCollection services,
    IConfiguration configuration
)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        services.AddSwaggerGen(p =>
        {
            p.ResolveConflictingActions(ad => ad.First());
            p.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                }
            );
            p.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                }
            );
        });

        services
            .AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])
                    )
                };
            });
    }
}
