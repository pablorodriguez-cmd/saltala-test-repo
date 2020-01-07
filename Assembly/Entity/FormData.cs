using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Entity
{
    public class FormData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RegisterReason { get; set; }
        public bool Apply { get; set; }
    }
}
