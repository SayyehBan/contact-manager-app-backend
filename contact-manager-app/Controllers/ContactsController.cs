using contact_manager_app.ConfigureService.Exceptions;
using contact_manager_app.Model.Entities;
using contact_manager_app.Service.Repository;
using contact_manager_app.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using SayyehBanTools.ManageFile;

namespace contact_manager_app.Controllers;

/// <summary>
/// کنترلر برای مدیریت مخاطبین
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly RContacts rContacts;

    /// <summary>
    /// نمونه سازی جدید از کنترلر مخاطبین
    /// </summary>
    /// <param name="rContacts">مخزن مخاطبین</param>
    public ContactsController(RContacts rContacts)
    {
        this.rContacts = rContacts;
    }
    /// <summary>
    /// نمایش مخاطبین
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetContactAsync()
    {
        try
        {
            var contacts = await rContacts.GetContactsAsync();
            return new JsonResult(contacts);
        }
        catch (ContactNotFoundException)
        {
            return NotFound("مخاطبی یافت نشد");
        }
        catch (Exception)
        {
            // ثبت خطا
            return StatusCode(500, "خطای داخلی سرور");
        }
    }

    /// <summary>
    /// یافتن مخاطب با شناسه
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب برای جستجو</param>
    /// <returns>در صورت پیدا شدن مخاطب برگردانده می شود، در غیر این صورت NotFound</returns>
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
            return NotFound("مخاطبی یافت نشد");
        }
        catch (Exception)
        {
            // ثبت خطا
            return StatusCode(500, "خطای داخلی سرور\n");
        }
    }
    /// <summary>
    /// درج مخاطب جدید با تصویر آواتار
    /// </summary>
    /// <param name="Contacts">اطلاعات مخاطب و فایل برای آپلود</param>
    /// <returns>جزئیات مخاطب ایجاد شده</returns>
    [HttpPost]
    public async Task<IActionResult> InsertContact([FromForm] VMInsertContact Contacts)
    {
        if (Contacts.File?.File == null)
        {
            return Content("تصویر انتخاب نشده");
        }
        else
        {

            var basePath = AppConstants.BaseRoot + "Uploads/Avatars/";

            var file = Contacts.File!.File!;
            var newFilePath = await ManageFiles.UploadFileAsync(basePath, file);
            Contacts.Photo = newFilePath;


            var result = await rContacts.InsertContacts(Contacts);

            return new JsonResult(result);
        }
    }

    /// <summary>
    /// به روزرسانی مخاطب موجود و تصویر آواتار آن
    /// </summary>
    /// <param name="contact">اطلاعات به روز شده مخاطب و فایل جدید اختیاری</param>
    /// <returns>جزئیات مخاطب به روز شده</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateContact([FromForm] VMUpdateContact contact)
    {
        if (contact.File?.File == null)
        {
            contact.Photo = null;
            var newContact = await rContacts.UpdateContact(contact);
            return new JsonResult(newContact);
        }
        else
        {
            await ManageFiles.DeleteFileServer(AppConstants.BaseRoot + contact.Photo);

            var basePath = AppConstants.BaseRoot + "Uploads/Avatars/";
            var file = contact.File!.File!;
            var newFilePath = await ManageFiles.UploadFileAsync(basePath, file);
            contact.Photo = newFilePath;

            var newContact = await rContacts.UpdateContact(contact);
            return new JsonResult(newContact);
        }
    }
    /// <summary>
    /// حذف مخاطب و تصویر آواتار مرتبط با آن
    /// </summary>
    /// <param name="ContactID">شناسه مخاطب برای حذف</param>
    /// <returns>در صورت حذف موفق پیام موفقیت، در غیر این صورت NotFound</returns>
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
            return NotFound("مخاطبی یافت نشد");
        }
        catch (Exception)
        {
            // ثبت خطا
            return StatusCode(500, "خطای داخلی سرور");
        }

    }
}