using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "Enter Name in Capital letters only")]
        public string Name { get; set; }
    }
}
