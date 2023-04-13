using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    [Table("TB_M_Accounts")]
    public class Accounts
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public char EmployeeNik { get; set; }

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set;}
    }
}
