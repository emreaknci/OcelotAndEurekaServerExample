using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int BkgNumber { get; set; }
        public DateTime? CheckInDate{ get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? BkgDate{ get; set; }
        public int Amount { get; set; }
    }
}
