using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkModel
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}
