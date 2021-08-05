using GOPR_HELP_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API.Models
{
    public class MountainsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Height { get; set; }

        public List<TrailsDto> Trails { get; set; }
    }
}
