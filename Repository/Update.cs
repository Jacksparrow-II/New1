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
    public class Update
    {
        public bool UpdateEmp(Employes st)
        {
            try
            {
                SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); SqlCommand cd = new SqlCommand("UpdateEmployee", sc);
                cd.CommandType = System.Data.CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Id", st.Id);
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
