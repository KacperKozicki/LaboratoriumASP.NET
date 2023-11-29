using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Laboratorium3___App.Models
{
    public class PagingAlbumList<T>
    {
        public IEnumerable<T> Data { get; }
        public int TotalItems { get; }
        public int TotalPages { get; }
        public int Number { get; }
        public int Size { get; }
        public bool IsFirst { get; }
        public bool IsLast { get; }
        public bool IsNext { get; }
        public bool IsPrevious { get; }

        private PagingAlbumList(ICollection<T> data, int totalItems, int number, int size)
        {
            Data = data;
            TotalItems = totalItems;
            Number = number;
            Size = size;
            TotalPages = TotalItems / Size + (TotalItems % Size > 0 ? 1 : 0);
            IsFirst = number <= 1;
            IsLast = number >= TotalPages;
            IsNext = !IsLast;
            IsPrevious = !IsFirst;
        }
        public static PagingAlbumList<T> Create(ICollection<T> data, int totalItems, int number, int size)
        {
            PagingAlbumList<T> page = new PagingAlbumList<T>(data, totalItems, number, size);
            if (number > page.TotalPages)
            {
                return new PagingAlbumList<T>(data, totalItems, page.TotalPages, size);
            }
            if (number < 1)
            {
                return new PagingAlbumList<T>(data, totalItems, 1, size);
            }
            return page;
        }
    }

}
