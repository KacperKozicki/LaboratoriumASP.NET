using Data.Entities;

namespace Laboratorium3___App.Models;

public interface IPlaylistService
{
    int Add(Playlist playlist);
    void Update(Playlist playlist);
    void Delete(int playlistId);
    Playlist FindById(int playlistId);
    List<Playlist> GetAllPlaylists();
    TimeSpan CalculateTotalDuration(List<int> trackIds);

    PagingPlaylistList<Playlist> FindPage(int pageIndex, int pageSize);
    List<GenreEntity> FindAllGenres();
    bool ValidateGenreId(int? id);
    public Playlist FindByIdWithTracks(int id);
    public bool TrackExists(string trackName);
    public List<string> GetTagsForPlaylist(int playlistId);


}
