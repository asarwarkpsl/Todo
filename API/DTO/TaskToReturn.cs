using Core.Model;
using System.Diagnostics.CodeAnalysis;

namespace API.DTO
{
    public class TaskToReturn
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int ListId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime NextRemindDate { get; set; }
        public DateTime Timestamp { get; set; }
        public string FileURL { get; set; }
        public bool isEnabled { get; set; } = true;
    }
}
