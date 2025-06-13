using FinShark.API.Swagger.Examples;
using Swashbuckle.AspNetCore.Filters;

namespace FinShark.API.Configuration;

public static class Swagger
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(config =>
        {
            config.EnableAnnotations();
            config.ExampleFilters();
        });

        builder.Services.AddSwaggerExamplesFromAssemblyOf<UserLoginDtoExample>();


        return builder;
    }
}