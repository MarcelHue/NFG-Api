namespace NetFlixGo.Entities
{
    public record Favorites
    {
        public int FavoritesId { get; init; }
        public int UserId { get; init; }
        public int MovieId { get; init; }
    }
}