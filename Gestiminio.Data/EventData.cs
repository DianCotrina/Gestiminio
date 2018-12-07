using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using System.Data.SqlClient;

namespace Gestiminio.Data
{
    public class EventData
    {
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public EventData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<Event> getAllEvents()
        {
            List<Event> eventList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getEventList";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //crear el reader y ejecutar el command
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //abrir la conexion
            connection.Open();
            //verificar que tenga filas para leer con un if statement
            if (reader.HasRows)
            {
                //inicializamos la lista de trabajadores
                eventList = new List<Event>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {
                    //se instancia una variable de clase Trabajador
                    Event even = new Event();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    even.EventId = int.Parse(reader["event_id"].ToString());
                    even.EventName = reader["event_des"].ToString();
                    //se agrega a la lista workersList
                    eventList.Add(even);
                }
            }
            //cerrar la conexion
            connection.Close();
            return eventList;
        }
       
    }
}
