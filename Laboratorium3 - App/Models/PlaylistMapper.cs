﻿using Data.Entities;
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
            var playlistEntity = new PlaylistEntity
            {
                Created = playlist.Created,
                Id = playlist.Id,
                Name = playlist.Name,
                GenreId = playlist.GenreId,
                UserId = playlist.UserId,
                TotalDuration = playlist.TotalDuration,
                IsPublic = playlist.IsPublic,
                PlaylistTracks = playlist.TrackIds
                    .Where(trackId => !dbContext.PlaylistTracks.Any(pt => pt.PlaylistId == playlist.Id && pt.TrackId == trackId))
                    .Select(trackId => new PlaylistTrackEntity { PlaylistId = playlist.Id, TrackId = trackId })
                    .ToList(),
                PlaylistTags = playlist.TagIds?.Select(tagId => new PlaylistTagEntity { PlaylistId = playlist.Id, TagId = tagId }).ToList()
            };

            return playlistEntity;
        }

        public static Playlist FromEntity(PlaylistEntity entity, AppDbContext dbContext)
        {
            var tagIds = entity.PlaylistTags?.Select(pt => pt.TagId).ToList() ?? new List<int>();

            var tagNames = dbContext.Tags
                                    .Where(tag => tagIds.Contains(tag.Id)) // Użycie wczytanych identyfikatorów
                                    .Select(tag => tag.Name)
                                    .ToList();
            var trackDetails = dbContext.PlaylistTracks
                    .Where(pt => pt.PlaylistId == entity.Id)
                    .Include(pt => pt.Track)
                    .ThenInclude(t => t.Album)
                    .ThenInclude(a => a.Genre)
                    .Select(pt => new TrackDetails
                    {
                        Id = pt.Track.Id, // Upewnij się, że korzystasz z prawidłowego Id
                        Name = pt.Track.Name,
                        Genre = pt.Track.Album.Genre.Name,
                        BandOrArtist = pt.Track.Album.BandOrArtist,
                        Duration = pt.Track.Duration,
                        AlbumName = pt.Track.Album.Name
                    })
                    .ToList();

            return new Playlist()
            {
                Created = entity.Created,
                Id = entity.Id,
                Name = entity.Name,
                GenreId = entity.GenreId,
                TagIds = tagIds,
                TagNames = tagNames,
                TotalDuration = entity.TotalDuration,
                IsPublic = entity.IsPublic,
                UserId = entity.UserId,
                TrackIds = entity.PlaylistTracks?.Select(pt => pt.TrackId).ToList() ?? new List<int>(),
                TrackNames = dbContext.Tracks
                              .Where(t => entity.PlaylistTracks.Select(pt => pt.TrackId).Contains(t.Id))
                              .Select(t => t.Name)
                              .ToList(),
                TrackDetails = trackDetails,
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
                TagIds = entity.PlaylistTags?.Select(pt => pt.TagId).ToList() ?? new List<int>(),
                TotalDuration = entity.TotalDuration,
                IsPublic = entity.IsPublic,
                UserId = entity.UserId,
                TrackIds = entity.PlaylistTracks?.Select(pt => pt.TrackId).ToList() ?? new List<int>(),

            };
        }



        public static void UpdateEntity(PlaylistEntity entity, Playlist playlist, AppDbContext dbContext)
        {
            entity.Name = playlist.Name;
            entity.GenreId = playlist.GenreId;
            entity.IsPublic = playlist.IsPublic;
            entity.UserId = playlist.UserId;

            // Aktualizacja tagów
            entity.PlaylistTags.Clear();
            if (playlist.TagIds != null && playlist.TagIds.Any())
            {
                entity.PlaylistTags = playlist.TagIds.Select(tagId => new PlaylistTagEntity { PlaylistId = entity.Id, TagId = tagId }).ToList();
            }

            // Aktualizacja utworów
            var existingTrackIds = entity.PlaylistTracks.Select(pt => pt.TrackId).ToList();
            var newTrackIds = playlist.TrackIds.Except(existingTrackIds).ToList();
            var removedTrackIds = existingTrackIds.Except(playlist.TrackIds).ToList();

            foreach (var trackId in newTrackIds)
            {
                entity.PlaylistTracks.Add(new PlaylistTrackEntity { PlaylistId = entity.Id, TrackId = trackId });
            }

            foreach (var trackId in removedTrackIds)
            {
                var trackToRemove = entity.PlaylistTracks.FirstOrDefault(pt => pt.TrackId == trackId);
                if (trackToRemove != null)
                {
                    entity.PlaylistTracks.Remove(trackToRemove);
                }
            }
        }

    }
}
