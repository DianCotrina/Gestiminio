using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;
using Gestiminio.Data;

namespace Gestiminio.Business
{
    public class VisitorBusiness
    {
        VisitorData data = new VisitorData();
        public string addNewVisitor(Visitor visitor)
        {
            string msg = "";
            try
            {
                //validar visitante
                data.addNewVisitor(visitor);
                msg = "Visita registrada con éxito";
            }
            catch (Exception ex)
            {
                msg = "Error al registrar visita" + ex.Message;
            }
            return msg;
        }

        public List<Visitor> getVisitorsByOwner(string param)
        {
            return data.getVisitorsByOwner(param);
        }
    }
}
