namespace contact_manager_app.ConfigureService.Exceptions;

/// <summary>
/// استثنای سفارشی برای زمانی که مخاطب یافت نشود
/// </summary>
public class ContactNotFoundException : Exception
{
    /// <summary>
    /// ایجاد نمونه جدید از استثنای عدم یافتن مخاطب
    /// </summary>
    /// <param name="message">پیام خطا</param>
    public ContactNotFoundException(string message) : base(message) { }
}
