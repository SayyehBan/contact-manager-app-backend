namespace contact_manager_app.Model.Entities
{
    /// <summary>
    /// کلاس مدل برای آپلود فایل
    /// </summary>
    public class UploadFile
    {
        /// <summary>
        /// فایل آپلود شده
        /// </summary>
        public IFormFile? File { get; set; }
    }
}
