using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreRepository.Models;
using System.Data.Entity;

namespace BookStoreRepository.DAL
{
   
    public class BookRepository : IBookRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void DeleteBook(int bookID)
        {
            Book book = db.Books.Find(bookID);
            db.Books.Remove(book);
        }

        public Book GetBookByID(int bookId)
        {
          return  db.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            db.Books.Add(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private ApplicationDbContext applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BookRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}