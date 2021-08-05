using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API.Data
{
    public class Registration
    {
        public int Id { get; set; }
        public int Tourist_Id { get; set; }
        public int Mountains_Id { get; set; }
        public int Trails_Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime END { get; set; }//nullable 
        public bool Status { get; set; }//Default "Pozytywnie" TRUE 
        
    }
}
