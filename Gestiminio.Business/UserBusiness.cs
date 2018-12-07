using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class UserBusiness
    {
        UserData data = new UserData();

        public User getlogin(string email, string pwd)
        {
            User user = data.loginUser(email, pwd);
            return user;
        }
        public List<User> getUsersList()
        {
            return data.getUsersList();
        }

        public string addUser(User user)
        {
            string msg = "";
            try
            {
                user.Validar();
                data.addUser(user);
                msg = "Usuario registrado con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar usuario" + ex.Message;
            }
            return msg;
        }

        public string updateUser(User user)
        {
            string msg = "";
            try
            {
                if (user.userId == 0) {
                    msg = "¡Usuario no válido!";
                }
                else
                {
                    var existeUsuario = data.getAllUsersList().Any(x => x.userId == user.userId);
                    if (existeUsuario)
                    {
                        user.Validar();
                        data.updateUser(user);
                        msg = "Usuario actualizado con éxito";
                    }
                    else
                    {
                        msg = "¡Usuario no existe!";
                    }
                }
                
            }
            catch (Exception ex)
            {
                msg = "Error al actualizar usuario" + ex.Message;
            }
            return msg;
        }

        public string deleteUser(int userId)
        {
            string msg = "";
            try
            {
                if (userId == 0)
                {
                    msg = "¡Usuario no válido!";
                }
                else
                {
                    var existeUsuario = data.getUsersList().Any(x => x.userId == userId);
                    if (existeUsuario)
                    {
                        data.deleteUser(userId);
                        msg = "Trabajador eliminado con éxito";
                    }
                    else
                    {
                        msg = "¡Usuario no existe!";
                    }

                }
                
            }
            catch (Exception ex)
            {
                msg = "Error al eliminar usuario" + ex.Message;
            }
            return msg;
        }
    }
}
