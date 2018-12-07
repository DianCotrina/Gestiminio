using Gestiminio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestiminio.Model;

namespace Gestiminio.Business
{
    public class ReportBusiness
    {
        ReportData data = new ReportData();

        public List<Worker> getWorkersReport(DateTime startDate, DateTime finishDate)
        {
            return data.getWorkersReport(startDate, finishDate);
        }

        public List<Visitor> getVisitorsReport(DateTime startDate, DateTime finishDate)
        {
            return data.getVisitorsReport(startDate, finishDate);
        }
    }
}
