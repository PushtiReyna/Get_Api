using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.GetData
{
    public class GetDataReqDTO
    {
        public Pagination pagination { get; set; }
        public List<Datum> data { get; set; }
        public class Datum
        {
            public double open { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double close { get; set; }
            public double volume { get; set; }
            public double adj_high { get; set; }
            public double adj_low { get; set; }
            public double adj_close { get; set; }
            public double adj_open { get; set; }
            public double adj_volume { get; set; }
            public double split_factor { get; set; }
            public double dividend { get; set; }
            public string symbol { get; set; }
            public string exchange { get; set; }
            public DateTime date { get; set; }
        }

        public class Pagination
        {
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
            public int total { get; set; }
        }
    }
}
