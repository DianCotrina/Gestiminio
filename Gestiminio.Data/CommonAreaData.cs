using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class CommonAreaData
    {
        //string connectionString = "Server=?\\SQLEXPRESS;database=?;Integrated Security=true";
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public CommonAreaData()
        {

            connection = new SqlConnection(connectionString);

        }

        public List<CommonArea> getCommonAreaList()
        {
            List<CommonArea> commonAreaList = null;
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "sp_getCommonAreaList";
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
                commonAreaList = new List<CommonArea>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {

                    //se instancia una variable de clase Trabajador
                    CommonArea commonArea = new CommonArea();
                    // se parsean mediante el reader los atributos de la tabla tb_trabajador
                    commonArea.commonAreaId = reader["codigoAreaComun"].ToString();
                    commonArea.commonAreaName = reader["nombreAreaComun"].ToString();
                    commonArea.commonAreaDescription = reader["descripcionAreaComun"].ToString();
                    commonArea.commonAreaReservationLimits = int.Parse(reader["LimiteReservaAreaComun"].ToString());
                    commonArea.commonAreaMonday = int.Parse(reader["lunes"].ToString());
                    commonArea.commonAreaTuesday = int.Parse(reader["martes"].ToString());
                    commonArea.commonAreaWednesday = int.Parse(reader["miercoles"].ToString());
                    commonArea.commonAreaThursday = int.Parse(reader["jueves"].ToString());
                    commonArea.commonAreaFriday = int.Parse(reader["viernes"].ToString());
                    commonArea.commonAreaSaturday = int.Parse(reader["sabado"].ToString());
                    commonArea.commonAreaSunday = int.Parse(reader["domingo"].ToString());
                    //se agrega a la lista workersList
                    commonAreaList.Add(commonArea);
                }
            }
            //cerrar la conexion
            connection.Close();
            return commonAreaList;
        }

        public List<CommonArea> getCommonAreasByPreference(string param)
        {
            List<CommonArea> list = null;
            connection.Open();
            var statement = "sp_getCommonAreaByPreference";
            SqlCommand cmd = new SqlCommand(statement, connection);

            cmd.Parameters.AddWithValue("@param", param);

            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (reader.HasRows)
            {
                CommonArea commonArea = new CommonArea();

                while (reader.Read())
                {
                    commonArea.commonAreaId = reader["codigoAreaComun"].ToString();
                    commonArea.commonAreaName = reader["nombreAreaComun"].ToString();
                    commonArea.commonAreaDescription = reader["descripcionAreaComun"].ToString();

                    list.Add(commonArea);
                }

            }
            connection.Close();
            return list;
        }

        public void addCommonArea(CommonArea area)
        {
            connection.Open();
            string sqlStatement = "sp_addCommonArea";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@commonAreaId", area.commonAreaId);
            cmd.Parameters.AddWithValue("@commonAreaName", area.commonAreaName);
            cmd.Parameters.AddWithValue("@commonAreaDescription", area.commonAreaDescription);
            cmd.Parameters.AddWithValue("@commonAreaReservationLimits", area.commonAreaReservationLimits);
            cmd.Parameters.AddWithValue("@commonAreaMonday", area.commonAreaMonday);
            cmd.Parameters.AddWithValue("@commonAreaTuesday", area.commonAreaTuesday);
            cmd.Parameters.AddWithValue("@commonAreaWednesday", area.commonAreaWednesday);
            cmd.Parameters.AddWithValue("@commonAreaThursday", area.commonAreaThursday);
            cmd.Parameters.AddWithValue("@commonAreaFriday", area.commonAreaFriday);
            cmd.Parameters.AddWithValue("@commonAreaSaturday", area.commonAreaSaturday);
            cmd.Parameters.AddWithValue("@commonAreaSunday", area.commonAreaSunday);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void updateCommonArea(CommonArea area)
        {

            connection.Open();
            string sqlStatement = "sp_updateCommonArea";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@commonAreaId", area.commonAreaId);
            cmd.Parameters.AddWithValue("@commonAreaName", area.commonAreaName);
            cmd.Parameters.AddWithValue("@commonAreaDescription", area.commonAreaDescription);
            cmd.Parameters.AddWithValue("@commonAreaReservationLimits", area.commonAreaReservationLimits);
            cmd.Parameters.AddWithValue("@commonAreaMonday", area.commonAreaMonday);
            cmd.Parameters.AddWithValue("@commonAreaTuesday", area.commonAreaTuesday);
            cmd.Parameters.AddWithValue("@commonAreaWednesday", area.commonAreaWednesday);
            cmd.Parameters.AddWithValue("@commonAreaThursday", area.commonAreaThursday);
            cmd.Parameters.AddWithValue("@commonAreaFriday", area.commonAreaFriday);
            cmd.Parameters.AddWithValue("@commonAreaSaturday", area.commonAreaSaturday);
            cmd.Parameters.AddWithValue("@commonAreaSunday", area.commonAreaSunday);
            cmd.ExecuteNonQuery();


            connection.Close();
        }

        public void deleteCommonArea(string commonAreaId)
        {
            connection.Open();
            string sqlStatement = "sp_deleteCommonArea";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@commonAreaId", commonAreaId);

            cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}
