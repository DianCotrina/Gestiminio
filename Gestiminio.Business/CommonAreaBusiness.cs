using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class CommonAreaBusiness
    {
        CommonAreaData data = new CommonAreaData();

        public List<CommonArea> getCommonAreaList()
        {
            return data.getCommonAreaList();
        }

        public string addCommonArea(CommonArea area)
        {
            string msg = "";
            try
            {
                area.Validar();
                data.addCommonArea(area);
                msg = "Trabajador registrado con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar trabajador" + ex.Message;
            }
            return msg;
        }

        public string updateCommonArea(CommonArea area)
        {
            string msg = "";
            try
            {
                if (area.commonAreaId.Equals(""))
                {
                    msg = "¡Usuario no válido!";
                }
                else
                {
                    var existeArea = data.getCommonAreaList().Any(x => x.commonAreaId == area.commonAreaId);
                    if (existeArea)
                    {
                        area.Validar();
                        data.updateCommonArea(area);
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
                msg = "Error al actualizar trabajador" + ex.Message;
            }
            return msg;
        }

        public List<CommonArea> getCommonAreasByPreference(string param)
        {
            return data.getCommonAreasByPreference(param);
        }

        public string deleteCommonArea(string commonAreaId)
        {
            string msg = "";
            try
            {
                if (commonAreaId.Equals(""))
                {
                    msg = "¡Usuario no válido!";
                }
                else
                {
                    var existeArea = data.getCommonAreaList().Any(x => x.commonAreaId == commonAreaId);
                    if (existeArea)
                    {
                        data.deleteCommonArea(commonAreaId);
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
                msg = "Error al eliminar trabajador" + ex.Message;
            }
            return msg;
        }
    }
}
