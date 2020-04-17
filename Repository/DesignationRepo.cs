using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using New1.Models;

namespace New1.Repository
{
    public class DesignationRepo
    {
        public List<Designation> GetDesignation()
        {
                SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                List<Designation> s2 = new List<Designation>();


                SqlDataAdapter sa = new SqlDataAdapter("ListDesignation", sc);
                DataTable dt = new DataTable();
                sa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sc.Open();
                sa.Fill(dt);
                sc.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    s2.Add(
                        new Designation
                        {
                            DesignationId = Convert.ToInt32(dr["DesignationId"]),
                            DesignationName = Convert.ToString(dr["DesignationName"]),
                        }
                        );
                }
                return s2;
            
        }
    }
}
