using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Team")
                {
                    try
                    {
                        string teamName = commandArgs[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (commandArgs[0] == "Add")
                {
                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];
                    double endurance = double.Parse(commandArgs[3]);
                    double sprint = double.Parse(commandArgs[4]);
                    double dribble = double.Parse(commandArgs[5]);
                    double passing = double.Parse(commandArgs[6]);
                    double shooting = double.Parse(commandArgs[7]);

                    if (teams.Any(t => t.Name == teamName))
                    {
                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble,
                                passing, shooting);
                            teams.FirstOrDefault(t => t.Name == teamName).AddPlayer(player);
                        }
                        catch (ArgumentException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];                                       

                    if (teams.Any(t => t.Name == teamName))
                    {
                        try
                        {
                            teams.FirstOrDefault(t => t.Name == teamName).RemovePlayer(playerName);
                        }
                        catch (ArgumentException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else
                {
                    string teamName = commandArgs[1];

                    if (teams.Any(t => t.Name == teamName))
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
            }
        }
    }
}
