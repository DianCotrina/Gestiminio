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
    public class VisitorController : ApiController
    {
        VisitorBusiness visitorBusiness = new VisitorBusiness();

        [HttpPost]
        public string addNewVisitor(Visitor visitor) {
            string msg = "";
            msg = visitorBusiness.addNewVisitor(visitor);
            return msg;
        }

        [HttpGet]
        public List<Visitor> getVisitorsByOwner(string param) {
            var list = visitorBusiness.getVisitorsByOwner(param);
            return list;
        }
        
    }
}
