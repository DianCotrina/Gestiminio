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
    public class StatusController : ApiController
    {
        StatusBusiness statusBusiness = new StatusBusiness();

        [HttpGet]
        public List<Status> getStatusList() {
            var list = statusBusiness.getStatusList();
            return list;
        }

    }
}
