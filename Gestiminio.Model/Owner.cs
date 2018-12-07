using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Owner
    {
        public string OwnerDni { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }
        public int ApartmentId { get; set; }

    }
}
