using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTime.Model
{
    public class Activity
    {
        public string TaskName { get; set; }
        public int TaskID { get; set; }
        public string ProjectName { get; set; }
        public int ProjectID { get; set; }
        public string TimeElapsed { get; set; }
    }
}
