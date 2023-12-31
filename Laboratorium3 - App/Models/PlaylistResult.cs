namespace Laboratorium3___App.Models
{
    public class PlaylistResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string Author { get; set; }
        public int TrackCount { get; set; }
        public string VisibilityNote { get; set; } // Pole na dopisek gdy playlista nie jest publiczna
    }
}
