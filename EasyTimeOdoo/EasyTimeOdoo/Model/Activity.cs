using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTimeOdoo.Model
{
    public class Activity
    {
        public string task_start_date { get; set; }
        public string project_name { get; set; }
        public double task_total_hours { get; set; }
        public string task_end_date { get; set; }
        public int task_id { get; set; }
        public string task_name { get; set; }
        public int project_id { get; set; }


        // get specific task
        //public string task_description { get; set; }
        //public string task_date_deadline { get; set; }
        //public double task_planned_hours { get; set; }


    }
}
