using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Data;
using Gestiminio.Model;


namespace Gestiminio.Business
{
    public class StatusBusiness
    {
        StatusData data = new StatusData();

        public List<Status> getStatusList() {
            return data.getStatusList();
        }
    }
}
