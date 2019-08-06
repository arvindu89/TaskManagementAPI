using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagement_API.Models
{
    public class TaskModel
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public int ParentTaskID { get; set; }
        public string ParentTaskName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}