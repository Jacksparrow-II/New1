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
        
        
    }
}
