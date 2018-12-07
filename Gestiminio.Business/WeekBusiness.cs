using Gestiminio.Data;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiminio.Business
{
    public class WeekBusiness
    {
        WeekData data = new WeekData();

        public List<Week> getAllDaysOnWeek()
        {
            return data.getAllDaysOnWeek();
        }
    }
}
