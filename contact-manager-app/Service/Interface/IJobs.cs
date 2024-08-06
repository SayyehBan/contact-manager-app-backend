using contact_manager_app.Service.Model;

namespace contact_manager_app.Service.Interface;

public interface IJobs
{
    Task<IEnumerable<VMJobs>> GetJobAsync();
}
