using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTimeOdoo.Model
{
    public class Activity
    {
        public string Title { get; set; }
        public int TaskID { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public string UserID { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public string timeElapsed { get; set; }
    }
}
