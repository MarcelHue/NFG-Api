namespace NetFlixGo.Entities
{
    public record Writer
    {
        public int WriterId { get; init; }
        public string Name { get; init; }
    }
}