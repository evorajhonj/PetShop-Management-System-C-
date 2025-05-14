using System;
using System.Data;
using System.Data.SqlClient;

namespace System_Evora_Group
{
    internal class Database
    {
        DataTable dTable;
        SqlDataAdapter sqlDA;
        SqlCommand sqlCmd;
        SqlConnection sqlCon;
        string conStr;

        public Database()
        {
            conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\evora\source\repos\System_Evora_Group\PetShopDb.mdf;Integrated Security=True";
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
        }

           
        public int cudCMD(string sql)
        {
            sqlCmd = new SqlCommand(sql, sqlCon);
            return sqlCmd.ExecuteNonQuery();
        }
        public DataTable selectCmd(string sql)
        {
            dTable = new DataTable();
            sqlDA = new SqlDataAdapter(sql, conStr);
            sqlDA.Fill(dTable);
            sqlDA.Dispose();
            return dTable;
        }

    }
}
