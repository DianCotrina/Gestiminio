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
    public class RoleController : ApiController
    {
        RoleBusiness roleBusiness = new RoleBusiness();

        [HttpGet]
        public List<Role> getRolesList() {
            var list = roleBusiness.getRolesList();
            return list;
        }
    }
}
