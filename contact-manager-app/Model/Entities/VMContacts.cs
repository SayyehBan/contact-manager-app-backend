namespace contact_manager_app.Model.Entities;

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
public class VMContacts
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Photo { get; set; }
    public UploadFile File { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public int JobID { get; set; }
    public int GroupID { get; set; }
}
public class VMFindContactID : VMGetContacts
{
    public int JobID { get; set; }
    public int GroupID { get; set; }
}

public class VMInsertContact : VMContacts
{
}
public class VMUpdateContact : VMContacts
{
    public int ContactID { get; set; }
}
public class VMDeleteContact
{
    public string Photo { get; set; }
}