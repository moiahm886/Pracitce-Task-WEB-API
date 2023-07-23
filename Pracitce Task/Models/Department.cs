using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pracitce_Task.Models
{
    public class Department
    {
        public string Dname { get; set; }
        [Key]
        public int Dnumber { get; set; }
        [Column(TypeName = "char(9)")]
        public string Mgr_ssn { get; set; }
        public DateTime? Mgr_start_date { get; set; }
    }
}
