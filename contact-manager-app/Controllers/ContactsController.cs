using contact_manager_app.Service.Model;
using contact_manager_app.Service.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contact_manager_app.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly RContacts rContacts;

    public ContactsController(RContacts rContacts)
    {
        this.rContacts = rContacts;
    }
    [HttpGet]
    public async Task<IEnumerable<VMGetContacts>> GetContactsAsync()
    {
        return await rContacts.GetContactsAsync();
    }
    [HttpPost]
    public async Task<IActionResult> InsertContacts([FromForm] VMInsertContacts insertContacts)
    {
        var newContact = await rContacts.InsertContacts(insertContacts);
        var response = new VMGetContacts
        {

            ContactID = newContact,
            FirstName = insertContacts.FirstName,
            LastName = insertContacts.LastName,
            Photo = insertContacts.Photo,
            Mobile = insertContacts.Mobile,
            Email = insertContacts.Email
};
        return new JsonResult(response);
    }
}
