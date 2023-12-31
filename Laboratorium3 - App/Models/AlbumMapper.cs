using Data.Entities;
using System.Globalization;
using System.Linq;
using static Laboratorium3___App.Models.Album;

namespace Laboratorium3___App.Models
{
    public class AlbumMapper
    {
        public static AlbumEntity ToEntity(Album model)
        {
            var entity = new AlbumEntity()
            {
                Created = model.Created,
                Id = model.Id,
                Name = model.Name,
                BandOrArtist = model.BandOrArtist,
                ReleaseDate = model.ReleaseDate,
                Duration = model.Duration,
                ChartRanking = (int)model.ChartRanking,
                Tracklist = new List<TrackEntity>(),

                GenreId = (int)model.GenreId,

            };
            TimeSpan totalDuration = TimeSpan.Zero;
            foreach (var track in model.Tracklist)
            {
                var trackEntity = new TrackEntity
                {
                    Name = track.Name,
                    Duration = track.Duration
                };
                entity.Tracklist.Add(trackEntity);
                totalDuration += track.Duration;
            }

            

            return entity;


        }

        public static Album FromEntity(AlbumEntity entity)
        {
            return new Album()
            {
                Created = entity.Created,
                Id = entity.Id,
                Name = entity.Name,
                BandOrArtist = entity.BandOrArtist,
                ReleaseDate = entity.ReleaseDate,
                Duration = entity.Duration,
                ChartRanking = (AlbumChartRanking)entity.ChartRanking,
                Tracklist = entity.Tracklist?.Select(track => new Track
                {
                    Name = track.Name,
                    Duration = track.Duration
                }).ToList() ?? new List<Track>(),
                GenreId = entity.GenreId,

            };
        }
    }
}
