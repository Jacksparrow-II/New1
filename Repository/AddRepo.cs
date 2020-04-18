using Microsoft.Data.SqlClient;
using New1.Models;
using System;
using System.Data;
using System.Collections.Generic;

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

        public List<Employes> GetEmp()
        {
            SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); List<Employes> s2 = new List<Employes>();

            SqlDataAdapter sa = new SqlDataAdapter("Getemployee", sc);
            DataTable dt = new DataTable();
            sa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sc.Open();
            sa.Fill(dt);
            sc.Close();
            foreach (DataRow dr in dt.Rows)
            {
                s2.Add(
                    new Employes
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        EmployeeCode = Convert.ToInt32(dr["EmployeeCode"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Designation = Convert.ToInt32(dr["Designation"]),
                        DesignationName = Convert.ToString(dr["DesignationName"]),
                        Department = Convert.ToInt32(dr["Department"]),
                        DepartmentName = Convert.ToString(dr["DepartmentName"]),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        Salary = Convert.ToInt32(dr["Salary"]),
                    }
                    );
            }
            return s2;
        }

        public bool DeleteEmp(int ID)
        {
            SqlConnection sc = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); SqlCommand cd = new SqlCommand("DeleteEmployee", sc);
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
