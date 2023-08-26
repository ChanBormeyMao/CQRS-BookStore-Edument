using BookNormalCQRS;
using Edument.CQRS;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public class ReservationReadModel : IReservationReadModel, ISubscribeTo<BorrowedBook>, ISubscribeTo<ReturnedBook>
    {
        public class Reservation
        {
            public Guid Id;
            public User User { get; set; }
            public Book Book { get; set; }
        }

        private List<Reservation> _allReservations = new List<Reservation>();



        public List<Reservation> GetAllreservations()
        {
            lock (_allReservations)
            {
                return (from r in _allReservations
                        select new Reservation
                        {
                            Id = r.Id,
                            User = r.User,
                            Book = r.Book,

                        }
                       ).ToList();
            }
        }
        public Reservation SearchReservation(Guid Id)
        {
            return _allReservations.First(r => r.Id == Id);
        }
        public void Handle(BorrowedBook e)
        {

            var reservation = new Reservation
            {
                Id = e.Id,
                Book = e.Book,
                User = e.User,
            };
            //var borrowedBook = _allBooks.First(r => r.Id == reservation.BookId);

            lock (_allReservations)
            {
                _allReservations.Add(reservation);
            }
            //borrowedBook.IsReserved = true;
        }
        public void Handle(ReturnedBook e)
        {
            var returnedReservation = SearchReservation(e.Id);

            lock (_allReservations)
            {
                _allReservations.Remove(returnedReservation);
            }

        }
    }
}
