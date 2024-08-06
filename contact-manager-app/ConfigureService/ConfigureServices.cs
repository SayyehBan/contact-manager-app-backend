using contact_manager_app.Service.Interface;
using contact_manager_app.Service.Repository;

namespace contact_manager_app.ConfigureService;

public class ConfigureServices
{
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<RGroups>();
        services.AddTransient<RJobs>();
        services.AddTransient<RContacts>();
    }
}
