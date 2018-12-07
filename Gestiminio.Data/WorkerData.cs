using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class WorkerData
    {
        SqlConnection connection;
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";

        public WorkerData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<Worker> getWorkersList()
        {
            List<Worker> workersList = null;
            connection.Open();
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getWorkersList";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                    worker.workerEmail = reader["email"].ToString();
                    worker.workerPhoneNumber = reader["telefono"].ToString();
                    worker.workerRoleId = int.Parse(reader["cod_cargo"].ToString());
                    worker.workerRoleDescription = reader["des_cargo"].ToString();
                    worker.workerStartDate = Convert.ToDateTime(reader["fechaIngreso"]);
                    worker.workerStatusId = int.Parse(reader["codigoEstado"].ToString());
                    worker.workerStatusDescription = reader["descripcionEstado"].ToString();
                    //se agrega a la lista workersList
                    workersList.Add(worker);
                }
            }
            //cerrar la conexion
            connection.Close();
            return workersList;
        }

        public List<Worker> getAllWorkersList()
        {
            List<Worker> workersList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getAllWorkersList";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //crear el reader y ejecutar el command
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                    worker.workerEmail = reader["email"].ToString();
                    worker.workerPhoneNumber = reader["telefono"].ToString();
                    worker.workerRoleId = int.Parse(reader["cod_cargo"].ToString());
                    worker.workerRoleDescription = reader["des_cargo"].ToString();
                    worker.workerStartDate = Convert.ToDateTime(reader["fechaIngreso"]);
                    worker.workerStatusId = int.Parse(reader["codigoEstado"].ToString());
                    worker.workerStatusDescription = reader["descripcionEstado"].ToString();
                    //se agrega a la lista workersList
                    workersList.Add(worker);
                }
            }
            //cerrar la conexion
            connection.Close();
            return workersList;
        }

        public void addWorker(Worker worker)
        {
            connection.Open();
            string sqlStatement = "sp_addWorker";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@workerDni", worker.workerDni);
            cmd.Parameters.AddWithValue("@workerName", worker.workerName);
            cmd.Parameters.AddWithValue("@workerLastName", worker.workerLastName);
            cmd.Parameters.AddWithValue("@workerEmail", worker.workerEmail);
            cmd.Parameters.AddWithValue("@workerPhoneNumber", worker.workerPhoneNumber);
            cmd.Parameters.AddWithValue("@workerRoleId", worker.workerRoleId);
            //cmd.Parameters.AddWithValue("@workerStartDate", worker.workerStartDate);
            cmd.Parameters.AddWithValue("@workerStatusId", worker.workerStatusId);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void updateWorker(Worker worker)
        {

            connection.Open();
            string sqlStatement = "sp_updateWorker";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@workerDni", worker.workerDni);
            cmd.Parameters.AddWithValue("@workerName", worker.workerName);
            cmd.Parameters.AddWithValue("@workerLastName", worker.workerLastName);
            cmd.Parameters.AddWithValue("@workerEmail", worker.workerEmail);
            cmd.Parameters.AddWithValue("@workerPhoneNumber", worker.workerPhoneNumber);
            cmd.Parameters.AddWithValue("@workerRoleId", worker.workerRoleId);
            //cmd.Parameters.AddWithValue("@workerStartDate", worker.workerStartDate);
            cmd.Parameters.AddWithValue("@workerStatusId", worker.workerStatusId);
            cmd.ExecuteNonQuery();


            connection.Close();
        }

        public void deleteWorker(string workerDni)
        {
            connection.Open();
            string sqlStatement = "sp_deleteWorker";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@workerDni", workerDni);

            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}

