using Edument.CQRS;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public class WaitListReadModel : IWaitListReadModel, ISubscribeTo<AddedWaitList>, ISubscribeTo<RemovedWaitList>
    {
        public class WaitList
        {
            public Guid Id;
            public User User { get; set; }
            public Book Book { get; set; }
        }

        private List<WaitList> _allWaitLists = new List<WaitList>();

        public List<WaitList> GetAllWaitLists()
        {
            lock (_allWaitLists)
            {
                return (from w in _allWaitLists
                        select new WaitList
                        {
                            Id = w.Id,
                            User = w.User,
                            Book = w.Book,
                        }).ToList();
            }
        }
        public WaitList SearchWaitList(Guid id)
        {
            return _allWaitLists.First(w => w.Id == id);
        }
        public void Handle(AddedWaitList e)
        {
            var addedWaitlist = new WaitList()
            {
                Id = e.Id,
                Book = e.Book,
                User = e.User,
            };
            lock (_allWaitLists)
            {
                _allWaitLists.Add(addedWaitlist);
            }
        }
        public void Handle(RemovedWaitList e)
        {
            var removedWaitlist = SearchWaitList(e.Id);
            lock (_allWaitLists)
            {
                _allWaitLists.Remove(removedWaitlist);
            }
        }
    }
}
