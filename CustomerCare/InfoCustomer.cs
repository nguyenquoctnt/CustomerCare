using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCare
{
    public class InfoCustomer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }
        public string link { get; set; }
        public bool remind { get; set; }
        public bool ordered { get; set; }

        //public DateTime? CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }
    }
}
