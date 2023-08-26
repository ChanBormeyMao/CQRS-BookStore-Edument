using Edument.CQRS;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRS
{
    public class WaitListAggregate : Aggregate, IHandleCommand<AddToWaitList>, IApplyEvent<AddedWaitList>, IHandleCommand<RemoveFromWaitList>, IApplyEvent<RemovedWaitList>
    {

        private List<WaitList> _allWaitLists = new List<WaitList>();
        public IEnumerable Handle(AddToWaitList c)
        {
            yield return new AddedWaitList
            {
                Id = c.Id,
                Book = c.Book,
                User = c.User,
            };
        }
        public IEnumerable Handle(RemoveFromWaitList c)
        {
            yield return new RemovedWaitList
            {
                Id = c.Id
            };
        }

        public void Apply(AddedWaitList c)
        {
            var newWaitList = new WaitList()
            {
                Id = c.Id,
                Book = c.Book,
                User = c.User,
            };
            _allWaitLists.Add(newWaitList);
        }
        public void Apply(RemovedWaitList c)
        {
            var waitList = _allWaitLists.First(w => w.Id == c.Id);
            _allWaitLists.Remove(waitList);
        }
    }
}
