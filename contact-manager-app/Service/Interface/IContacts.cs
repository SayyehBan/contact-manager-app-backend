using contact_manager_app.Service.Model;

namespace contact_manager_app.Service.Interface;

public interface IContacts
{
    Task<IEnumerable<VMGetContacts>> GetContactsAsync();
    Task<int> InsertContacts(VMInsertContacts contact);
}
