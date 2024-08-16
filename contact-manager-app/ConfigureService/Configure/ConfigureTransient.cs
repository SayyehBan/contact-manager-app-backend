using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Repository;

namespace contact_manager_app.ConfigureService.Configure;

public class ConfigureTransient
{
    public void ConfigureTransients(IServiceCollection services)
    {
        services.AddTransient<RGroups>();
        services.AddTransient<RJobs>();
        services.AddTransient<RContacts>();
    }
}
