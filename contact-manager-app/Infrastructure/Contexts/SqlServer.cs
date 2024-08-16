using System.Data.SqlClient;

namespace contact_manager_app.Infrastructure.Contexts;

public class SqlServer
{
    public static string ConnectionString()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = ".";
        builder.InitialCatalog = "ContactDB";
        builder.UserID = "TestConnection";
        builder.Password = "@123456";
        builder.ConnectTimeout = 0;
        builder.MaxPoolSize = 20000;
        builder.IntegratedSecurity = false;
        builder.TrustServerCertificate = true;
        return builder.ConnectionString.ToString();
    }
}
