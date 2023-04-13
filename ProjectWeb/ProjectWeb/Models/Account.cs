using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models
{
    [Table("TB_M_Accounts")]
    public class Account
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string EmployeeNik { get; set; }

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set;}

        public ICollection<AccountRole>? AccountRoles { get; set; }

        public Employee? Employees { get; set; }
    }
}
