using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API.Data
{
    public class Mountains
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Height { get; set; }
        public List<Trails> Trails { get; set; }

    
    }
}
