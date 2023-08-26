using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edument.CQRS;
using Book3ReadModels;
using BookNormalCQRS;
using System.Net;
using Book3ReadModels;
using Events;

namespace Book3WebFrontEnd
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        public static IBookReadModel BookList;
        public static IUserReadModel UserList;
        public static IReservationReadModel ReservationList;
        public static IWaitListReadModel WaitListList;


        public static void Setup()
        {
            Dispatcher = new MessageDispatcher(new InMemoryEventStore());

            Dispatcher.ScanInstance(new BookAggregate());
            Dispatcher.ScanInstance(new UserAggregate());
            Dispatcher.ScanInstance(new ReservationAggregate());
            Dispatcher.ScanInstance(new WaitListAggregate());

            BookList = new BookReadModel();
            Dispatcher.ScanInstance(BookList);

            UserList = new UserReadModel();
            Dispatcher.ScanInstance(UserList);

            ReservationList = new ReservationReadModel();
            Dispatcher.ScanInstance(ReservationList);

            WaitListList = new WaitListReadModel();
            Dispatcher.ScanInstance(WaitListList);
        }
    }
}
