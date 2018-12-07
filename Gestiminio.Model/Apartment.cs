using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }
        public string OwnerDni { get; set; }
        public string OwnerName { get; set; }
    }
}
