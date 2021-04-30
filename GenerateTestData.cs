using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerjeOppgaveAnsatte
{
    class GenerateTestData
    {
        public int MaxPay;

        public Dictionary<string, string[]> DepartmentData = new()
        {
            ["Color"] = new []{"Red","Blue","Orange","Green"},
            ["Body parts"] = new []{"Ear","Leg","Spleen","Hair"},
            ["Data Geeks"] = new []{"Minnegutta","Skjermjentene","Audiofilene"}
        };

        public GenerateTestData(int maxPay)
        {
            MaxPay = maxPay;
        }
        private string Name(Random random)
        {
            var names = new []
            {
                "Boba", "Bab", "Asa", "Bod", "Blal", "Bero", "Ask", "Fmat", "Ost", "Kok", "Schmø", "Kæbe", "Kake",
                "Lolerino", "1234", "4321", "Haha", "Bullegutt", "Navn", "Okei", "Scmokei","Bruri", "Froskegutt","Eirik"
            };
             var name =
                names[random.Next(0, names.Length)] + " " +
                names[random.Next(0, names.Length)] + " " +
                names[random.Next(0, names.Length)];
            return name;
        }

        private int Pay(Random random)
        {
            var pay = random.Next(200000, MaxPay);
            return pay;
        }
        private int CalculateWorkPercentage(double pay)
        {
            var percentage = (pay / MaxPay) * 100;
            return Convert.ToInt32(percentage);
        }

        private int StartYear(Random random)
        {
            var startYear = random.Next(1910,2020);
            return startYear;
        }
        private int QuitYear(Random random, int startYear, bool isEvent)
        {
            var quitYear = isEvent ? random.Next(startYear, 2020) : - 1;
            return quitYear;
        }

        public bool IsEvent(Random random)
        {
            return random.Next(2) == 1;
        }
        private string Department(Random random)
        {
            var index = random.Next(DepartmentData.Count);

            var key = DepartmentData.Keys.ElementAt(index);
            return key;
        }
        private string Team(Random random, string[] teams)
        {
            var teamIndex = random.Next(teams.Length);
            return teams[teamIndex];
        }

        private string NewTeam(Random random, string team, string[] teams)
        {
            string newTeam;
            do
            {
                var teamIndex = random.Next(teams.Length);
                newTeam = teams[teamIndex];
            } while (newTeam.Equals(team));
            return newTeam;
        }

        private string[] GetTeams(string department)
        {
            var teams = DepartmentData.FirstOrDefault(d => d.Key == department).Value;
            return teams;
        }

        private string GenerateOneEmployee()
        {
            var random = new Random();

            var pay = Pay(random);
            var newPay = IsEvent(random) ? Pay(random) : -1;
            var startYear = StartYear(random);
            var quitYear = QuitYear(random, startYear, IsEvent(random));
            var newWorkPercentage = newPay == -1 ? -1 : CalculateWorkPercentage(newPay);

            var department = Department(random);
            var teamsInDepartment = GetTeams(department);
            var team = Team(random, teamsInDepartment);
            var newTeam = IsEvent(random) ? NewTeam(random, team, teamsInDepartment) : "-1";

            return $"{Name(random)}, " +
                   $"{pay}, " +
                   $"{newPay}, " +
                   $"{CalculateWorkPercentage(pay)}%, " +
                   $"{newWorkPercentage}%, " +
                   $"{startYear}, " +
                   $"{quitYear}, " +
                   $"{department}, " +
                   $"{team}, " +
                   $"{newTeam}";
        }

        public string[] GenerateAllEmployees(int count)
        {
            var testDataArray = new string[count];
            for (var i = 0; i < count; i++)
            {
                testDataArray[i] = GenerateOneEmployee();
            }
            return testDataArray;
        }
        public async Task WriteToTextFile(string[] text)
        {
            await File.WriteAllTextAsync("C:\\Users\\Eirik\\source\\repos\\Oppgaver\\TerjeOppgaveAnsatte\\TerjeOppgaveAnsatte\\NewEmployeeData.txt", string.Empty);
            await File.WriteAllLinesAsync("C:\\Users\\Eirik\\source\\repos\\Oppgaver\\TerjeOppgaveAnsatte\\TerjeOppgaveAnsatte\\NewEmployeeData.txt", text);
        }
    }
}
