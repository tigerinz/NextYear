using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextYear
{
    class BLL
    {
        public void CreateNewYear(Account source)
        {
            DAL dal = new DAL();
            Account target = source;
            target.Year = dal.GetMaxYear(source)+1;

            dal.RestoreDB(source, target);
            dal.AddMemoColumn(target);
            dal.DeleteMC_(target);
            dal.BatchImportTables(source, target);
            dal.CreateNewCalendar(target);
            dal.ImportHoldAuth(target);
            //have wa sub
            if(source.Subs.IndexOf("WA") >= 0)
            {
                dal.CloseLastYearWA(source);
            }
        }
    }
}
