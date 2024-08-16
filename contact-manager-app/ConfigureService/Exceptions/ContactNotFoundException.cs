namespace contact_manager_app.ConfigureService.Exceptions;

public class ContactNotFoundException : Exception
{
    public ContactNotFoundException(string message) : base(message) { }
}
