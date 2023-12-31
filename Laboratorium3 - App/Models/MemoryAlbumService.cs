//using Data.Entities;
//using System.Reflection;

//namespace Laboratorium3___App.Models;
//public class MemoryAlbumService : IAlbumService
//{
//    IDateTimeProvider _timeProvider;

//    private Dictionary<int, Album> _items = new Dictionary<int, Album>();

//    public MemoryAlbumService(IDateTimeProvider timeProvider)
//    {
//        _timeProvider = timeProvider;
//    }


//    public int Add(Album item)
//    {
//        item.Tracklist = item.Tracklist.Where(item => !string.IsNullOrWhiteSpace(item)).ToList(); //jeżeli dodano nowe pola na piosenki ale są puste to omijaj 

//        int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
//        item.Id = id + 1;
//        item.Created=_timeProvider.GetDateTime();
//        _items.Add(item.Id, item);
//        return item.Id;
//    }

//    public void Delete(int id)
//    {
//        _items.Remove(id);
//    }

//    public List<Album> FindAll()
//    {
//        return _items.Values.ToList();
//    }

//    public List<GenreEntity> FindAllGenres()
//    {
//        throw new NotImplementedException();
//    }

//    public Album? FindById(int id)
//    {
//        return _items[id];
//    }

//    public PagingAlbumList<Album> FindPage(int pageIndex, int pageSize)
//    {
//        throw new NotImplementedException();
//    }

//    public void Update(Album item)
//    {
//        item.Tracklist = item.Tracklist.Where(item => !string.IsNullOrWhiteSpace(item)).ToList();

//        _items[item.Id] = item;
//    }

//    public bool ValidateGenreId(int? id)
//    {
//        throw new NotImplementedException();
//    }
//}
