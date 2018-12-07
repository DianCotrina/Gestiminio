using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using System.Data.SqlClient;

namespace Gestiminio.Data
{
    public class ReportData
    {
        SqlConnection connection;
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";

        public ReportData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<Worker> getWorkersReport(DateTime startDate, DateTime finishDate)
        {
            List<Worker> workersList = null;
            connection.Open();
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getWorkersReport";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@finishDate", finishDate);
            //crear el reader y ejecutar el command
           
            SqlDataReader reader = cmd.ExecuteReader();
            

            //abrir la conexion

            //verificar que tenga filas para leer con un if statement
            if (reader.HasRows)
            {
                //inicializamos la lista de trabajadores
                workersList = new List<Worker>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {
                    //se instancia una variable de clase Trabajador
                    Worker worker = new Worker();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    worker.workerDni = reader["Dni"].ToString();
                    worker.workerName = reader["nombretrabajador"].ToString();
                    worker.workerLastName = reader["apellidoTrabajador"].ToString();
                    worker.workerStartDate = Convert.ToDateTime(reader["fechaIngreso"]);
                    worker.workerFinishDate = Convert.ToDateTime(reader["fechaSalida"]);
                    //se agrega a la lista workersList
                    workersList.Add(worker);
                }
            }
            //cerrar la conexion
            connection.Close();
            return workersList;
        }

        public List<Visitor> getVisitorsReport(DateTime startDate, DateTime finishDate)
        {
            List<Visitor> visitorList = null;
            connection.Open();
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getVisitorReport";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@finishDate", finishDate);
            //crear el reader y ejecutar el command

            SqlDataReader reader = cmd.ExecuteReader();


            //abrir la conexion

            //verificar que tenga filas para leer con un if statement
            if (reader.HasRows)
            {
                //inicializamos la lista de trabajadores
                visitorList = new List<Visitor>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {
                    //se instancia una variable de clase Trabajador
                    Visitor visitor = new Visitor();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    visitor.DocumentNumber = reader[""].ToString();
                    visitor.VisitorName = reader[""].ToString();
                    visitor.ApartmentId = int.Parse(reader[""].ToString());
                    visitor.ApartmentName = reader[""].ToString();
                    visitor.EventDate = Convert.ToDateTime(reader[""].ToString());
                    //se agrega a la lista workersList
                    visitorList.Add(visitor);
                }
            }
            //cerrar la conexion
            connection.Close();
            return visitorList;
        }
    }
}
