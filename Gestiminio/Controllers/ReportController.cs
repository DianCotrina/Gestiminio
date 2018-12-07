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
    public class ReportController : ApiController
    {
        ReportBusiness reportBusiness = new ReportBusiness();

        [HttpGet]
        public List<Worker> getWorkersReport(DateTime startDate, DateTime finishDate) {
            return reportBusiness.getWorkersReport(startDate, finishDate);
        }

        [HttpGet]
        public List<Visitor> getVisitorsReport(DateTime startDate, DateTime finishDate) {
            return reportBusiness.getVisitorsReport(startDate, finishDate);
        }
    }
}
