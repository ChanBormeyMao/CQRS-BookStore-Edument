using Book3WebFrontEnd.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookNormalCQRS;
using Events;
using System.Runtime.InteropServices;
using Book3ReadModels;

namespace Book3WebFrontEnd.Controllers
{
    [IncludeLayoutData]
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View(Domain.BookList.GetAllBooks());
        }
        //Create() will lead to the form page where it asked for book title only
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update(Guid? Id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddNewBook m)
        {
            m.Id = Guid.NewGuid();
            m.IsReserved = false;

            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
            //return Content("<script language='javascript' type='text/javascript'>alert('You Book is added');</script>");
        }

        [HttpPost]
        public ActionResult Update(UpdateBook m)
        {

            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(DeleteBook m)
        {

            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateReserve(Guid Id)
        {
            var updateBook = new UpdateReserveStatus()
            {
                Id = Id,
            };
            Domain.Dispatcher.SendCommand(updateBook);
            return RedirectToAction("BorrowedBookList", "Reservation");
        }


    }
}