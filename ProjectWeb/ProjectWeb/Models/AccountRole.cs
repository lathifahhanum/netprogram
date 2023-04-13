using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWeb.Models
{
    [Table("TB_TR_AccountRoles")]
    public class AccountRole
    {
        [Key, Column("id", TypeName = "int")]
        public int Id { get; set; }
        
        [Column("account_nik", TypeName = "char(5)")]
        public string AccountNik { get; set; }

        [Column("role_id", TypeName = "int")]
        public int RoleId { get; set; }

        public Role? Roles { get; set; }
        public Account? Accounts { get; set; }
    }
}
