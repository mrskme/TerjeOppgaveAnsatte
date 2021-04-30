using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Teams
    {
        public List<Team> AllTeamsInDepartment { get; }
        public List<Team> SortedTeam => AllTeamsInDepartment.OrderBy(t => t.Name).ToList();

        public Teams()
        {
            AllTeamsInDepartment = new List<Team>();
        }
        public void MakeTeams(List<Employee> employeesInDepartment, Department department)
        {
            var list = employeesInDepartment.Where(employee =>
                !AllTeamsInDepartment.Exists(t => t.Name == employee.Team) 
                && employee.Department == department.Name);
            foreach (var employee in list)
            {
                var team = new Team(employee.Team);
                AllTeamsInDepartment.Add(team);
                team.AddMembers(employeesInDepartment);
            }
        }

        public string WriteTeams()
        {
            var text = string.Empty;
            foreach (var team in SortedTeam)
            {
                text += team.Name + "\n";
                text += team.Members.WriteEmployees();
            }
            return text;
        }
    }
}
