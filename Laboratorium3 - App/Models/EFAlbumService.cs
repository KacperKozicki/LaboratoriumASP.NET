﻿using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Laboratorium3___App.Models.Album;

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
            .Where(track => !string.IsNullOrEmpty(track.Name))
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

        private void UpdateTracklist(ICollection<TrackEntity> existingTracks, List<Track> newTracks)
        {
            // Remove tracks that are not in the new tracklist
            var trackNames = newTracks.Select(t => t.Name).ToList();
            var tracksToRemove = existingTracks.Where(t => !trackNames.Contains(t.Name)).ToList();

            foreach (var track in tracksToRemove)
            {
                existingTracks.Remove(track);
                _context.Tracks.Remove(track);
            }

            // Update or add new tracks
            foreach (var newTrack in newTracks)
            {
                var existingTrack = existingTracks.FirstOrDefault(t => t.Name == newTrack.Name);
                if (existingTrack != null)
                {
                    // Update existing track
                    existingTrack.Duration = newTrack.Duration;
                }
                else
                {
                    // Add new track
                    var trackEntity = new TrackEntity
                    {
                        Name = newTrack.Name,
                        Duration = newTrack.Duration
                    };
                    existingTracks.Add(trackEntity);
                }
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
