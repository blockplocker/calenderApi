namespace calenderApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Allday { get; set; }
    }
}
