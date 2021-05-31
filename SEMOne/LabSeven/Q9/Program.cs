using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethod;

namespace Q9
{
    static class Program
    {
        static void Main(string[] args)
        {
            string sentence = "Abstract methods are a very strange thing but with enough research, they can be easy to use. But how to incorporate them into this?";
            string sentenceTwo = "C# is an interesting language as it a strongly typed language.";

            Console.WriteLine(sentence);
            int counter = sentence.SentenceCount();
            Console.WriteLine($"Sentence One Word Count: {counter}");

            Console.WriteLine(sentenceTwo);
            counter = sentenceTwo.SentenceCount();
            Console.WriteLine($"Sentence Two Word Count: {counter}");

            Console.ReadKey();
        }

        
    }

    
}

namespace ExtensionMethod
{
    public static class Extension
    {
        public static int SentenceCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
