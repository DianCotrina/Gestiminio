using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Receipt
    {
        public int apartmentId { get; set; }
        public string  apartmentNumber { get; set; }
        public int amount { get; set; }
        public DateTime receiptExpirationDate { get; set; }
        public DateTime receiptPaymentDate { get; set; }
        public int monthId { get; set; }
        public string monthDes { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int receiptStatusId { get; set; }
        public string receiptStatusDes { get; set; }

    }
}
