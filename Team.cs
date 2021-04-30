using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Team
    {
        public string Name { get; }
        public Employees Members { get; }
        public List<Employee> SortedMembers => Members.All.OrderBy(m => m.Name).ToList();
        public Team(string name)
        {
            Name = name;
            Members = new Employees();
        }

        public void AddMembers(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.Team == Name) Members.All.Add(employee);
            }
        }
    }
}
