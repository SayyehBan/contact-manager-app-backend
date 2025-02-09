using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Repository;

namespace contact_manager_app.ConfigureService.Configure;

/// <summary>
/// کلاس پیکربندی سرویس‌های موقت
/// </summary>
public class ConfigureTransient
{
    /// <summary>
    /// پیکربندی سرویس‌های موقت در کانتینر DI
    /// </summary>
    /// <param name="services">کالکشن سرویس‌ها</param>
    public void ConfigureTransients(IServiceCollection services)
    {
        services.AddTransient<RGroups>();
        services.AddTransient<RJobs>();
        services.AddTransient<RContacts>();
    }
}
