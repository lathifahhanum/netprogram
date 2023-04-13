using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models
{
    [Table("TB_TR_Profilings")]
    public class Profiling
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string EmployeeNik { get; set; }

        [Column("education_id", TypeName = "int")]
        public int EducationId { get; set; }
        public Education? Educations { get; set; }
        public Employee? Employees { get; set; }
    }
}
