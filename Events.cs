using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Events
    {
        public int NewPay { get; }
        public int NewWorkPercentage { get; }
        public int QuitYear { get; }
        public string NewTeam { get; }

        public Events(string newPay, string newWorkPercentage, string quitYear, string newTeam)
        {
            NewPay = newPay == "-1" ? -1 :  Convert.ToInt32(newPay);
            NewWorkPercentage = HandleWorkPercentage(newWorkPercentage);
            QuitYear = quitYear == "-1" ? -1 : Convert.ToInt32(quitYear);
            NewTeam = newTeam;
        }
        public int HandleWorkPercentage(string workPercentageStr)
        {
            var str = workPercentageStr.Replace("%", "");
            return str == "-1" ? -1 : Convert.ToInt32(str);
        }
    }
}
