using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models
{
    [Table("TB_M_Educations")]
    public class Education
    {
        [Key, Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("major", TypeName = "varchar(100)")]
        public string Major { get; set; }

        [Column("degree", TypeName = "varchar(10)")]
        public string Degree { get; set; }

        [Column("gpa", TypeName = "decimal(3,2)")]
        public double Gpa { get; set; }

        [Column("university_id", TypeName = "int")]
        public int UniversityId { get; set; }

        public University? Universities { get; set; }
        public Profiling? Profilings { get; set; }
    }
}
