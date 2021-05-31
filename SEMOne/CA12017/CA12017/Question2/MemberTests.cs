using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class MemberTests
    {
        static void Main(string[] args)
        {
            //Variables
            Member mem = new Member("Ronan", "Cassidy", 19,"S00177754");
            Member[] members = new Member[5];

            members[0] = new Member("Jacob", "Mikado", 18, "S02137754");
            members[1] = new Member("Jim", "Jangle", 20, "S00188993");
            members[2] = new Member("Carl", "Markle", 17, "S00187752");
            members[3] = new Member("Richard", "O'Brien", 22, "S00144751");
            members[4] = new Member("Benji", "Achoo", 16, "S00137750");

            //Output Data
                //mem.ToString();
                //Console.WriteLine("==== Club Membership Details ====");
                //Console.WriteLine("=== Member Details ===");
            TitleColor("==== Club Membership Details ====");
            TitleColor("=== Member Details ===");
            OutputData(members);

            //Change Status
                //Console.WriteLine("\n=== Member Details With Status Changed on 1 & 3 ===");
            TitleColor("\n=== Member Details With Status Changed on 1 & 3 ===");
            members[0].Changestatus();
            members[2].Changestatus();
            OutputData(members);

            //Output Total Amount
                //Console.WriteLine($"\n=== Number Of Club Members: {Member.AmountOfMembers} ===");
            TitleColor($"\n=== Number Of Club Members: {Member.AmountOfMembers} ===");

            //Output Sort Reverse
                //Console.WriteLine("\n=== Member Details After Sorting By Surname ===");
            TitleColor("\n=== Member Details After Sorting By Surname ===");
            members = members.OrderByDescending(c => c).ToArray();
            OutputData(members);

            TitleColor("\nPress Any Key To Continue . . .");
            Console.ReadKey();
        }

        static void OutputData(Member[] members)
        {
            foreach (var member in members)
            {
                Console.WriteLine(member.ToString()); 
            }
        }


        //Extra Features
        static void TitleColor(string TitleMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(TitleMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void TitleColor(string TitleMessage, ConsoleColor TitleColor)
        {
            Console.ForegroundColor = TitleColor;
            Console.WriteLine(TitleMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void TitleColor(string TitleMessage, ConsoleColor TitleColor, ConsoleColor TextColor)
        {
            Console.ForegroundColor = TitleColor;
            Console.WriteLine(TitleMessage);
            Console.ForegroundColor = TextColor;
        }
    }
}
