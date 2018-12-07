using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class StatusData
    {
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public StatusData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<Status> getStatusList()
        {
            List<Status> statusList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getStatusList";
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
                statusList = new List<Status>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {


                    //se instancia una variable de clase Trabajador
                    Status status = new Status();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    status.statusId = int.Parse(reader["codigoEstado"].ToString());
                    status.statusName = reader["descripcionEstado"].ToString();
                    //se agrega a la lista workersList
                    statusList.Add(status);
                }
            }
            //cerrar la conexion
            connection.Close();
            return statusList;
        }



    }
}
