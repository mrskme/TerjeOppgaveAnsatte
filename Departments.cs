using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Departments
    {
        public List<Department> All { get; set; }
        public List<Department> SortedDepartment => All.OrderBy(d => d.Name).ToList();

        public Departments()
        {
            All = new List<Department>();
        }

        public void MakeDepartments(Employees employees)
        {
            foreach (var employee in employees.All.Where(employee => !All.Exists(d => employee.Department.Equals(d.Name))))
            {
                var department = new Department(employee.Department);
                var allEmployeesInDepartment = employees.All.Where(e => e.Department == employee.Department);
                department.Teams.MakeTeams(allEmployeesInDepartment.ToList(), department);
                All.Add(department);
            }
        }

        public string WriteDepartmentsWithTeamsWithEmployees()
        {
            var text = string.Empty;
            foreach (var department in SortedDepartment)
            {
                text += $"Avdeling: {department.Name}\n";
                text += department.Teams.WriteTeams();
            }
            return text;
        }
    }
}
