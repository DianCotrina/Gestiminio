using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Model
{
    public class User
    {
        public int userId { get; set; }
        public int userTypeId { get; set; }
        public string userTypeDescription { get; set; }
        public string userIdDescription { get; set; }
        public string userPassword { get; set; }
        public string userDni { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string userPhoneNumber { get; set; }
        public string userEmail { get; set; }
        public DateTime userStartDate { get; set; }
        public int userStatusId { get; set; }
        public string userStatusDescription { get; set; }
        public int ApartmentId { get; set; }
        public string AparmentNumber { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(userId.ToString()))
                throw new Exception("Debe colocar el dni del trabajador");
            if (userDni.Length != 8)
                throw new Exception("El dni del usuario debe tener 8 caracteres");
            if (string.IsNullOrEmpty(userIdDescription))
                throw new Exception("Debe colocar el usuario del propietario o administrador");
            if (string.IsNullOrEmpty(userPassword))
                throw new Exception("Debe colocar la contraseña del usuario");
            if (userPassword.Length != 8)
                throw new Exception("La contraseña del usuario debe tener 8 caracteres");
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Debe colocar el nombre del usuario");
            if (string.IsNullOrEmpty(userLastName))
                throw new Exception("Debe colocar el apellido del usuario");
            if (string.IsNullOrEmpty(userPhoneNumber))
                throw new Exception("Debe colocar el numero del usuario");
            if (userPhoneNumber.Length != 9)
                throw new Exception("El número del usuario debe tener 9 caracteres");
            if (string.IsNullOrEmpty(userEmail))
                throw new Exception("Debe colocar el correo electronico del usuario");
            if (string.IsNullOrEmpty(Convert.ToDateTime(userStartDate).ToString()))
                throw new Exception("Debe seleccionar la fecha de ingreso del trabajador");
            if (string.IsNullOrEmpty(userStatusId.ToString()))
                throw new Exception("Debe seleccionar un estado del trabajador");
        }
    }
}
