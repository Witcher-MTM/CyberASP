using System.Data.SqlClient;

namespace CyberASP
{
    public class ConnectDataBase
    {
        public static SqlConnection conn { get; set; }
        public static bool isConnect { get; set; }
        public static bool Connect()
        {
            if (conn == null)
            {
                conn = new SqlConnection("Data Source=SQL5102.site4now.net;Initial Catalog=db_a838e6_gray;User Id=db_a838e6_gray_admin;Password=qwerty20039");
            }
            isConnect = false;
            try
            {
                if (!isConnect)
                {
                    conn.Open();

                }
                isConnect = true;
            }
            catch (System.Exception)
            {
                isConnect = false;
            }
            return isConnect;
        }
    }
}
