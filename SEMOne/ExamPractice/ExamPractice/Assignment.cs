using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice
{
    public class Assignment
    {
        //Variables
        public string AssignmentName { get; private set; }
        public string SubjectName { get; private set; }
        public DateTime DueDate { get; private set; }
        public int AssignmentMarks { get; private set; }
        public int ReminderTime { get; private set; }
        public string AssignmentDetails { get; private set; }
        public List<string> TagList { get; private set; }

        //Constructor
        public Assignment()
        {
        }
        public Assignment(string name,string subject,DateTime dueDate,int marks,int remind,string details,string tags)
        {
            AssignmentName = name;
            SubjectName = subject;
            DueDate = dueDate;
            AssignmentMarks = marks;
            ReminderTime = remind;
            AssignmentDetails = details;
            
        }
    }
}
