using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using Gestiminio.Data;

namespace Gestiminio.Business
{
    public class ReservationBusiness
    {
        ReservationData data = new ReservationData();
        public string addNewReservation(Reservation reservation)
        {
            string msg = "";
            try
            {
                //Validar
                data.addNewReservation(reservation);
                msg = "Reserva creada con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar reserva" + ex.Message;
            }
            return msg;
        }
    }
}
