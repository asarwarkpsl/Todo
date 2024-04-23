

using System.Diagnostics.CodeAnalysis;

namespace Core.Model
{   
    public class Task: BaseModel
    {
        public int ListId { get; set; }
        public string Description { get; set; } 
        public string Status { get; set; } = TaskStatus.Active.ToString();
        public DateTime DueDate { get; set; }
        [AllowNull]
        public DateTime NextRemindDate { get; set; }
        public string Type { get; set; } = RepeatType.None.ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string FileURL { get; set; }
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