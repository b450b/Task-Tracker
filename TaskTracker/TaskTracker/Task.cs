using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker
{
    public class Task
    {
        public int Id {  get; set;}
        public string Description { get; set;}
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Task() { }

        public Task(int id,string descrip)
        {
            Id = id;
            Description = descrip;
            Status = "todo";    
            CreatedAt = DateTime.Now;     
            UpdatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Id}] {Description} [{Status}]";
        }
    }
}
