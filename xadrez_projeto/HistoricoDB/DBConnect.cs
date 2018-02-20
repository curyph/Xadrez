using System;
using System.Data.SqlClient;


namespace xadrez
{
    public static class DBConnect
    {
        public static SqlConnection myConnection = new SqlConnection("user id=sa;" +
                                      "password=l4p1s;server=LNV\\SQLFGA;" +
                                      "Trusted_Connection=no;" +
                                      "database=Chess; " +
                                      "connection timeout=15");
    }
}
