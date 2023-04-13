using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("TB_M_Educations")]
    public class Educations
    {
        [Key, Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("major", TypeName = "varchar(100)")]
        public string Major { get; set; }

        [Column("degree", TypeName = "varchar(10)")]
        public string Degree { get; set; }

        [Column("gpa", TypeName = "varchar(5)")]
        public string Gpa { get; set; }

        [Column("university_id", TypeName = "int")]
        public string UniversityId { get; set; }

        public Universities Universities { get; set; }
    }
}
