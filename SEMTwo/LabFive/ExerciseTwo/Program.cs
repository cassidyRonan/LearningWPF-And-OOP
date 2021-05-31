using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();

            var query = files
                        .Where(f => f.Length > 10000)
                        .OrderBy(f => f.Length).ThenBy(f => f.Name)
                        .Select(f => new MyFileInfo
                        {
                            Name = f.Name,
                            Length = f.Length,
                            CreationTime = f.CreationTime
                        });

                //var query = from item in files
                //        where item.Length > 10000
                //        orderby item.Length, item.Name
                //        select new MyFileInfo
                //        {
                //            Name = item.Name,
                //            Length = item.Length,
                //            CreationTime = item.CreationTime
                //        };

            Console.WriteLine("Filename\tSize\t\tCreation Date");

            foreach (var item in query)
            {
                Console.WriteLine(
                    "{0} \t{1} bytes,\t{2}",
                    item.Name,item.Length,item.CreationTime);
            }

            Console.ReadKey();
        }

    }

    public class MyFileInfo
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
