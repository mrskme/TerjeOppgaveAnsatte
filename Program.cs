using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateTestData().Wait();

            var fileLocation = @"C:\Users\Eirik\source\repos\Oppgaver\TerjeOppgaveAnsatte\TerjeOppgaveAnsatte\NewEmployeeData.txt";
            var fileHandler = new FileHandler();
            var employees = new Employees();
            var departments = new Departments();

            var lines = fileHandler.TextToListOfLines(fileLocation);

            employees.LinesToEmployees(lines);
            departments.MakeDepartments(employees);

            //Console.WriteLine(departments.WriteDepartmentsWithTeamsWithEmployees());
            List<string> userInput = new List<string>();
            var input = string.Empty;
            do
            {
                input = Console.ReadLine();
                userInput.Add(input);
            }
            while (input != "ferdig");


            Console.WriteLine(employees.WriteEmployees(userInput.ToArray()));
            //var text = MakeTextFromData(departments, employees);
            //Console.WriteLine(text);
            Console.ReadLine();
        }

        private static async Task GenerateTestData()
        {
            //gjøre async
            var testDataCreator = new GenerateTestData(maxPay:1000001);
            var randomlyGeneratedEmployees = testDataCreator.GenerateAllEmployees(50);
            await testDataCreator.WriteToTextFile(randomlyGeneratedEmployees);
        }

        public static string MakeTextFromData(Departments departments, Employees employees)
        {
            var text = string.Empty;
            text += $"Ansatte totalt: {employees.All.Count} \n";
            text += $"Avdelinger totalt: {departments.All.Count} \n";

            foreach (var department in departments.SortedDepartment)
            {
                text += $"\nAvdeling: {department.Name} \nTotalt teams på adveling: {department.Teams.SortedTeam.Count}\n\n";
                foreach (var team in department.Teams.SortedTeam)
                {
                    text += $"Team: {team.Name}\n";
                    text += $"Totalt annsatte på team: {team.SortedMembers.Count}\n";
                    foreach (var employee in team.SortedMembers)
                    {
                        text += $" - {employee.Name}\n";
                        text += $"Pay: {employee.Pay}\n";
                        if (employee.Name.Contains("Schmø Kæbe Bruri")) Console.WriteLine(EldenRingLogoASCII());
                    }
                }
            }

            return text;
        }
        public static string EldenRingLogoASCII()
        {
            var logo = 
                "\n⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣼⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⣤⣄⣠⣤⣤⣿⣤⣤⣄⣄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠙⣿⡟⠈⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣻⠇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣻⡆⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠄⢠⡶⠞⠿⣿⠿⠿⢶⣄⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⣌⢉⣤⡄⠄⣿⡖⢠⣄⠉⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⡀⣹⡾⣿⢶⠶⣿⣷⠶⠾⠷⣶⣄⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⢰⠟⣿⠇⠄⠄⠄⣿⠉⣧⡄⠄⡽⡟⢷⣄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⢰⡷⠄⣿⣣⣀⡀⠄⣿⠄⢀⣠⡼⢽⠷⠃⢏⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠹⣇⠄⠚⢧⡈⠛⠓⣻⠓⣛⡟⣥⡟⠁⢠⣿⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⢸⣦⠄⠈⠉⢱⡦⣭⠄⣾⠏⠉⠄⢀⣾⠋⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠉⠿⢷⣶⣴⠟⣽⠿⠴⢤⣤⠾⢿⠄⠄⠄⠄⠄⠄⠄⠔\n" +
                "⠂⠤⡀⠄⠄⠄⠄⠄⠄⠉⠄⠄⢈⠄⠄⠑⢤⡔⠋⠄⠄⠄⢀⣤⠄⠄⠄\n" +
                "⠄⠄⠈⠐⠶⣤⠄⠄⠄⠄⡄⠄⢸⡀⢠⡀⠄⠁⠄⣀⡴⠚⠋⠁⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠉⠛⠻⠷⠶⢿⢷⠶⠞⠁⠛⠋⠄⠄⠄⠄⠄⠄⠄⠄\n" +
                "⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠰⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\n\n";

            return logo;
        }
    }
}
