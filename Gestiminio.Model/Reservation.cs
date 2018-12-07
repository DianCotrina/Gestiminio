using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Reservation
    {
        public int reservationId { get; set; }
        public int reservationTime { get; set; }
        public int commonAreaId { get; set; }
        public string commonAreaName { get; set; }
        public DateTime reservationDate { get; set; }
    }
}
