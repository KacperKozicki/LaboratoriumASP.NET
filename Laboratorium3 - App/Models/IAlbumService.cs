using Data.Entities;

namespace Laboratorium3___App.Models;

public interface IAlbumService
{
    int Add(Album book);
    void Delete(int id);
    void Update(Album book);
    List<Album> FindAll();
    Album? FindById(int id);

    List<GenreEntity> FindAllGenres();

    PagingAlbumList<Album> FindPage(int pageIndex, int pageSize);

}