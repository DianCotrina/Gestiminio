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
    public class CommonAreaController : ApiController
    {
        CommonAreaBusiness commonAreaBusiness = new CommonAreaBusiness();

        [HttpGet]
        public List<CommonArea> getCommonAreaList()
        {
            var list = commonAreaBusiness.getCommonAreaList();
            return list;
        }

        [HttpGet]
        public CommonArea getAreaById(string param)
        {
            var list = commonAreaBusiness.getCommonAreaList();
            CommonArea area = list.FirstOrDefault(x => x.commonAreaId == param);
            return area;
        }

        [HttpPost]
        public string createCommonArea(CommonArea area)
        {
            string msg = "";
            msg = commonAreaBusiness.addCommonArea(area);
            return msg;
        }

        [HttpPost]
        public string updateCommonArea(CommonArea area)
        {
            string msg = "";
            msg = commonAreaBusiness.updateCommonArea(area);
            return msg;
        }

        [HttpPost]
        public string deleteCommonArea(string param)
        {
            string msg = "";
            msg = commonAreaBusiness.deleteCommonArea(param);
            return msg;
        }

        [HttpGet]
        public List<CommonArea> getCommonAreasByPreference(string param) {
            var list = commonAreaBusiness.getCommonAreasByPreference(param);
            return list;
        }
    }
}
