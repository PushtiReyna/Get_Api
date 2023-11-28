﻿using System;
using System.Collections.Generic;

namespace Data_layer.Models;

public class Datum
{
    public double? StockOpen { get; set; }

    public double? High { get; set; }

    public double? Low { get; set; }

    public double? StockClose { get; set; }

    public double? Volume { get; set; }

    public double? AdjHigh { get; set; }

    public double? AdjLow { get; set; }

    public double? AdjClose { get; set; }

    public double? AdjOpen { get; set; }

    public double? AdjVolume { get; set; }

    public double? SplitFactor { get; set; }

    public double? Dividend { get; set; }

    public string? Symbol { get; set; }

    public string? Exchange { get; set; }

    public DateTime? Date { get; set; }
}