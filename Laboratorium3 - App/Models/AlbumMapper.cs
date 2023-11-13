using Data.Entities;
using System.Linq;

namespace Laboratorium3___App.Models
{
    public class AlbumMapper
    {
        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                Created = model.Created,
                Id = model.Id,
                Name = model.Name,
                BandOrArtist = model.BandOrArtist,
                ReleaseDate = model.ReleaseDate,
                Duration = model.Duration,
                ChartRanking = (int)model.ChartRanking,
                Tracklist = model.Tracklist?.Select(track => new TrackEntity { Name = track }).ToList() ?? new List<TrackEntity>(),
            };
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
                Tracklist = entity.Tracklist?.Select(track => track.Name).ToList() ?? new List<string>(),
            };
        }
    }
}
