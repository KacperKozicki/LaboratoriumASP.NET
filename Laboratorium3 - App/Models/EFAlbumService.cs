using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium3___App.Models
{
    public class EFAlbumService : IAlbumService
    {
        private readonly AppDbContext _context;

        public EFAlbumService(AppDbContext context)
        {
            _context = context;
            var albumsWithTracks = context.Albums.Include(a => a.Tracklist).ToList();

        }

        public int Add(Album album)
        {
            // Filter out empty or null tracks before adding the album
            album.Tracklist = album.Tracklist
                .Where(track => !string.IsNullOrEmpty(track))
                .ToList();

            var e = _context.Albums.Add(AlbumMapper.ToEntity(album));
            _context.SaveChanges();
            int id = e.Entity.Id;

            return id;
        }
        public bool ValidateGenreId(int? genreId)
        {
            // Sprawdzenie, czy genreId istnieje w bazie danych
            var genreEntity = _context.Genres.Find(genreId);
            return genreEntity != null;
        }

        public void Delete(int id)
        {
            AlbumEntity? find = _context.Albums.Find(id);
            if (find != null)
            {
                _context.Albums.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Album> FindAll()
        {
            //return _context.Albums.Select(e => AlbumMapper.FromEntity(e)).ToList();
            var albums = _context.Albums.Include(a => a.Tracklist).ToList();
            return albums.Select(e => AlbumMapper.FromEntity(e)).ToList();
        }

        public List<GenreEntity> FindAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Album? FindById(int id)
        {
            AlbumEntity? find = _context.Albums.Find(id);

            return find != null ? AlbumMapper.FromEntity(find) : null;
        }

        //public void Update(Album album)
        //{
        //    var existingAlbumEntity = _context.Albums.Find(album.Id);

        //    if (existingAlbumEntity != null)
        //    {
        //        _context.Entry(existingAlbumEntity).CurrentValues.SetValues(AlbumMapper.ToEntity(album));
        //        _context.SaveChanges();
        //    }

        //}

        public void Update(Album album)
        {
            var existingAlbumEntity = _context.Albums
                .Include(a => a.Tracklist) // Ensure Tracklist is loaded
                .SingleOrDefault(a => a.Id == album.Id);

            if (existingAlbumEntity != null)
            {
                // Update scalar properties
                _context.Entry(existingAlbumEntity).CurrentValues.SetValues(AlbumMapper.ToEntity(album));

                // Update related tracks
                UpdateTracklist(existingAlbumEntity.Tracklist, album.Tracklist);

                _context.SaveChanges();
            }
        }

        private void UpdateTracklist(ICollection<TrackEntity> existingTracks, List<string> newTracks)
        {
            // Remove tracks that are not present in the newTracks list or are empty
            var tracksToRemove = existingTracks
                .Where(t => !newTracks.Contains(t.Name) && !string.IsNullOrEmpty(t.Name))
                .ToList();

            foreach (var track in tracksToRemove)
            {
                existingTracks.Remove(track);
                _context.Tracks.Remove(track); // Optionally, you might want to delete the track from the database
            }

            // Add new non-empty tracks
            var tracksToAdd = newTracks
                .Where(name => !existingTracks.Any(t => t.Name == name) && !string.IsNullOrEmpty(name))
                .Select(name => new TrackEntity { Name = name })
                .ToList();

            foreach (var track in tracksToAdd)
            {
                existingTracks.Add(track);
            }
        }


        public PagingAlbumList<Album> FindPage(int page, int size)
        {
            int totalCount = _context.Albums.Count();
            List<Album> albums = _context.Albums
             .Skip((page - 1) * size)
             .Take(size)
             .Select(AlbumMapper.FromEntity) // Użyj mappera do przekształcenia
             .ToList();
            return PagingAlbumList<Album>.Create(albums, totalCount, page, size);

        }


    }
}
