using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTimeOdoo.Model
{
    public class Activity
    {
        public string startDate { get; set; }
        public string projectName { get; set; }
        public string totalHours { get; set; }
        public string endDate { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int projectId { get; set; }
    }
}
