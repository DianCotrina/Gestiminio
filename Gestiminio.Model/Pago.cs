using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Pago
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ApartmentId { get; set; }
        public string ApartmentNumber { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeDes { get; set; }
    }
}
