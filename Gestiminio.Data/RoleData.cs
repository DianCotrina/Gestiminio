using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class RoleData
    {

        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public RoleData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<Role> getRolesList()
        {
            List<Role> roleList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getRoleList";
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
                roleList = new List<Role>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {


                    //se instancia una variable de clase Trabajador
                    Role role = new Role();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    role.roleId = int.Parse(reader["cod_cargo"].ToString());
                    role.roleName = reader["des_cargo"].ToString();
                    //se agrega a la lista workersList
                    roleList.Add(role);
                }
            }
            //cerrar la conexion
            connection.Close();
            return roleList;
        }
    }
}
