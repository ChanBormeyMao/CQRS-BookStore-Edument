using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public interface IReservationReadModel
    {
        List<ReservationReadModel.Reservation> GetAllreservations();
        ReservationReadModel.Reservation SearchReservation(Guid Id);
    }
}