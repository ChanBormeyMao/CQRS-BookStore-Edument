using Book3WebFrontEnd.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookNormalCQRS;
using Events;
using Book3WebFrontEnd;

namespace User3WebFrontEnd.Controllers
{
    [IncludeLayoutData]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View(Domain.UserList.GetAllUsers());
        }
        //Create() will lead to the form page where it asked for User title only
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update(Guid? Id, string UserName, string UserEmail)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddNewUser m)
        {
            m.Id = Guid.NewGuid();
            m.UserName = m.UserName;
            m.UserEmail = m.UserEmail;
            //var newUser = new Events.AddedUser { UserId = m.UserId, UserTitle = m.UserTitle, IsReserved = m.IsReserved };
            //Domain.UserList.Handle(m);
            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
            //return Content("<script language='javascript' type='text/javascript'>alert('You User is added');</script>");
        }

        [HttpPost]
        public ActionResult Update(UpdateUser m)
        {

            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(DeleteUser m)
        {

            Domain.Dispatcher.SendCommand(m);
            return RedirectToAction("Index");
        }
    }
}