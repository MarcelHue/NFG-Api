namespace NetFlixGo.Entities
{
    public record GenresMovie
    {
        public int GenresMovieId { get; init; }
        public int GenresId { get; init; }
        public int MovieId { get; init; }
    }
}