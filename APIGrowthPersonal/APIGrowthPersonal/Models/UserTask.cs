namespace APIGrowthPersonal.Models
{
    public class UserTask
    {
        public int UserId { get; set; }
        public int QuestId { get; set; }
        public string Status { get; set; } = "active";
        public int Progress { get; set; } = 0;
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}
