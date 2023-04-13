using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("TB_TR_Profilings")]
    public class Profilings
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public char EmployeeNik { get; set; }

        [Column("education_id", TypeName = "int")]
        public int EducationId { get; set; }
    }
}
