using FinShark.API.Helpers;

namespace FinShark.API.Configuration;

public static class DateTimeConfiguration
{
    public static WebApplicationBuilder ConfigureDateTimeProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return builder;
    }
}