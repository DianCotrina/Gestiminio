using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class RoleBusiness
    {
        RoleData data = new RoleData();

        public List<Role> getRolesList()
        {
            return data.getRolesList();
        }
    }
}
