using contact_manager_app.Model.Entities;

namespace contact_manager_app.Service.Interface;

public interface IContacts
{
    Task<IEnumerable<VMGetContacts>> GetContactsAsync();
    Task<VMFindContactID> FindContactID(int ContactID);
    Task<int> InsertContacts(VMInsertContact contact);
    Task<VMFindContactID> UpdateContact(VMUpdateContact contact);
    Task<VMDeleteContact> DeleteContact(int ContactID);
}
