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
using New1.Models;

namespace New1.Repository
{
    public class List
    {
        public List<Employee> GetEmp()
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            List<Employee> s2 = new List<Employee>();

            SqlDataAdapter sa = new SqlDataAdapter("Getemployee", sc);
            DataTable dt = new DataTable();
            sa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sc.Open();
            sa.Fill(dt);
            sc.Close();
            foreach (DataRow dr in dt.Rows)
            {
                s2.Add(
                    new Employee
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        position = Convert.ToString(dr["position"]),
                        empcode = Convert.ToString(dr["empcode"]),
                        Salary = Convert.ToString(dr["Salary"]),
                    }
                    );
            }
            return s2;
        }
    }
}
