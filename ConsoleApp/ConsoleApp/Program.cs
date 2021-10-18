using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countryContext = new List<Country>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Menu: Add country - 1 | Add city - 2 | View cities - 3 | Find city - 4 | Delete country - 5 | exit");
                Console.ResetColor();
                
                string userResponse =  Console.ReadLine();

                if (userResponse.ToLower()=="exit")
                {
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection>=1 && selection<=5)
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.AddCountry:
                            
                            Console.Write("Enter county name: ");
                            string ctName = Console.ReadLine();
                            if (string.IsNullOrEmpty(ctName))
                            {
                                Console.WriteLine("County name invalid.");
                                break;
                            }
                           
                            Console.Write("Enter county president name: ");
                            string ctPresident = Console.ReadLine();
                            if (string.IsNullOrEmpty(ctPresident))
                            {
                                Console.WriteLine("President name invalid.");
                                break;
                            }

                            Country newCountry = new Country(ctName,ctPresident);

                            if (countryContext.Contains(newCountry))
                            {
                                Console.WriteLine("Country already exists.");
                                break;
                            }

                            countryContext.Add(newCountry);
                            Console.WriteLine("Country added successfully.");

                            break;
                        case (int)AppMenuSelection.AddCity:
                            if (countryContext.Count<=0)
                            {
                                Console.WriteLine("Add a country first.");
                                break;
                            }

                            Console.Write("Enter city name: ");
                            string cityName = Console.ReadLine();
                            if (string.IsNullOrEmpty(cityName))
                            {
                                Console.WriteLine("City name invalid.");
                                break;
                            }

                            Console.Write("Enter major name: ");
                            string cityMajor = Console.ReadLine();
                            if (string.IsNullOrEmpty(cityMajor))
                            {
                                Console.WriteLine("Major name invalid.");
                                break;
                            }

                            Console.Write("Enter population: ");
                            int cityPopulation;
                            bool cityPopulationIsValid = int.TryParse(Console.ReadLine(), out cityPopulation);
                            if (!cityPopulationIsValid)
                            {
                                Console.WriteLine("Population invalid.");
                                break;
                            }

                            foreach (Country item in countryContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the country that you want to add the city to: ");
                            int cityCountryId;
                            bool cityCountryIdIsValid = int.TryParse(Console.ReadLine(), out cityCountryId);
                            if (!cityCountryIdIsValid)
                            {
                                Console.WriteLine("Country id invalid.");
                                break;
                            }

                            Country countryToAddCityTo = null;

                            foreach (Country item in countryContext)
                            {
                                if (item.Id == cityCountryId)
                                {
                                    countryToAddCityTo = item;
                                }
                            }

                            if (countryToAddCityTo == null)
                            {
                                Console.WriteLine("Country does not exist.");
                                break;
                            }

                            City newCity = new City(cityName,cityMajor,cityPopulation);

                            if (countryToAddCityTo.AddCity(newCity))
                            {
                                Console.WriteLine("City added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("City already exists.");
                            }

                            break;
                        case (int)AppMenuSelection.ViewCities:
                            foreach (Country item in countryContext)
                            {
                                item.PrintAllCities();
                            }
                            break;
                        case (int)AppMenuSelection.FindCities:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Country item in countryContext)
                            {
                                item.SearchAndPrintCities(usersQuery);
                            }

                            break;
                        case (int)AppMenuSelection.DeleteCountry:

                            foreach (Country item in countryContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the country that you want to delete: ");
                            int deleteCountryId;
                            bool deleteCountryIdIsValid = int.TryParse(Console.ReadLine(), out deleteCountryId);
                            if (!deleteCountryIdIsValid)
                            {
                                Console.WriteLine("Country id invalid.");
                                break;
                            }

                            Country countryToDelete = null;

                            foreach (Country item in countryContext)
                            {
                                if (item.Id == deleteCountryId)
                                {
                                    countryToDelete = item;
                                }
                            }

                            if (countryToDelete == null)
                            {
                                Console.WriteLine("Country does not exist.");
                                break;
                            }

                            countryContext.Remove(countryToDelete);

                            Console.WriteLine("Country deleted successfully.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
        }
    }
}
