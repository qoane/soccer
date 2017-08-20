using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace soccer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //create a teams table
            Dictionary<string,teamInfoHolder> teamTable = getTeamObjectsFromCSV(@"c:\xampp\htdocs\soccer\soccer.csv");
            //create a sorted collection, sort with most points
            var teams = from team in teamTable
             orderby team.Value.points descending
            select team;           
            int i=1;
            foreach (var team in teams)
            {
                //make sure we have a teamInforHolder instance
               teamInfoHolder teamObject = (teamInfoHolder)team.Value;
                Console.WriteLine("Position {0}, Team name {1}, Matches Played {2}, Matches Won {3}, Matches Drawn {4}, Matches Lost {5}, Total Goals {6}, Total Points {7}",i,teamObject.name,teamObject.plays,teamObject.totalWon,teamObject.totaldraws,teamObject.plays-teamObject.totalWon-teamObject.totaldraws,teamObject.totalGoals,teamObject.points);
                Console.WriteLine();
                i++;
            }
            Console.ReadKey();
        }

        static Dictionary<string, teamInfoHolder> getTeamObjectsFromCSV(string fullFilePath)
        {
            //init a colelction for our teams and their stats, we use a dict so we can recall easily with team name as key
            Dictionary<string, teamInfoHolder> legueDictionary = new Dictionary<string, teamInfoHolder>();
            
            using (TextFieldParser parser = new TextFieldParser(fullFilePath))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();

                    //first team won?
                    if (int.Parse(fields[1]) > int.Parse(fields[3]))
                    {
                        //already in our collection?
                        if (legueDictionary.ContainsKey(fields[0]))
                        {
                            //modify first team object
                            teamInfoHolder tempObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[0]];
                            int currentPlays = tempObjectHolderInfo.plays;
                            int currentPoints = tempObjectHolderInfo.points;
                            int currentWins = tempObjectHolderInfo.totalWon;
                            int currentLoses = tempObjectHolderInfo.totalLost;
                            int currentDraws = tempObjectHolderInfo.totaldraws;
                            int currentGoals = tempObjectHolderInfo.totalGoals;
                            legueDictionary[fields[0]] = new teamInfoHolder
                            {
                                name = fields[0],
                                plays = currentPlays += 1,
                                points = currentPoints += 3,
                                totalWon = currentWins += 1,
                                totalLost = currentLoses += 0,
                                totalGoals = currentGoals += int.Parse(fields[1]),
                                totaldraws = currentDraws += 0
                            };
                        }
                        if (legueDictionary.ContainsKey(fields[2]))
                        {
                            //modify second team object
                            teamInfoHolder tempObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[2]];
                            int currentPlays = tempObjectHolderInfo.plays;
                            int currentPoints = tempObjectHolderInfo.points;
                            int currentWins = tempObjectHolderInfo.totalWon;
                            int currentLoses = tempObjectHolderInfo.totalLost;
                            int currentDraws = tempObjectHolderInfo.totaldraws;
                            int currentGoals = tempObjectHolderInfo.totalGoals;
                            legueDictionary[fields[2]] = new teamInfoHolder
                            {
                                name = fields[2],
                                plays = currentPlays += 1,
                                points = currentPoints += 0,
                                totalWon = currentWins += 0,
                                totalLost = currentLoses += 1,
                                totalGoals = currentGoals += int.Parse(fields[3]),
                                totaldraws = currentDraws += 0
                            };
                        }
                        //not in collection?
                        if (!legueDictionary.ContainsKey(fields[0]))
                        {
                           //add first team object
                            teamInfoHolder firstTeamObject = new teamInfoHolder();
                            firstTeamObject.plays = 1;
                            firstTeamObject.name = fields[0];
                            firstTeamObject.points = 3;
                            firstTeamObject.totaldraws = 0;
                            firstTeamObject.totalGoals = int.Parse(fields[1]);
                            firstTeamObject.totalLost = 0;
                            firstTeamObject.totalWon = 1;
                            legueDictionary.Add(fields[0], firstTeamObject);
                        }
                        if (!legueDictionary.ContainsKey(fields[2]))
                        {
                            //add second team object
                                teamInfoHolder secondTeamObject = new teamInfoHolder();
                                secondTeamObject.plays = 1;
                                secondTeamObject.name = fields[2];
                                secondTeamObject.points = 0;
                                secondTeamObject.totaldraws = 0;
                                secondTeamObject.totalGoals = int.Parse(fields[3]);
                                secondTeamObject.totalLost = 1;
                                secondTeamObject.totalWon = 0;                                
                                legueDictionary.Add(fields[2], secondTeamObject);
                        }
                        
                        
                    }

                    //second team won?
                    if (int.Parse(fields[1]) < int.Parse(fields[3]))
                    {
                        //second team already in collection?
                        if (legueDictionary.ContainsKey(fields[2]))
                        {
                            //modify second team object
                            teamInfoHolder tempObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[2]];
                            int currentPlays = tempObjectHolderInfo.plays;
                            int currentPoints = tempObjectHolderInfo.points;
                            int currentWins = tempObjectHolderInfo.totalWon;
                            int currentLoses = tempObjectHolderInfo.totalLost;
                            int currentDraws = tempObjectHolderInfo.totaldraws;
                            int currentGoals = tempObjectHolderInfo.totalGoals;
                            legueDictionary[fields[2]] = new teamInfoHolder
                            {
                                name = fields[2],
                                plays = currentPlays += 1,
                                points = currentPoints += 3,
                                totalWon = currentWins += 1,
                                totalLost = currentLoses += 0,
                                totalGoals = currentGoals += int.Parse(fields[3]),
                                totaldraws = currentDraws += 0
                            };
                        }
                        //first team already in collection?
                        if (legueDictionary.ContainsKey(fields[0]))
                        {
                            //modify first team object
                            teamInfoHolder tempObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[0]];
                            int currentPlays = tempObjectHolderInfo.plays;
                            int currentPoints = tempObjectHolderInfo.points;
                            int currentWins = tempObjectHolderInfo.totalWon;
                            int currentLoses = tempObjectHolderInfo.totalLost;
                            int currentDraws = tempObjectHolderInfo.totaldraws;
                            int currentGoals = tempObjectHolderInfo.totalGoals;
                            legueDictionary[fields[0]] = new teamInfoHolder
                            {
                                name = fields[0],
                                plays = currentPlays += 1,
                                points = currentPoints += 0,
                                totalWon = currentWins += 0,
                                totalLost = currentLoses += 1,
                                totalGoals = currentGoals += int.Parse(fields[1]),
                                totaldraws = currentDraws += 0
                            };
                        }
                        //second team object doest exist in collection?
                        if (!legueDictionary.ContainsKey(fields[2]))
                        {
                            //add second team object
                            teamInfoHolder firstTeamObject = new teamInfoHolder();
                            firstTeamObject.plays = 1;
                            firstTeamObject.name = fields[2];
                            firstTeamObject.points = 3;
                            firstTeamObject.totaldraws = 0;
                            firstTeamObject.totalGoals = int.Parse(fields[3]);
                            firstTeamObject.totalLost = 0;
                            firstTeamObject.totalWon = 1;                            
                            legueDictionary.Add(fields[2], firstTeamObject);
                        }
                        //first team object doest exist in collection?
                        if (!legueDictionary.ContainsKey(fields[0]))
                        {
                            //add first team object
                            teamInfoHolder secondTeamObject = new teamInfoHolder();
                            secondTeamObject.plays = 1;
                            secondTeamObject.name = fields[0];
                            secondTeamObject.points = 0;
                            secondTeamObject.totaldraws = 0;
                            secondTeamObject.totalGoals = int.Parse(fields[1]);
                            secondTeamObject.totalLost = 1;
                            secondTeamObject.totalWon = 0;                            
                            legueDictionary.Add(fields[0], secondTeamObject);

                        }
                        
                    }

                    //is it a draw?
                    if (int.Parse(fields[1]) == int.Parse(fields[3]))
                    {
                        //second team object in collection?
                        if (legueDictionary.ContainsKey(fields[2]))
                        {
                            //modify it
                            teamInfoHolder tempTeamOneObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[2]];
                            int currentTeamOnePlays = tempTeamOneObjectHolderInfo.plays;
                            int currentTeamOnePoints = tempTeamOneObjectHolderInfo.points;
                            int currentTeamOneWins = tempTeamOneObjectHolderInfo.totalWon;
                            int currentTeamOneLoses = tempTeamOneObjectHolderInfo.totalLost;
                            int currentTeamOneDraws = tempTeamOneObjectHolderInfo.totaldraws;
                            int currentTeamOneGoals = tempTeamOneObjectHolderInfo.totalGoals;
                            legueDictionary[fields[2]] = new teamInfoHolder
                            {
                                name = fields[2],
                                plays = currentTeamOnePlays += 1,
                                points = currentTeamOnePoints += 1,
                                totalWon = currentTeamOneWins += 0,
                                totalLost = currentTeamOneLoses += 0,
                                totalGoals = currentTeamOneGoals += int.Parse(fields[3]),
                                totaldraws = currentTeamOneDraws += 1
                            };
                        }

                        //first team object exists in collection?
                        if (legueDictionary.ContainsKey(fields[0]))
                        {
                           //modify it
                            teamInfoHolder tempTeamOneObjectHolderInfo = (teamInfoHolder)legueDictionary[fields[0]];
                            int currentTeamOnePlays = tempTeamOneObjectHolderInfo.plays;
                            int currentTeamOnePoints = tempTeamOneObjectHolderInfo.points;
                            int currentTeamOneWins = tempTeamOneObjectHolderInfo.totalWon;
                            int currentTeamOneLoses = tempTeamOneObjectHolderInfo.totalLost;
                            int currentTeamOneDraws = tempTeamOneObjectHolderInfo.totaldraws;
                            int currentTeamOneGoals = tempTeamOneObjectHolderInfo.totalGoals;
                            legueDictionary[fields[0]] = new teamInfoHolder
                            {
                                name = fields[0],
                                plays = currentTeamOnePlays += 1,
                                points = currentTeamOnePoints += 1,
                                totalWon = currentTeamOneWins += 0,
                                totalLost = currentTeamOneLoses += 0,
                                totalGoals = currentTeamOneGoals += int.Parse(fields[1]),
                                totaldraws = currentTeamOneDraws += 1
                            };
                            
                        }
                        //first team object doest exist?
                        if (!legueDictionary.ContainsKey(fields[0]))
                        {
                            //add it
                            teamInfoHolder firstTeamObject = new teamInfoHolder();
                            firstTeamObject.plays = 1;
                            firstTeamObject.name = fields[0];
                            firstTeamObject.points = 1;
                            firstTeamObject.totaldraws = 1;
                            firstTeamObject.totalGoals = int.Parse(fields[1]);
                            firstTeamObject.totalLost = 0;
                            firstTeamObject.totalWon = 0;                            
                            legueDictionary.Add(fields[0], firstTeamObject);

                            teamInfoHolder secondTeamObject = new teamInfoHolder();
                            secondTeamObject.plays = 1;
                            secondTeamObject.name = fields[2];
                            secondTeamObject.points = 1;
                            secondTeamObject.totaldraws = 1;
                            secondTeamObject.totalGoals = int.Parse(fields[3]);
                            secondTeamObject.totalLost = 0;
                            secondTeamObject.totalWon = 0;
                            
                        }
                        //second team object doesnt exist?
                        if (!legueDictionary.ContainsKey(fields[2]))
                        {
                            //add it
                            teamInfoHolder firstTeamObject = new teamInfoHolder();
                            firstTeamObject.plays = 1;
                            firstTeamObject.name = fields[2];
                            firstTeamObject.points = 1;
                            firstTeamObject.totaldraws = 1;
                            firstTeamObject.totalGoals = int.Parse(fields[3]);
                            firstTeamObject.totalLost = 0;
                            firstTeamObject.totalWon = 0;                           
                            legueDictionary.Add(fields[2], firstTeamObject);
                        }
                        
                    }

                }
                
            }
            return legueDictionary;
        }
            
        
            
        

        struct teamInfoHolder
        {
            public string name;
            public int plays;
            public int totalGoals;
            public int points;
            public int totalWon;
            public int totalLost;
            public int totaldraws;
        }
    }
}
