using BookNormalCQRS;
using Edument.CQRS;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public class BookReadModel : IBookReadModel, ISubscribeTo<AddedBook>, ISubscribeTo<DeletedBook>, ISubscribeTo<UpdatedBook>, ISubscribeTo<UpdatedReserveStatus>
    {
        public class Book
        {
            public Guid Id;
            public string BookTitle;
            public bool IsReserved;
        }

        private List<Book> _allBooks = new List<Book>()
        {
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a6"), BookTitle = "fsfsfsfgsgsgsgfsf", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a7"), BookTitle="fsgfdhgdhgdjg", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a8"), BookTitle="jughkhgjkhuhgf", IsReserved= false}
        };

        public List<Book> GetAllBooks()
        {
            lock (_allBooks)
            {
                return (from b in _allBooks
                        select new Book
                        {
                            Id = b.Id,
                            BookTitle = b.BookTitle,
                            IsReserved = b.IsReserved
                        }
                       ).ToList();
            }
        }
        public Book SearchedBook(Guid BookId)
        {
            return _allBooks.First(b => b.Id == BookId);
        }

        public void Handle(AddedBook e)
        {
            if (IsBookExisted(e.BookTitle))
            {
                throw new Exception("Book Existed");
            }
            var book = new Book
            {
                Id = e.Id,
                BookTitle = e.BookTitle,
                IsReserved = e.IsReserved
            };
            lock (_allBooks)
            {
                _allBooks.Add(book);
            }
        }
        public void Handle(UpdatedBook e)
        {

            if (IsBookExisted(e.UpdatedBookTitle))
            {
                throw new Exception("Book Existed");
            }
            var book = _allBooks.First(b => b.Id == e.Id);
            lock (_allBooks)
            {
                book.BookTitle = e.UpdatedBookTitle;
            }
        }
        public void Handle(DeletedBook e)
        {
            var book = _allBooks.First(b => b.Id == e.Id);
            lock (_allBooks)
            {
                _allBooks.Remove(book);
            }
        }

        public void Handle(UpdatedReserveStatus e)
        {
            var book = SearchedBook(e.Id);
            lock (_allBooks)
            {
                book.IsReserved = !book.IsReserved;
            }
        }

        public bool IsBookExisted(string bookTitle)
        {
            foreach (Book b in _allBooks)
            {
                return b.BookTitle == bookTitle;
            }
            return false;
        }

    }
}
