using contact_manager_app.ConfigureService.Exceptions;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Repository;
using contact_manager_app.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using SayyehBanTools.ManageFile;

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
    /// <summary>
    /// نمایش مخاطبین
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetContactsAsync()
    {
        try
        {
            var contacts = await rContacts.GetContactsAsync();
            return new JsonResult(contacts);
        }
        catch (ContactNotFoundException)
        {
            return NotFound("Contacts not found");
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> FindContactID(int ContactID)
    {
        try
        {
            var contacts = await rContacts.FindContactID(ContactID);
            if (contacts == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(contacts);
            }

        }
        catch (ContactNotFoundException)
        {
            return NotFound("Contacts not found");
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error\n" + ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> InsertContacts([FromForm] VMInsertContact Contacts)
    {
        if (Contacts.File.File == null)
        {
            return Content("تصویر انتخاب نشده");
        }
        else
        {

            var basePath = AppConstants.BaseRoot + "Uploads/Avatars/";

            var file = Contacts.File.File;
            var newFilePath = await ManageFiles.UploadFileAsync(basePath, file);
            Contacts.Photo = newFilePath;


            var newContact = await rContacts.InsertContacts(Contacts);

            var response = new VMGetContacts
            {
                ContactID = newContact,
                FirstName = Contacts.FirstName,
                LastName = Contacts.LastName,
                Photo = Contacts.Photo,
                Mobile = Contacts.Mobile,
                Email = Contacts.Email
            };
            return new JsonResult(response);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact([FromForm] VMUpdateContact contact)
    {
        if (contact.File == null)
        {
            contact.Photo = null;
            var newContact = await rContacts.UpdateContact(contact);
            return new JsonResult(newContact);
        }
        else
        {

            await ManageFiles.DeleteFileServer(AppConstants.BaseRoot + contact.Photo);

            var basePath = AppConstants.BaseRoot + "Uploads/Avatars/";
            var file = contact.File.File;
            var newFilePath = await ManageFiles.UploadFileAsync(basePath, file);
            contact.Photo = newFilePath;

            var newContact = await rContacts.UpdateContact(contact);
            return new JsonResult(newContact);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteContact([FromForm] int ContactID)
    {
        try
        {
            var contacts = await rContacts.DeleteContact(ContactID);
            if (contacts == null)
            {
                return NotFound();
            }
            else
            {
                await ManageFiles.DeleteFileServer(AppConstants.BaseRoot + contacts.Photo);
                return Content("حذف با موفیت انجام شد");
            }

        }
        catch (ContactNotFoundException)
        {
            return NotFound("Contacts not found");
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error");
        }

    }
}