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
    public class Employes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int EmployeeCode { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Designation { get; set; }
        [Required]
        public int Department { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public int Salary { get; set; }


    }
}




