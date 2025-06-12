using System.Text;
using FinShark.API.Data;
using FinShark.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FinShark.API.Configuration;

public static class Identity
{
    public static WebApplicationBuilder UseIdentity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 12;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        var jwtSettings = builder.Configuration.GetRequiredSection("JWT").Get<JwtSettings>() ??
                          throw new InvalidOperationException("Invalid JWT configuration");

        builder.Services.AddSingleton(jwtSettings);

        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    options.DefaultChallengeScheme =
                        options.DefaultForbidScheme =
                            options.DefaultScheme =
                                options.DefaultSignInScheme =
                                    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey))
                };
            });

        return builder;
    }
}

public record JwtSettings
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SigningKey { get; init; }

    public JwtSettings(string issuer, string audience, string signingKey)
    {
        ArgumentException.ThrowIfNullOrEmpty(issuer);
        ArgumentException.ThrowIfNullOrEmpty(audience);
        ArgumentException.ThrowIfNullOrEmpty(signingKey);

        Issuer = issuer;
        Audience = audience;
        SigningKey = signingKey;
    }
}