using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("TB_M_Universities")]
    public class Universities
    {
        [Key, Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        public ICollection<Educations> Educations { get; set; }
    }
}
