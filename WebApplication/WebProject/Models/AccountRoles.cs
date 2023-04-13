using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    [Table("TB_TR_AccountRoles")]
    public class AccountRoles
    {
        [Key, Column("id", TypeName = "int")]
        public int Id { get; set; }
        
        [Column("account_nik", TypeName = "char(5)")]
        public string AccountNik { get; set; }

        [Column("role_id", TypeName = "int(11)")]
        public string RoleId { get; set; }
    }
}
