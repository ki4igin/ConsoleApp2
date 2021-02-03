using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        public enum MyEnum
        {
            Name1 = 1,
            [Description("Here is another")]
            HereIsAnother = 2,
            [Description("Last one")]
            LastOne = 3
        }

        [Description("Счетсик циклов")]
        public int Counter { get; set; }

        static void Main(string[] args)
        {
            Settings settings = new();
            while (true)
            {
                MyConsole.WriteLine("Hello World!");
                Thread.Sleep(1000);
                settings.Read();
                settings.ReadFromFile();
                settings.Display();

                //settings.BoardLocations = "55555";

                //settings.Save();
                ////settings.SaveToFile();

                //settings.Display();


                //Console.ReadLine();
            }


        }
    }

    public class Person : IDescription
    {
        [Description("Name of Person")]
        public string Name { get; set; } = "Tom";
    }
}
