using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class WorkerBusiness
    {
        WorkerData data = new WorkerData();

        public List<Worker> getWorkersList()
        {
            return data.getWorkersList();
        }

        public string addWorker(Worker worker)
        {
            string msg = "";
            try
            {
                worker.Validar();
                data.addWorker(worker);
                msg = "Trabajador registrado con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar trabajador" + ex.Message;
            }
            return msg;
        }

        public string updateWorker(Worker worker)
        {
            string msg = "";
            try
            {
                if (worker.workerDni.Equals(""))
                {
                    msg = "¡Trabajador no válido!";
                }
                else
                {
                    var existeTrabajador = data.getAllWorkersList().Any(x => x.workerDni == worker.workerDni);
                    if (existeTrabajador)
                    {
                        worker.Validar();
                        data.updateWorker(worker);
                        msg = "Trabajador actualizado con éxito";
                    }
                    else
                    {
                        msg = "¡Trabajador no existe!";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Error al actualizar trabajador" + ex.Message;
            }
            return msg;
        }

        public string deleteWorker(string workerDni)
        {
            string msg = "";
            try
            {
                if (workerDni.Equals(""))
                {
                    msg = "¡Trabajador no válido!";
                }
                else
                {
                    var existeUsuario = data.getWorkersList().Any(x => x.workerDni == workerDni);
                    if (existeUsuario)
                    {
                        data.deleteWorker(workerDni);
                        msg = "Trabajador eliminado con éxito";
                    }
                    else
                    {
                        msg = "¡Trabajador no existe!";
                    }

                }
            }
            catch (Exception ex)
            {
                msg = "Error al eliminar trabajador" + ex.Message;
            }
            return msg;
        }
        

    }
}
