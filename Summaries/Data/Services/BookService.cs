

using Summaries.Data.Models;
using System.Linq;

namespace Summaries.Data
{
    public class BookService : IBookService
    {
        public void AddBook(Book newBook)
        {
            Data.Books.Add(newBook);
        }

        public void DeleteBook(int id)
        {
            Book? book = Data.Books.FirstOrDefault(c => c.Id == id);
            if(book != null)
            {
               Data.Books.Remove(book);
            }
        }

        public List<Book> GetAllBooks()
        {
            return Data.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return Data.Books.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateBook(int id, Book newBook)
        {
            var oldBook = Data.Books.FirstOrDefault(c => c.Id == id);
            if(oldBook != null)
            {
                oldBook.Title = newBook.Title;
                oldBook.Author = newBook.Author;
                oldBook.Description = newBook.Description;
                oldBook.DateStart = newBook.DateStart;
                oldBook.Rate = newBook.Rate;
                oldBook.DateRead = newBook.DateRead;
            }
        }
    }


}
