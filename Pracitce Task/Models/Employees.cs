using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pracitce_Task.Models
{
    public class Employees
    {
        public string Fname { get; set; }
        [Column(TypeName = "char(1)")]
        public string? Minit { get; set; }
        public string Lname { get; set; }
        [Key]
        [Column(TypeName = "char(9)")]
        public string Ssn { get; set; }
        public DateTime Bdate { get; set; }
        public string? Address { get; set; }
        [Column(TypeName = "char(1)")]
        public string? Sex { get; set; }
        public decimal Salary { get; set; }
        [Column(TypeName = "char(9)")]
        public string? Super_ssn { get; set; }

        public int Dno { get; set; }

    }

}
