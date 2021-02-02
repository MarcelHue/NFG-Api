namespace NetFlixGo.Entities
{
    public record StarMovie
    {
        public int StarMovieId { get; init; }
        public int StarId { get; init; }
        public int MovieId { get; init; }
    }
}