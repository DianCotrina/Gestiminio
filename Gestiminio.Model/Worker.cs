using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class Worker
    {
        public string  workerDni { get; set; }
        public string workerName { get; set; }
        public string  workerLastName { get; set; }
        public string workerEmail { get; set; }
        public string workerPhoneNumber { get; set; }
        public int workerRoleId { get; set; }
        public string workerRoleDescription { get; set; }
        public DateTime workerStartDate { get; set; }
        public int workerStatusId { get; set; }
        public string workerStatusDescription { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(workerDni))
                throw new Exception("Debe colocar el dni del trabajador");
            if (workerDni.Length != 8)
                throw new Exception("El dni del trabajador debe tener 8 caracteres");
            if (string.IsNullOrEmpty(workerName))
                throw new Exception("Debe colocar el nombre del trabajador");
            if (string.IsNullOrEmpty(workerLastName))
                throw new Exception("Debe colocar el apellido del trabajador");
            if (string.IsNullOrEmpty(workerEmail))
                throw new Exception("Debe colocar el correo electronico del trabajador");
            if (string.IsNullOrEmpty(workerPhoneNumber))
                throw new Exception("Debe colocar el número del trabajador");
            if (workerPhoneNumber.Length != 9)
                throw new Exception("El número del trabajador debe tener 9 caracteres");
            if (string.IsNullOrEmpty(workerRoleId.ToString()))
                throw new Exception("Debe seleccionar un rol de trabajador");
            if (string.IsNullOrEmpty(Convert.ToDateTime(workerStartDate).ToString()))
                throw new Exception("Debe seleccionar la fecha de ingreso del trabajador");
            if (string.IsNullOrEmpty(workerStatusId.ToString()))
                throw new Exception("Debe seleccionar un estado del trabajador");
         
        }
    }
}
