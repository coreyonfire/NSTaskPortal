using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSTaskPortal.Models
{
    public class NSTask
    {
        [Key]
        public int NSTaskID { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public String AssignedTo { get; set; }

        public NSTask() : this(0, "NO TITLE PROVIDED", 0.0, "NOT ASSIGNED")
        {
            //
        }
        public NSTask(int t = 0, string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSIGNED")
        {
            NSTaskID = t;
            Name = n;
            Hours = h;
            AssignedTo = a;
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