using System;
using System.Collections.Generic;

namespace EVMS.Models;

public partial class TbPaymentMethod
{
    public int Id { get; set; }

    public string? MethodName { get; set; }

    public int? Discount { get; set; }
}
