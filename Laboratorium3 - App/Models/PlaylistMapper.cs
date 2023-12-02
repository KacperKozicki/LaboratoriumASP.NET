using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Data;
using System.Collections.Generic;


namespace Laboratorium3___App.Models
{
    public static class PlaylistMapper
    {
        public static PlaylistEntity ToEntity(Playlist playlist, AppDbContext dbContext)
        {
            var playlistEntity = new PlaylistEntity()
            {
                Created = playlist.Created,
                Id = playlist.Id,
                Name = playlist.Name,
                GenreId = playlist.GenreId,
                Tags = playlist.Tags,
                TotalDuration = playlist.TotalDuration,
                IsPublic = playlist.IsPublic,
                PlaylistTracks = new List<PlaylistTrackEntity>()
            };

            foreach (var trackId in playlist.TrackIds)
            {
                // Sprawdź, czy relacja już istnieje
                if (!dbContext.PlaylistTracks.Any(pt => pt.PlaylistId == playlist.Id && pt.TrackId == trackId))
                {
                    playlistEntity.PlaylistTracks.Add(new PlaylistTrackEntity { PlaylistId = playlist.Id, TrackId = trackId });
                }
            }

            return playlistEntity;
        }

        public static Playlist FromEntity(PlaylistEntity entity, AppDbContext dbContext)
        {
            return new Playlist()
            {
                Created = entity.Created,
                Id = entity.Id,
                Name = entity.Name,
                GenreId = entity.GenreId,
                Tags = entity.Tags,
                TotalDuration = entity.TotalDuration,
                IsPublic = entity.IsPublic,
                TrackIds = entity.PlaylistTracks?.Select(pt => pt.TrackId).ToList() ?? new List<int>(),
                // Dodajemy TrackNames:
                TrackNames = dbContext.Tracks
                                      .Where(t => entity.PlaylistTracks.Select(pt => pt.TrackId).Contains(t.Id))
                                      .Select(t => t.Name)
                                      .ToList()
            };

            
        }
        public static Playlist FromEntity(PlaylistEntity entity)
        {
            return new Playlist 
            {
                Created = entity.Created,
                Id = entity.Id,
                Name = entity.Name,
                GenreId = entity.GenreId,
                Tags = entity.Tags,
                TotalDuration = entity.TotalDuration,
                IsPublic = entity.IsPublic,
                TrackIds = entity.PlaylistTracks?.Select(pt => pt.TrackId).ToList() ?? new List<int>(),

            };

           
        }


        public static void UpdateEntity(PlaylistEntity entity, Playlist playlist)
        {
            entity.Name = playlist.Name;
            entity.GenreId = playlist.GenreId;
            entity.Tags = playlist.Tags;
            entity.TotalDuration = playlist.TotalDuration;
            entity.IsPublic = playlist.IsPublic;
            // Aktualizacja listy utworów może wymagać dodatkowej logiki
        }
    }

}
