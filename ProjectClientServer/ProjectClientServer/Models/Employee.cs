using System;
using System.Collections.Generic;

namespace ProjectClientServer.Models;

public partial class Employee
{
    public string Nik { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime Birthdate { get; set; }

    public int Gender { get; set; }

    public DateTime HiringDate { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual Account? TbMAccount { get; set; }

    public virtual Profiling? TbTrProfiling { get; set; }
}
