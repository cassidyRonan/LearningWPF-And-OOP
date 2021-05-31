using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CA1_Sem4
{
    public enum TaskCategory { Misc, Birthday, School, Work, Personal };
    public enum PriorityLevel {None, Low, Medium, High, Urgent };
    

    public class Task : IComparable
    {
        //Variables
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskCategory Category { get; set; }
        public DateTime DueDate { get; set; }
        public string Date { get; set; }
        public PriorityLevel Priority { get; set; }
        public List<string> Labels { get; set; }
        public string Responsibility { get; set; }
        public string ImagePath { get; set; }
        public string Completed { get; set; } = "Not Completed";

        //Constructor
        public Task(string title,string description,TaskCategory category,DateTime dueDate,PriorityLevel priority,string imagePath, string labels,string responsibility)
        {
            Title = title;
            Description = description;
            Category = category;
            DueDate = dueDate;
            Date = DueDate.ToShortDateString();
            Priority = priority;
            Responsibility = responsibility;
            Labels = new List<string>();
            Labels = (labels.Split(',')).ToList<string>();
            ImagePath = imagePath;

        }
        public Task(string title, string description, TaskCategory category, DateTime dueDate, PriorityLevel priority,string imgPth, string labels, string responsibility,string complete) : this(title, description, category, dueDate, priority,imgPth, labels, responsibility)
        {
            Completed = complete;
        }
        
        [JsonConstructor]
        public Task(string title, string description, TaskCategory category, DateTime dueDate,string date, PriorityLevel priority, List<string> labels, string responsibility, string imgPth, string complete)
        {
            //JSON
            Title = title;
            Description = description;
            Category = category;
            DueDate = dueDate;
            Date = DueDate.ToShortDateString();
            Priority = priority;
            Labels = labels;
            Responsibility = responsibility;
            ImagePath = imgPth;
            Completed = complete;
        }

        public void CompleteTask()
        {
            if(Completed == "Not Completed")
            Completed = "Completed";
            else
            {
                Completed = "Not Completed";
            }
        }

        public int CompareTo(object obj)
        {
            return DueDate.CompareTo(obj);
        }
    }

    
}
