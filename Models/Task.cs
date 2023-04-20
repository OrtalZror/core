using System;

namespace שיעור_2.Models 
{
  public class Task
  {
    public string Id {get; set; }
        public string Description {get; set; }
        public DateTime Deadline {get; set; }
        public bool IsDone {get; set; }
        public string userId {get;set;}
  }
}