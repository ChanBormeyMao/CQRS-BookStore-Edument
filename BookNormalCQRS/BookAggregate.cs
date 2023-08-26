
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events;
using NUnit.Framework.Constraints;

namespace BookNormalCQRS
{
    public class BookAggregate : Aggregate, IHandleCommand<AddNewBook>, IHandleCommand<UpdateReserveStatus>, IHandleCommand<UpdateBook>, IHandleCommand<DeleteBook>, IApplyEvent<AddedBook>, IApplyEvent<UpdatedBook>, IApplyEvent<DeletedBook>, IApplyEvent<UpdatedReserveStatus>
    {
        private List<Book> _allBooks = new List<Book>()
        {
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a6"), BookTitle = "fsfsfsfgsgsgsgfsf", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a7"), BookTitle="fsgfdhgdhgdjg", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a8"), BookTitle="jughkhgjkhuhgf", IsReserved= false}
        };
        public IEnumerable Handle(AddNewBook c)
        {
            if (IsBookExist(c.BookTitle))
            {
                throw new Exception("Book existed");
            }
            yield return new AddedBook
            {
                Id = c.Id,
                BookTitle = c.BookTitle,
                IsReserved = c.IsReserved
            };
        }



        public IEnumerable Handle(UpdateBook c)
        {
            if (IsBookExist(c.UpdatedBookTitle))
            {
                throw new Exception("Book existed");
            }
            yield return new UpdatedBook
            {
                Id = c.Id,
                UpdatedBookTitle = c.UpdatedBookTitle
            };
        }
        public IEnumerable Handle(DeleteBook c)
        {
            yield return new DeletedBook
            {
                Id = c.Id,
            };
        }

        public IEnumerable Handle(UpdateReserveStatus c)
        {
            yield return new UpdatedReserveStatus
            {
                Id = c.Id,
            };
        }
        //public IEnumerable Handle(SearchBook c)
        //{
        //    yield return new SearchedBook
        //    {
        //        Id = c.Id,
        //    };
        //}
        public void Apply(AddedBook e)
        {
            Book newBook = new Book()
            {
                Id = e.Id,
                BookTitle = e.BookTitle,
                IsReserved = e.IsReserved
            };
            _allBooks.Add(newBook);
        }
        public void Apply(UpdatedBook e)
        {
            var selectedBook = _allBooks.First(b => b.Id == e.Id);
            selectedBook.BookTitle = e.UpdatedBookTitle;
        }
        public void Apply(DeletedBook e)
        {
            var selectedBook = _allBooks.First(b => b.Id == e.Id);
            _allBooks.Remove(selectedBook);
        }

        public void Apply(UpdatedReserveStatus e)
        {
            var selectedBook = _allBooks.First(b => b.Id == e.Id);
            selectedBook.IsReserved = !selectedBook.IsReserved;
        }
        //public Book Apply(SearchedBook e)
        //{
        //    var selectedBook = _allBooks.First(b => b.BookId == e.Id);
        //    return selectedBook;
        //}
        private bool IsBookExist(string bookTitle)
        {
            foreach (Book b in _allBooks)
            {
                return b.BookTitle == bookTitle;
            }
            return false;
        }
    }
}



