namespace NetFlixGo.Entities
{
    public record Rating
    {
        public int RatingId { get; init; }
        public int UserId { get; init; }
        public int MovieId { get; init; }
        public int Ratings { get; init; }
    }
}