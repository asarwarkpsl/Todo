

namespace Core.Model
{   
    public class Task: BaseModel
    {
        public int ListId { get; set; }
        public string Description { get; set; } 
        public TaskStatus Status { get; set; } = TaskStatus.Active;
        public DateTime DueDate { get; set; }
        public DateTime NextRemindDate { get; set; }
        public RepeatType Type { get; set; } = RepeatType.None;
        public DateTime Timestamp { get; set; }
        public bool isEnabled { get; set; } = true;
    }

    public enum TaskStatus
    {
        Completed,
        Canceled,
        Snozed,
        Active
    }

    public enum RepeatType
    {
        None,
        Daily,
        Weekly,
        Yearly
    }

}