using BookStoreRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository.DAL
{
    interface IBookRepository:IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int bookID);
        void UpdateBook(Book book);
        void Save();
    }
}
