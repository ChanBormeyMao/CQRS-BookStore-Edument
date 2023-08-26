using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events;

namespace BookNormalCQRS
{
    public class ReservationAggregate : Aggregate, IHandleCommand<BorrowBook>, IHandleCommand<ReturnBook>, IApplyEvent<BorrowedBook>, IApplyEvent<ReturnedBook>
    {
        private List<Reservation> _AllReservations = new List<Reservation>();
        private List<Book> _allBooks = new List<Book>();

        private bool isBookReserved(Guid BookId)
        {
            foreach (Book b in _allBooks)
            {
                var seletedBook = _allBooks.First(bb => bb.Id == BookId);
                return seletedBook.IsReserved;
            }
            return false;
        }
        public void Apply(BorrowedBook e)
        {
            Reservation newReservation = new Reservation()
            {
                Id = e.Id,
                Book = e.Book,
                User = e.User
            };
            _AllReservations.Add(newReservation);
            
        }
        public void Apply(ReturnedBook e)
        {
            var selectedReservation = _AllReservations.First(r => r.Id == e.Id);
            _AllReservations.Remove(selectedReservation);
            
        }

        public IEnumerable Handle(BorrowBook c)
        {
            if (isBookReserved(c.Book.Id))
            {
                throw new CannotBorrowBook();
            }
            yield return new BorrowedBook
            {
                Id = c.Id,
                Book = c.Book,
                User = c.User
            };
        }
        public IEnumerable Handle(ReturnBook c)
        {

            yield return new ReturnedBook
            {
                Id = c.Id,
            };
        }

    }
}