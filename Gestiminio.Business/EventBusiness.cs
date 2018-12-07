using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class EventBusiness
    {
        EventData data = new EventData();
        public List<Event> getAllEvents()
        {
            return data.getAllEvents();
        }
    }
}
