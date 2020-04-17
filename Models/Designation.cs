using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace New1.Models
{
    public class Designation
    {
        
        [Key]
        public int DesignationId { get; set; }
        [Required]
        public string DesignationName { get; set; }
    }
}
