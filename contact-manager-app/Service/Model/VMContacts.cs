namespace contact_manager_app.Service.Model;

public class VMGetContacts
{
    public int ContactID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Photo { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }
    public string GroupTitle { get; set; }
}
public class VMInsertContacts
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Photo { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public int JobID { get; set; }
    public int GroupID { get; set; }
}
