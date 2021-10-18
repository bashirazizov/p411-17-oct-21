using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class City
    {
        public string Name { get; set; }
        public string Major { get; set; }
        public int Population { get; set; }
        
        private static int count;
        public readonly int Id;

        private City()
        {
            count++;
            Id = count;
        }

        public City(string name, string major, int population):this()
        {
            Name = name;
            Major = major;
            Population = population;
        }

        public override string ToString()
        {
            return $"City: {Id} - Name: {Name} MajorName: {Major} Population: {Population} ";
        }

        public override bool Equals(object obj)
        {
            return Name == ((City)obj).Name;
        }

    }
   
}
