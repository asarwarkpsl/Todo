using System;

namespace Core.Model
{
    public class List : BaseModel
    {   
        public ICollection<Task> Tasks { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool isEnabled { get; set; }     
    }
}