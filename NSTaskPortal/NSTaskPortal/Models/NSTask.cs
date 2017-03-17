using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSTaskPortal.Models
{
    public class NSTask
    {
        public enum taskTypeEnum { Support, Project };

        [Key]
        public int NSTaskID { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public String AssignedTo { get; set; }
        public taskTypeEnum TaskType { get; set; }

        public NSTask() : this(0, "NO TITLE PROVIDED", 0.0, "NOT ASSIGNED")
        {
            //
        }
        public NSTask(int t = 0, string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSIGNED", int type = 0)
        {
            NSTaskID = t;
            Name = n;
            Hours = h;
            AssignedTo = a;
            TaskType = type == 0 ? taskTypeEnum.Support : taskTypeEnum.Project;
        }
    }

    //public class NSSupportTask : NSTask
    //{
    //    public int CaseNumber { get; set; }

    //    public NSSupportTask(string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSINGED", int c = 0) 
    //        : base(n, h, a)
    //    {
    //        CaseNumber = c;
    //    }
    //}

    //public class NSProjectTask : NSTask
    //{
    //    // project tasks are the case themselves so do i need to store case number? I will for now, just in case
    //    public NSProjectTask(string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSINGED") 
    //        : base(n, h, a)
    //    { }
    //}
}