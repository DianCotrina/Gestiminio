using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gestiminio.Model;
using Gestiminio.Business;
using System.Web.Http.Cors;

namespace Gestiminio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservationController : ApiController
    {
        ReservationBusiness reservationBusiness = new ReservationBusiness();

        [HttpPost]
        public string addNewReservation(Reservation reservation) {
            string msg = "";
            msg = reservationBusiness.addNewReservation(reservation);
            return msg;
        }
    }
}
