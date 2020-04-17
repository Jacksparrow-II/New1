using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using New1.Models;


namespace New1.Repository
{
    public class DepartmentRepo
    {
        public List<Department> GetDepartment()
        {
                SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
                List<Department> s2 = new List<Department>();

                SqlDataAdapter sa = new SqlDataAdapter("ListDepartment", sc);
                DataTable dt = new DataTable();
                sa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sc.Open();
                sa.Fill(dt);
                sc.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    s2.Add(
                        new Department
                        {
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                            DepartmentName = Convert.ToString(dr["DepartmentName"]),
                        }
                        );
                    
                }
                return s2;
        }
    }
}
