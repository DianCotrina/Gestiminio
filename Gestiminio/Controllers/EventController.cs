using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gestiminio.Model;
using Gestiminio.Business;
using System.Web.Http.Cors;

namespace Gestiminio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventController : ApiController
    {
        EventBusiness eventBusiness = new EventBusiness();

        [HttpGet]
        public List<Event> getAllEvents() {
            var list = eventBusiness.getAllEvents();
            return list;
        }
    }
}
