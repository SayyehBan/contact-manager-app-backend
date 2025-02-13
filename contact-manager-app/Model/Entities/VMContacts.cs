namespace contact_manager_app.Model.Entities;

/// <summary>
/// مدل نمایش اطلاعات مخاطب برای دریافت
/// </summary>
public class VMGetContacts
{
    /// <summary>
    /// شناسه مخاطب
    /// </summary>
    public int ContactID { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// مسیر تصویر
    /// </summary>
    public string? Photo { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// عنوان شغل
    /// </summary>
    public string? JobTitle { get; set; }

    /// <summary>
    /// عنوان گروه
    /// </summary>
    public string? GroupTitle { get; set; }

    /// <summary>
    /// شناسه شغل
    /// </summary>
    public int JobID { get; set; }

    /// <summary>
    /// شناسه گروه
    /// </summary>
    public int GroupID { get; set; }
}

/// <summary>
/// مدل پایه برای عملیات‌های مخاطب
/// </summary>
public class VMContacts
{
    /// <summary>
    /// نام
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// مسیر تصویر
    /// </summary>
    public string? Photo { get; set; }

    /// <summary>
    /// فایل آپلودی
    /// </summary>
    public UploadFile? File { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شناسه شغل
    /// </summary>
    public int JobID { get; set; }

    /// <summary>
    /// شناسه گروه
    /// </summary>
    public int GroupID { get; set; }
}

/// <summary>
/// مدل جستجوی مخاطب با شناسه
/// </summary>
public class VMFindContactID : VMGetContacts
{
    /// <summary>
    /// شناسه شغل
    /// </summary>
    public new int JobID { get; set; }

    /// <summary>
    /// شناسه گروه
    /// </summary>
    public new int GroupID { get; set; }
}

/// <summary>
/// مدل درج مخاطب جدید
/// </summary>
public class VMInsertContact : VMContacts
{
}

/// <summary>
/// مدل به‌روزرسانی مخاطب
/// </summary>
public class VMUpdateContact : VMContacts
{
    /// <summary>
    /// شناسه مخاطب
    /// </summary>
    public int ContactID { get; set; }
}

/// <summary>
/// مدل حذف مخاطب
/// </summary>
public class VMDeleteContact
{
    /// <summary>
    /// مسیر تصویر مخاطب برای حذف
    /// </summary>
    public string? Photo { get; set; }
}