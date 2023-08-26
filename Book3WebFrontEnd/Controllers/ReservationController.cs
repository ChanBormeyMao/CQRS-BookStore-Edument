using Book3WebFrontEnd.ActionFilters;
using BookNormalCQRS;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book3WebFrontEnd.Controllers
{
    public class ReservationController : Controller
    {
        [IncludeLayoutData]
        public ActionResult BorrowedBookList()
        {
            return View(Domain.ReservationList.GetAllreservations());
        }

        public ActionResult Borrow(Guid? BookId, Guid? UserId)
        {
            var b = Domain.BookList.SearchedBook((Guid)BookId);
            var book = new Book()
            {
                Id = b.Id,
                BookTitle = b.BookTitle,
                IsReserved = b.IsReserved,
            };
            var u = Domain.UserList.SearchUser((Guid)UserId);
            var user = new User()
            {
                Id = u.Id,
                UserName = u.UserName,
                UserEmail = u.UserEmail
            };
            var newreservation = new BorrowBook()
            {
                Id = Guid.NewGuid(),
                Book = book,
                User = user
            };
            Domain.Dispatcher.SendCommand(newreservation);
            return RedirectToAction("UpdateReserve", "Book", new { Id = book.Id });
        }
        public ActionResult Return(ReturnBook m)
        {
            var r = Domain.ReservationList.SearchReservation(m.Id);
            var BookId = Domain.BookList.SearchedBook(r.Book.Id).Id;
            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("UpdateReserve", "Book", new { Id = BookId });
        }
    }
}