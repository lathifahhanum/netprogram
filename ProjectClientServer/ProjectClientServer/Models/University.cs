﻿using System;
using System.Collections.Generic;

namespace ProjectClientServer.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Education> TbMEducations { get; set; } = new List<Education>();
}
