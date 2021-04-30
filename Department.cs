using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Department
    {
        public string Name { get; set; }
        public Teams Teams { get; set; }

        public Department(string name)
        {
            Name = name;
            Teams = new Teams();
        }
    }
}
