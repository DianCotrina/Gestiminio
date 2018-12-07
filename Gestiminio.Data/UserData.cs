using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class UserData
    {
        //string connectionString = "Server=?\\SQLEXPRESS;database=?;Integrated Security=true";
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public UserData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<User> getUsersList()
        {
            List<User> usersList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getUsersList";
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
                usersList = new List<User>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {

                    //se instancia una variable de clase Trabajador
                    User user = new User();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    user.userId = int.Parse(reader["codigoUsuario"].ToString());
                    user.userTypeId = int.Parse(reader["codigoTipoUsuario"].ToString());
                    user.userTypeDescription = reader["descripcionTipoUsuario"].ToString();
                    user.userIdDescription = reader["userCodigoDes"].ToString();
                    user.userPassword = reader["passwordUsuario"].ToString();
                    user.userDni = reader["Dni"].ToString();
                    user.userName = reader["nombreUsuario"].ToString();
                    user.userLastName = reader["apellidoPropietario"].ToString();
                    user.userPhoneNumber = reader["telefono"].ToString();
                    user.userEmail = reader["email"].ToString();
                    user.userStartDate = Convert.ToDateTime(reader["fechaIngreso"]);
                    user.userStatusId = int.Parse(reader["codigoEstado"].ToString());
                    user.userStatusDescription = reader["descripcionEstado"].ToString();
                    user.ApartmentId = int.Parse(reader[""].ToString());
                    user.AparmentNumber = reader[""].ToString();
                    //se agrega a la lista workersList
                    usersList.Add(user);
                }
            }
            //cerrar la conexion
            connection.Close();
            return usersList;
        }

        public List<User> getAllUsersList()
        {
            List<User> usersList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getAllUsersList";
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
                usersList = new List<User>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {

                    //se instancia una variable de clase Trabajador
                    User user = new User();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    user.userId = int.Parse(reader["codigoUsuario"].ToString());
                    user.userTypeId = int.Parse(reader["codigoTipoUsuario"].ToString());
                    user.userTypeDescription = reader["descripcionTipoUsuario"].ToString();
                    user.userIdDescription = reader["userCodigoDes"].ToString();
                    user.userPassword = reader["passwordUsuario"].ToString();
                    user.userDni = reader["Dni"].ToString();
                    user.userName = reader["nombreUsuario"].ToString();
                    user.userLastName = reader["apellidoPropietario"].ToString();
                    user.userPhoneNumber = reader["telefono"].ToString();
                    user.userEmail = reader["email"].ToString();
                    user.userStartDate = Convert.ToDateTime(reader["fechaIngreso"]);
                    user.userStatusId = int.Parse(reader["codigoEstado"].ToString());
                    user.userStatusDescription = reader["descripcionEstado"].ToString();
                    //se agrega a la lista workersList
                    usersList.Add(user);
                }
            }
            //cerrar la conexion
            connection.Close();
            return usersList;
        }

        public void addUser(User user)
        {
            connection.Open();
            string sqlStatement = "sp_addNewUser";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userTypeId", user.userTypeId);
            cmd.Parameters.AddWithValue("@userIdDescription", user.userIdDescription);
            cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
            cmd.Parameters.AddWithValue("@userDni", user.userDni);
            cmd.Parameters.AddWithValue("@userName", user.userName);
            cmd.Parameters.AddWithValue("@userLastName", user.userLastName);
            cmd.Parameters.AddWithValue("@userPhoneNumber", user.userStatusId);
            cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
            //cmd.Parameters.AddWithValue("@userStartDate", user.userStartDate);
            cmd.Parameters.AddWithValue("@userStatusId", user.userStatusId);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void updateUser(User user)
        {

            connection.Open();
            string sqlStatement = "sp_updateUser";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", user.userId);
            cmd.Parameters.AddWithValue("@userTypeId", user.userTypeId);
            cmd.Parameters.AddWithValue("@userIdDescription", user.userIdDescription);
            cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
            cmd.Parameters.AddWithValue("@userDni", user.userDni);
            cmd.Parameters.AddWithValue("@userName", user.userName);
            cmd.Parameters.AddWithValue("@userLastName", user.userLastName);
            cmd.Parameters.AddWithValue("@userPhoneNumber", user.userStatusId);
            cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
            //cmd.Parameters.AddWithValue("@userStartDate", user.userStartDate);
            cmd.Parameters.AddWithValue("@userStatusId", user.userStatusId);
            cmd.ExecuteNonQuery();


            connection.Close();
        }

        public void deleteUser(int userId)
        {
            connection.Open();
            string sqlStatement = "sp_deleteUser";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", userId);

            cmd.ExecuteNonQuery();

            connection.Close();

        }

        public User loginUser(string email, string pwd)
        {
            User user = null;
            connection.Open();
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_Login";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", pwd);
            //crear el reader y ejecutar el command
            
            SqlDataReader reader = cmd.ExecuteReader();


            //abrir la conexion

            //verificar que tenga filas para leer con un if statement
            if (reader.HasRows)
            {
                //inicializamos la lista de trabajadores
                user = new User();
                //se lee el arreglo en un while block
                while (reader.Read())
                {
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    user.userId = int.Parse(reader["codigoUsuario"].ToString());
                    user.userEmail = reader["email"].ToString();
                    user.userPassword = reader["passwordUsuario"].ToString();
                    user.userTypeId = int.Parse(reader["codigoTipoUsuario"].ToString());
                    user.userTypeDescription = reader["descripcionTipoUsuario"].ToString();

                    //se agrega a la lista workersList
                }
            }
            //cerrar la conexion
            connection.Close();
            return user;
        }
    }
}
