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

namespace New1.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string empcode { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public string position { get; set; }
        
        public bool Addemp(Employee st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

                SqlCommand cd = new SqlCommand("AddEmployee", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Name", st.Name);
                cd.Parameters.AddWithValue("@Position", st.position);
                cd.Parameters.AddWithValue("@empcode", st.empcode);
                cd.Parameters.AddWithValue("@salary", st.Salary);
                sc.Open();
                bool isExecute = Convert.ToBoolean(cd.ExecuteNonQuery());
                sc.Close();
                return isExecute;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }


        public List<Employee> Getemp()
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

        public bool Updateemp(Employee st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
                SqlCommand cd = new SqlCommand("UpdateEmployee", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Id", st.Id);
                cd.Parameters.AddWithValue("@Name", st.Name);
                cd.Parameters.AddWithValue("@Position", st.position);
                cd.Parameters.AddWithValue("@empcode", st.empcode);
                cd.Parameters.AddWithValue("@salary", st.Salary);
                sc.Open();
                bool isExecute = Convert.ToBoolean(cd.ExecuteNonQuery());
                sc.Close();
                return isExecute;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

      
        public bool Deleteemp(int ID)
        {
            SqlConnection sc = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = work; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cd = new SqlCommand("DeleteEmp", sc);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@Id", ID);
            sc.Open();
            int isExecute = cd.ExecuteNonQuery();
            sc.Close();
            if (isExecute>=1)
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
