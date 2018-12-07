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
    public class WorkerController : ApiController
    {
        WorkerBusiness workerBusiness = new WorkerBusiness();

        [HttpGet]
        public List<Worker> getWorkersList() {
            var list = workerBusiness.getWorkersList();
            return list;
        }

        [HttpGet]
        public Worker getWorkersListById(string workerDni) {
            var list = workerBusiness.getWorkersList();
            Worker worker = list.FirstOrDefault(x => x.workerDni == workerDni);
            return worker;
        }

        [HttpPost]
        public string createWorker(Worker worker) {
            string msg = "";
            msg = workerBusiness.addWorker(worker);
            return msg;
        }

        [HttpPost]
        public string updateWorker(Worker worker) {
            string msg = "";
            msg = workerBusiness.updateWorker(worker);
            return msg;
        }

        [HttpPost]
        public string deleteWorker(string workerDni) {
            string msg = "";
            msg = workerBusiness.deleteWorker(workerDni);
            return msg;
        }
    }
}
