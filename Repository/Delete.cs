using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Xunit;

namespace New1.Repository
{
    public class Delete
    {
        public bool DeleteEmp(int ID)
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cd = new SqlCommand("DeleteEmp", sc);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@Id", ID);
            sc.Open();
            int isExecute = cd.ExecuteNonQuery();
            sc.Close();
            if (isExecute >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
