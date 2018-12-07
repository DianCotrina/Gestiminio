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
    public class ReceiptController : ApiController
    {
        ReceiptBusiness receiptBusiness = new ReceiptBusiness();

        [HttpPost]
        public string addNewReceipt(Receipt receipt) {
            var msg = "";
            msg = receiptBusiness.addNewReceipt(receipt);
            return msg;
        }

        [HttpGet]
        public List<Receipt> getReceiptByDate(DateTime date) {
            return receiptBusiness.getReceiptByDate(date);
        }
    }
}
