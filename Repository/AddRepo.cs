using Microsoft.Data.SqlClient;
using New1.Models;
using System;

namespace New1.Repository
{
    public class AddRepo
    {
        public bool AddEmp(Employes st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cd = new SqlCommand("AddEmployee", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Name", st.Name);
                cd.Parameters.AddWithValue("@Email", st.Email);
                cd.Parameters.AddWithValue("@EmployeeCode", st.EmployeeCode);
                cd.Parameters.AddWithValue("@Gender", st.Gender);
                cd.Parameters.AddWithValue("@Designation", st.Designation);
                cd.Parameters.AddWithValue("@Department", st.Department);
                cd.Parameters.AddWithValue("@DOB", st.DOB);
                cd.Parameters.AddWithValue("@Salary", st.Salary);
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
    }
}
