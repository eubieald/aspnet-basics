namespace ProjectApiBasics.Data
{
    public class Application
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required string Studio { get; set; } = string.Empty;
        public required float Review { get; set; }
        public required DateTimeOffset DateTimeCreated { get; set; }
    }
}
