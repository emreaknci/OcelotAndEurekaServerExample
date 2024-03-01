using Reservation.Infrastracture;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class ReservationService : IReservationService
    {
        public ReservationDTO GetReservationById(int id)
        {
            return new (){
            Id = id,
            Amount = 1500,
            BkgDate = DateTime.Now,
            BkgNumber = 123,
            CheckInDate = DateTime.Now.AddDays(5),
            CheckOutDate = DateTime.Now.AddDays(7),
            };
        }
    }
}
