using System;
using System.Collections.Generic;

namespace Data_layer.Models;

public partial class ApiGetDataMst
{
    public int Id { get; set; }

    public double? High { get; set; }

    public double? Low { get; set; }

    public double? AdjHigh { get; set; }

    public double? AdjLow { get; set; }
}
