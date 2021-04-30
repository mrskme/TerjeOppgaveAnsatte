using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Employee
    {
        public string Name { get; }
        public int Pay { get; set; }
        public int WorkPercentage { get; set; }
        public int StartYear { get; }
        public string Team { get; set; }
        public string Department { get; set; }
        public Events Events { get; set; }

        public Employee(
            string name, 
            string pay,
            string newPay, 
            string workPercentage, 
            string newWorkPercentage, 
            string startYear, 
            string quitYear, 
            string department, 
            string team, 
            string newTeam)
        {
            Name = name;
            Pay = Convert.ToInt32(pay);
            WorkPercentage = Convert.ToInt32(workPercentage.Replace("%", ""));
            StartYear = Convert.ToInt32(startYear);
            Department = department;
            Team = team;
            Events = new Events(newPay,newWorkPercentage,quitYear, newTeam);
        }
    }
}
