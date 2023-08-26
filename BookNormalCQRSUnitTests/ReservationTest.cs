using BookNormalCQRS;
using Edument.CQRS;
using Events;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRSUnitTests
{

    [TestFixture]
    public class ReservationTest : BDDTest<ReservationAggregate>
    {

        private Guid _userId;
        private Guid _bookId;
        private Guid _reservationId;

        [SetUp]
        public void Setup()
        {
            _reservationId = Guid.NewGuid();
            _userId = Guid.NewGuid();
            _bookId = Guid.NewGuid();


        }
        [Test]
        public void CannotBorrowBookTest()
        {
            Test(
                Given(),
                When(new BorrowBook
                {
                    UserId = _userId,
                    BookId = _bookId
                }),
                ThenFailWith<CanNotBorrowBook>());
        }
        //[Test]
        //public void BorrowBookTest()
        //{
        //    Test(
        //        Given(new BorrowedBookReservation
        //        {
        //            Item = new Reservation { BookId = _bookId, UserId = _userId, ReservationId = _reservationId },
        //        }),
        //        When(new MakeReservation
        //        {
        //            ReservationId = _reservationId,
        //            UserId = _userId,
        //            BookId = _bookId
        //        }),
        //        Then(new Reservation
        //        {
        //            ReservationId = _reservationId,
        //            UserId = _userId,
        //            BookId = _bookId
        //        }));
        //}
        //[Test]
        //public void ReturnBookTest()
        //{
        //    Test(
        //        Given(new ReturnBookReservation
        //        {
        //            Item = new Reservation { BookId = _bookId, UserId = _userId, ReservationId = _reservationId },
        //        }),
        //        When(new MakeReservation
        //        {
        //            ReservationId = _reservationId,
        //            UserId = _userId,
        //            BookId = _bookId
        //        }),
        //        Then(new Reservation
        //        {
        //            ReservationId = _reservationId,
        //            UserId = _userId,
        //            BookId = _bookId
        //        }));
        //}
    }
}
