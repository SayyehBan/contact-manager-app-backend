using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

public interface IJobs
{
    Task<IEnumerable<VMJobs>> GetJobAsync();
}
