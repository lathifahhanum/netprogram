using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("TB_M_Employees")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Employees
    {
        [Key, Column("nik", TypeName = "char(5)")]
        public char Nik { get; set; }

        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(50)")]
        public string? LastName { get; set; }

        [Column("birthdate", TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        [Column("gender")]
        public Gender Gender { get; set; }

        [Column("hiring_date", TypeName = "datetime")]
        public DateTime HiringDate { get; set; }
        
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column("phone_number", TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }
}
