using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using Gestiminio.Data;

namespace Gestiminio.Business
{
    public class ReceiptBusiness
    {
        ReceiptData data = new ReceiptData();
        public string addNewReceipt(Receipt receipt)
        {
            string msg = "";
            try
            {
                //receipt.validar();
                data.addNewReceipt(receipt);
                msg = "Trabajador registrado con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar recibo" + ex.Message;
            }
            return msg;
        }

        public List<Receipt> getReceiptByDate(DateTime date)
        {
            return data.getReceiptByDate(date);
        }
    }
}
