using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium3___App.Models
{
    public class EFPlaylistService : IPlaylistService
    {
        private readonly AppDbContext _context;

        public EFPlaylistService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Playlist playlist)
        {
            var playlistEntity = PlaylistMapper.ToEntity(playlist, _context);

            // Obliczanie całkowitego czasu trwania playlisty
            playlistEntity.TotalDuration = CalculateTotalDuration(playlist.TrackIds);

            _context.Playlists.Add(playlistEntity);
            _context.SaveChanges();

            return playlistEntity.Id;
        }


        public void Update(Playlist playlist)
        {
            var existingPlaylist = _context.Playlists.Find(playlist.Id);
            if (existingPlaylist != null)
            {
                PlaylistMapper.UpdateEntity(existingPlaylist, playlist);
                _context.SaveChanges();
            }
        }

        public void Delete(int playlistId)
        {
            var playlist = _context.Playlists.Find(playlistId);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
                _context.SaveChanges();
            }
        }

        public Playlist FindById(int playlistId)
        {
            var playlist = _context.Playlists.Find(playlistId);
            return playlist != null ? PlaylistMapper.FromEntity(playlist) : null;
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _context.Playlists.Select(PlaylistMapper.FromEntity).ToList();
        }

        public TimeSpan CalculateTotalDuration(List<int> trackIds)
        {
            // Najpierw wykonaj zapytanie (pobierz wyniki do pamięci)
            var trackDurations = _context.Tracks
                                         .Where(t => trackIds.Contains(t.Id))
                                         .Select(t => t.Duration)
                                         .ToList(); // ToList() powoduje wykonanie zapytania

            // Następnie wykonaj agregację w pamięci
            var totalDuration = trackDurations.Aggregate(TimeSpan.Zero, (total, next) => total + next);

            return totalDuration;
        }



        public PagingPlaylistList<Playlist> FindPage(int page, int size)
        {
            int totalCount = _context.Playlists.Count();
            List<Playlist> playlists = _context.Playlists
             .Skip((page - 1) * size)
             .Take(size)
             .Select(PlaylistMapper.FromEntity) // Użyj mappera do przekształcenia
             .ToList();
            return PagingPlaylistList<Playlist>.Create(playlists, totalCount, page, size);

        }



       

        public List<GenreEntity> FindAllGenres()
        {
            return _context.Genres.ToList();
        }

        public List<TagEntity> FindAllTags()
        {
            return _context.Tags.ToList();
        }

        public bool ValidateGenreId(int? genreId)
        {
            // Sprawdzenie, czy genreId istnieje w bazie danych
            var genreEntity = _context.Genres.Find(genreId);
            return genreEntity != null;
        }

        public Playlist FindByIdWithTracks(int id)
        {
            var playlistEntity = _context.Playlists
                                         .Include(p => p.PlaylistTracks)
                                         .ThenInclude(pt => pt.Track)
                                         .ThenInclude(track => track.Album)
                                         .ThenInclude(album => album.Genre)
                                         .FirstOrDefault(p => p.Id == id);

            if (playlistEntity == null)
            {
                return null;
            }

            var playlist = PlaylistMapper.FromEntity(playlistEntity);

            // Dodanie szczegółów utworów
            foreach (var pt in playlistEntity.PlaylistTracks)
            {
                var track = pt.Track;
                var trackDetails = new TrackDetails
                {
                    Name = track.Name,
                    Genre = track.Album.Genre.Name, // Nazwa gatunku
                    BandOrArtist = track.Album.BandOrArtist, // Wykonawca
                    Duration = track.Duration, // Czas trwania
                    AlbumName = track.Album.Name // Nazwa albumu
                };
                playlist.TrackDetails.Add(trackDetails);
            }

            return playlist;
        }


        public List<string> GetTagsForPlaylist(int playlistId)
        {
            // Pobranie tagów z bazy danych dla danej playlisty
            var tagNames = _context.PlaylistTagEntity
                                     .Where(pt => pt.PlaylistId == playlistId)
                                     .Select(pt => pt.Tag.Name)
                                     .ToList();

            return tagNames;
        }


        public bool TrackExists(string trackName)
        {
            return _context.Tracks.Any(t => t.Name == trackName);
        }

    }

}
