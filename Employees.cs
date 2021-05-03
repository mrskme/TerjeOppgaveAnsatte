using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace TerjeOppgaveAnsatte
{
    class Employees
    {
        public List<Employee> All { get; }
        public List<Employee> SortedEmployees => All.OrderBy(e => e.Name).ToList();

        public Employees()
        {
            All = new List<Employee>();
        }

        public void LinesToEmployees(List<string> lines)
        {
            foreach (var line in lines)
            {
                var splitLine = line.Split(",");
                var name = splitLine[0];
                for (var j = 1; j < splitLine.Length; j++)
                {
                    splitLine[j] = splitLine[j].Trim();
                }
                var pay = splitLine[1];
                var newPay = splitLine[2];
                var workPercentage = splitLine[3];
                var newWorkPercentage = splitLine[4];
                var startYear = splitLine[5];
                var quitYear = splitLine[6];
                var department = splitLine[7];
                var team = splitLine[8];
                var newTeam = splitLine[9];
                All.Add(new Employee(
                    name,
                    pay,
                    newPay,
                    workPercentage,
                    newWorkPercentage,
                    startYear,
                    quitYear,
                    department,
                    team,
                    newTeam));
            }
        }
        public string WriteEmployeesName()
        {
            var text = string.Empty;
            foreach (var employee in SortedEmployees)
            {
                text += $" - {employee.Name}\n";
            }
            return text;
        }
        public string WriteEmployees(params string[] parameter)
        {
            var text = string.Empty;
            var showTeam = parameter.Contains("team");
            var showDepartment = parameter.Contains("department");
            var showPay = parameter.Contains("pay");

            foreach (var employee in SortedEmployees)
            {
                text += $" - {employee.Name}\n";
                text += showTeam ? employee.Team : string.Empty;
                text += showDepartment ? employee.Department : string.Empty;
                text += showPay ? employee.Pay : string.Empty;
            }
            return text;
        }
    }
}
