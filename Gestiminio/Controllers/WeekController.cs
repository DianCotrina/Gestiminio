using Gestiminio.Business;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gestiminio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeekController : ApiController
    {
        WeekBusiness weekBusiness = new WeekBusiness();
        public List<Week> getAllDaysOnWeek() {
            var list = weekBusiness.getAllDaysOnWeek();
            return list;
        }
    }
}
