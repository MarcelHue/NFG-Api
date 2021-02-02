namespace NetFlixGo.Entities
{
    public record WriterMovie
    {
        public int WriterMovieId { get; init; }
        public int WriterId { get; init; }
        public int MovieId { get; init; }
    }
}