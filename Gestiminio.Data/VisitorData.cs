using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using System.Data.SqlClient;

namespace Gestiminio.Data
{
    public class VisitorData
    {
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public VisitorData()
        {

            connection = new SqlConnection(connectionString);

        }
        public void addNewVisitor(Visitor visitor)
        {
            connection.Open();
            string sqlStatement = "sp_addNewVisitor";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventId", visitor.EventId);
            cmd.Parameters.AddWithValue("@EventName", visitor.EventName);
            //cmd.Parameters.AddWithValue("@EventDate", visitor.EventDate);
            cmd.Parameters.AddWithValue("@VisitorName", visitor.VisitorName);
            cmd.Parameters.AddWithValue("@VisitorLastName", visitor.VisitorLastName);
            cmd.Parameters.AddWithValue("@DocumentTypeId", visitor.DocumentTypeId);
            cmd.Parameters.AddWithValue("@DocumentTypeName", visitor.DocumentTypeName);
            cmd.Parameters.AddWithValue("@DocumentNumber", visitor.DocumentNumber);
            cmd.Parameters.AddWithValue("@VisitorEmail", visitor.VisitorEmail);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Visitor> getVisitorsByOwner(string param)
        {
            List<Visitor> list = null;
            connection.Open();
            string sqlStatement = "sp_getVisitorsByOwner";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            

            cmd.Parameters.AddWithValue("@OwnerName", param);

            SqlDataReader reader = cmd.ExecuteReader();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (reader.HasRows)
            {
                list = new List<Visitor>();
                while (true)
                {
                    Visitor visitor = new Visitor();
                    visitor.EventId = int.Parse(reader[""].ToString());
                    visitor.EventName = reader[""].ToString();
                    visitor.EventDate = Convert.ToDateTime(reader[""].ToString());
                    visitor.VisitorName = reader["nombre"].ToString();
                    visitor.VisitorLastName = reader["apellido"].ToString();
                    visitor.DocumentTypeId = int.Parse(reader[""].ToString());
                    visitor.DocumentTypeName = reader[""].ToString();
                    visitor.DocumentNumber = reader["Dni"].ToString();
                    visitor.VisitorEmail = reader["email"].ToString();
                    visitor.UserId = int.Parse(reader[""].ToString());
                    visitor.UserName = reader[""].ToString();
                    list.Add(visitor);
                }
            }
            connection.Close();
            return list;
        }
    }
}
