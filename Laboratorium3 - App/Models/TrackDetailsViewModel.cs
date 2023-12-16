using System;

// Model widoku dla szczegółów utworu
public class TrackDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string BandOrArtist { get; set; }
    public TimeSpan Duration { get; set; }
    public string AlbumName { get; set; }
    public List<TrackDetailsViewModel> OtherTracksByArtist { get; set; }

}
