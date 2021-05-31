using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFive
{
    class Team : IComparable
    {
        //Variables
        private readonly string teamName;
        private readonly string managerName;
        public string TeamName { get { return teamName; } }
        public string ManagerName { get { return managerName; } }
        public int Wins { get; private set; } = 0;
        public int Draw { get; private set; } = 0;
        public int Losses { get; private set; } = 0;
        public int Games { get; private set; } = 0;
        public int Points { get; private set; } = 0;

        public enum Result { Win, Draw, Lose };

        //Constructor
        public Team() : this("ATeam")
        {
        }

        public Team(string NameOfTeam) : this(NameOfTeam, "AnOther")
        {
            teamName = NameOfTeam;
        }

        public Team(string NameOfTeam, string NameOfManager)
        {
            teamName = NameOfTeam;
            managerName = NameOfManager;  
        }

        //Methods
        public void AddResult(Result result)
        {
            switch (result)
            {
                case Result.Win:
                    Wins++;
                    Points += 3;
                    Games++;
                    break;

                case Result.Draw:
                    Draw++;
                    Points += 1;
                    Games++;
                    break;

                case Result.Lose:
                    Losses++;
                    Games++;
                    break;

                default:
                    break;
            }

            
        }

        public int CompareTo(object obj)
        {
            Team That = (Team)obj;
            return this.Points.CompareTo(That.Points);
        }

        public override string ToString()
        {
            return string.Format("{0,-20}{1,-20}{2,-7}{3,-7}{4,-7}{5,-7}{6,-7}",teamName,managerName,Points,Wins,Draw,Losses,Games);
        }
    }
}
