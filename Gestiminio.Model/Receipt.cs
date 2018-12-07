using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Receipt
    {
        public int departmentId { get; set; }
        public int amount { get; set; }
        public DateTime receiptExpirationDate { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }

    }
}
