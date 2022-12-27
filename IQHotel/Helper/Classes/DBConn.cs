
namespace IQHotel.Helper
{
    public enum ConnectionType
    {
        SqlServerLocal,
        SqlServerSmarter
    }

    public static class DBConn
    {
        public static readonly ConnectionType ConnectionType = ConnectionType.SqlServerLocal;

        public static string ConnectionString
        {
            get
            {
                return ConnectionType switch
                {
                    ConnectionType.SqlServerLocal => "Server=DESKTOP-SNJ5UHC; Database=IqHotel; Trusted_Connection=True ;TrustServerCertificate=True;",

                    ConnectionType.SqlServerSmarter => "",

                    _ => "",
                };
            }
        }
    }
}