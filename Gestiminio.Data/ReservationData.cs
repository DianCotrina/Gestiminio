using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gestiminio.Data
{
    public class ReservationData
    {
        SqlConnection connection;
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";

        public ReservationData() {
            connection = new SqlConnection(connectionString);
        }

        public void addNewReservation(Reservation reservation)
        {
            connection.Open();
            string sqlStatement = "sp_addNewReservation";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@reservationId", reservation.reservationId);
            cmd.Parameters.AddWithValue("@reservationTime", reservation.reservationTime);
            cmd.Parameters.AddWithValue("@commonAreaId", reservation.commonAreaId);
            cmd.Parameters.AddWithValue("@commonAreaName", reservation.commonAreaName);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
