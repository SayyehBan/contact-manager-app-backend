using Microsoft.OpenApi.Models;

namespace contact_manager_app.ConfigureService.Extentions;

/// <summary>
/// کلاس افزودنی برای پیکربندی Swagger
/// </summary>
public static class SwaggerExtention
{
    /// <summary>
    /// افزودن و پیکربندی Swagger به سرویس‌ها
    /// </summary>
    /// <param name="services">کالکشن سرویس‌ها</param>
    /// <returns>کالکشن سرویس‌های به‌روز شده</returns>
    public static IServiceCollection AddOurSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // افزودن فایل توضیحات XML به Swagger
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Contacs.xml"), true);

            // تنظیم اطلاعات اصلی API
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1", // نسخه API
                Title = "API", // عنوان API
                Description = "Web API SayyehBan.ir", // توضیحات API
                Contact = new OpenApiContact() // اطلاعات تماس
                {
                    Name = "سایه بان",
                    Url = new Uri("http://sayyehban.ir/")
                }
            });

            // تنظیمات امنیتی برای احراز هویت JWT
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = // توضیحات نحوه استفاده از توکن
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization", // نام هدر مجوز
                In = ParameterLocation.Header, // محل قرارگیری در هدر
                Type = SecuritySchemeType.Http, // نوع طرح امنیتی
                Scheme = "bearer", // طرح Bearer
                Reference = new OpenApiReference // ارجاع به تعریف امنیتی
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            // افزودن تعریف امنیتی به Swagger
            c.AddSecurityDefinition("Bearer", securitySchema);

            // اعمال نیازمندی‌های امنیتی
            var securityRequirement = new OpenApiSecurityRequirement();
            securityRequirement.Add(securitySchema, new[] { "Bearer" });
            c.AddSecurityRequirement(securityRequirement);
        });
        return services;
    }
}
