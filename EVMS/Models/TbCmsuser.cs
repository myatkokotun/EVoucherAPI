﻿using System;
using System.Collections.Generic;

namespace EVMS.Models;

public partial class TbCmsuser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? Accesstime { get; set; }

    public virtual ICollection<TbEvoucher> TbEvouchers { get; } = new List<TbEvoucher>();
}
