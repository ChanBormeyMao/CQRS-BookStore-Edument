using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Book3ReadModels.WaitListReadModel;

namespace Book3ReadModels
{
    public interface IWaitListReadModel
    {
        List<WaitListReadModel.WaitList> GetAllWaitLists();
        WaitListReadModel.WaitList SearchWaitList(Guid id);
    }
}
