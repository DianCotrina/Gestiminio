using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class CommonArea
    {
        public string commonAreaId { get; set; }
        public string commonAreaName { get; set; }
        public string commonAreaDescription { get; set; }
        public int commonAreaReservationLimits { get; set; }
        public int commonAreaStatusId { get; set; }
        public string commonAreaStatusDes { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(commonAreaId.ToString()))
                throw new Exception("Debe colocar el dni del trabajador");
            if (string.IsNullOrEmpty(commonAreaName))
                throw new Exception("Debe colocar el usuario del propietario o administrador");
            if (string.IsNullOrEmpty(commonAreaDescription))
                throw new Exception("Debe colocar la contraseña del usuario");
        }


    }
}
