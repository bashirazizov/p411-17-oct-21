using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Country
    {
        public string Name { get; set; }
        public string President { get; set; }
        private List<City> Cities { get; set; }

        public int Population { 
            get {
                int result = 0;
                foreach (City item in Cities)
                {
                    result += item.Population;
                }
                return result;
            }
        }

        private static int count;
        public readonly int Id;

        private Country()
        {
            count++;
            Id = count;
            Cities = new List<City>();
        }

        public Country(string name, string president): this()
        {
            Name = name;
            President = president;
        }

        public override string ToString()
        {
            return $"Country: {Id} - Name: {Name} President: {President} Population: {Population} City Count: {Cities.Count}";
        }

        public override bool Equals(object obj)
        {
            return  Name == ((Country)obj).Name;
        }

        public bool AddCity(City city)
        {
            if (Cities.Contains(city))
            {
                return false;
            }

            Cities.Add(city);
            return true;
        }

        public bool RemoveCity(int id)
        {
            int count = Cities.Count;

            for (int i = 0; i < count; i++)
            {
                if (Cities[i].Id == id)
                {
                    Cities.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }


        //public bool RemoveCity(int id)
        //{
        //    City cityToDelete = null;

        //    foreach (City item in Cities)
        //    {
        //        if (item.Id == id)
        //        {
        //            cityToDelete = item;
        //            break;
        //        }
        //    }

        //    if (cityToDelete != null)
        //    {
        //        Cities.Remove(cityToDelete);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public void PrintAllCities()
        {
            foreach (City item in Cities)
            {
                Console.WriteLine($"{Name}-daki {item}");
            }
        }

        public void SearchAndPrintCities(string query)
        {
            bool resultFound = false;
            foreach (City item in Cities)
            {
                if (item.Name.Contains(query)||item.Major.Contains(query))
                {
                    Console.WriteLine($"{item} in {Name}");
                    resultFound = true;
                }
            }

            if (!resultFound)
            {
                Console.WriteLine($"No results found in {Name}.");
            }
        }
    }
}
