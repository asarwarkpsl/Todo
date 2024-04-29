namespace API.DTO
{
    public class ListToReturn
    {
        public int id { get; set; }
        public string Title { get; set; }
        public ICollection<TaskToReturn> Tasks { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool isEnabled { get; set; }
    }
}
