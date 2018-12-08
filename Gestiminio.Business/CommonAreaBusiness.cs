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
                msg = "Area comun registrada con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar area comun" + ex.Message;
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
                    msg = "Id de area comun no valido";
                }
                else
                {
                    var existeArea = data.getCommonAreaList().Any(x => x.commonAreaId == area.commonAreaId);
                    if (existeArea)
                    {
                        area.Validar();
                        data.updateCommonArea(area);
                        msg = "Area comun actualizada con éxito";
                    }
                    else
                    {
                        msg = "¡Area comun no existe!";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Error al actualizar area comun" + ex.Message;
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
                    msg = "Id de area comun no valido";
                }
                else
                {
                    var existeArea = data.getCommonAreaList().Any(x => x.commonAreaId == commonAreaId);
                    if (existeArea)
                    {
                        data.deleteCommonArea(commonAreaId);
                        msg = "Area comun actualizada con éxito";
                    }
                    else
                    {
                        msg = "¡Area comun no existe!";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Error al eliminar area comun" + ex.Message;
            }
            return msg;
        }
    }
}
