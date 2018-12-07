using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Data
{
    public class ReceiptData
    {
        string connectionString = "Server=DESKTOP-OLDNQMA\\SQLEXPRESS;database=Gestiminio;Integrated Security=true";
        SqlConnection connection;

        public ReceiptData()
        {
            connection = new SqlConnection(connectionString);
        }

        public void addNewReceipt(Receipt receipt)
        {
            connection.Open();

            string sqlStatement = "sp_addReceipt";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@departmentId", receipt.apartmentId);
            cmd.Parameters.AddWithValue("@amount", receipt.amount);
            cmd.Parameters.AddWithValue("@receiptExpirationDate", receipt.receiptExpirationDate);
            cmd.Parameters.AddWithValue("@receiptPaymentDate", receipt.receiptPaymentDate);
            cmd.Parameters.AddWithValue("@monthId", receipt.monthId);
            cmd.Parameters.AddWithValue("@userId", receipt.userId);
            cmd.Parameters.AddWithValue("@receiptStatusId", receipt.receiptStatusId);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Receipt> getReceiptByDate(DateTime date)
        {
            List<Receipt> receiptList = null;
            connection.Open();
            //crear Sqlstatement y poner el nombre del SP
            var sqlStatement = "";
            //crear command y asignarle los parametros del statement más la conexion
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dateparam", date);


            //crear el reader y ejecutar el command
            
            SqlDataReader reader = cmd.ExecuteReader();
            

            //abrir la conexion

            //verificar que tenga filas para leer con un if statement
            if (reader.HasRows)
            {
                //inicializamos la lista de trabajadores
                receiptList = new List<Receipt>();
                //se lee el arreglo en un while block
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.apartmentId = int.Parse(reader[""].ToString());
                    receipt.apartmentNumber = reader[""].ToString();
                    receipt.amount = int.Parse(reader[""].ToString());
                    receipt.receiptExpirationDate = Convert.ToDateTime(reader["fechaVencimiento"]);
                    receipt.receiptPaymentDate = Convert.ToDateTime(reader[""]);
                    receipt.monthId = int.Parse(reader[""].ToString());
                    receipt.monthDes = reader[""].ToString();
                    receipt.userId = int.Parse(reader[""].ToString());
                    receipt.userName = reader[""].ToString();
                    receipt.receiptStatusId = int.Parse(reader[""].ToString());
                    receipt.receiptStatusDes = reader[""].ToString();

                    receiptList.Add(receipt);
                }
            }
            //cerrar la conexion
            connection.Close();
            return receiptList;
        }

        /*public void addReceipt()
        {
            connection.Open();

            string sqlStatement = "sp_addReceipt";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@");
        }
        */
    }
}
