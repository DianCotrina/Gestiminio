using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Visitor
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string VisitorLastName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentNumber { get; set; }
        public string VisitorEmail { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }

    }
}
