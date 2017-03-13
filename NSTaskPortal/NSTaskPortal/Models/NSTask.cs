using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSTaskPortal.Models
{
    public class NSTask
    {
        protected string Name { get; set; }
        protected double Hours { get; set; }
        protected String AssignedTo { get; set; }

        public NSTask(string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSIGNED")
        {
            Name = n;
            Hours = h;
            AssignedTo = a;
        }
    }

    public class NSSupportTask : NSTask
    {
        protected int CaseNumber { get; set; }

        public NSSupportTask(string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSINGED", int c = 0) 
            : base(n, h, a)
        {
            CaseNumber = c;
        }
    }

    public class NSProjectTask : NSTask
    {
        // project tasks are the case themselves so do i need to store case number? I will for now, just in case
        public NSProjectTask(string n = "NO TITLE PROVIDED", double h = 0.0, string a = "NOT ASSINGED") 
            : base(n, h, a)
        { }
    }
}