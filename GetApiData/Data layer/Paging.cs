using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer
{
    //public class Paging
    //{ 
    //        public int current { get; set; }
    //        public int total { get; set; }
    //}
    //public class Movie
    //{
    //    public string s { get; set; }
    //}

    public class pagination
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

}
