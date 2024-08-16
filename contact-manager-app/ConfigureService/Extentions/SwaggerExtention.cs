using Microsoft.OpenApi.Models;

namespace contact_manager_app.ConfigureService.Extentions;

public static class SwaggerExtention
{
    public static IServiceCollection AddOurSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Contacs.xml"), true);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API",
                Description = "Web API SayyehBan.ir",
                Contact = new OpenApiContact()
                {
                    Name = "سایه بان",
                    Url = new Uri("http://sayyehban.ir/")
                }
            });
            var securitySchema = new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement();
            securityRequirement.Add(securitySchema, new[] { "Bearer" });
            c.AddSecurityRequirement(securityRequirement);
        });
        return services;
    }
}
