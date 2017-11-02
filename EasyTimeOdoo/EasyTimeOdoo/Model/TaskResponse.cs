using System;
using System.Collections.Generic;

namespace EasyTimeOdoo.Model
{
    public class TaskResponse
    {
        public int status
        {
            get;
            set;
        }

        public List<Activity> data
        {
            get;
            set;
        }
        
        
    }
}
