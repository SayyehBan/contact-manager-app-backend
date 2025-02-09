namespace contact_manager_app.Model.Entities;

/// <summary>
/// کلاس پاسخ عمومی API برای بازگرداندن نتایج
/// </summary>
/// <typeparam name="T">نوع داده‌ای که در پاسخ برگردانده می‌شود</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// نشان‌دهنده موفقیت یا شکست عملیات
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// داده‌های برگشتی از عملیات
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// پیام توضیحی عملیات
    /// </summary>
    public string? Message { get; set; }
}
