using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances

/*
 * Project Name : Assignment 1 - Classes and Inheritance
 * Contributers : Sanghyeon Lee, Aaron Manocha, Rudra Verma
 * Completed Date: June 10 2023
 * 
 */
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Sang Lee </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");

            long itemNum;

            string temp = Console.ReadLine();

            itemNum = long.Parse(temp);

            Appliance? foundAppliance = null;

            foreach (var appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNum)
                {
                    foundAppliance = appliance;
                    break;
                }
            }
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }

        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string findBrand = Console.ReadLine();
            List<Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance.Brand == findBrand)
                {
                    found.Add(appliance);
                }
            }
            DisplayAppliancesFromList(found, 0);

        }

                /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Enter number of doors: 0 - Any, 2 - Double doors, 3 - Three doors, 4 - Four doors");
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"


            int numOfDoors;

            numOfDoors = Convert.ToInt32(Console.ReadLine());

            List<Appliance> found = new List<Appliance>();
            foreach(var appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if (numOfDoors == 0)
                    {
                        found.Add(refrigerator);

                    }
                    else if (refrigerator.Doors == numOfDoors)
                    {
                        found.Add(refrigerator);
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);

        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:\n" +
                "0 - Any\n" +
                "1 - Residential\n" +
                "2 - Commercial\n" +
                "Enter grade:");

            string grade = Console.ReadLine();
            switch (grade)
            {
                case "0":
                    grade = "Any";
                    break;
                case "1":
                    grade = "Residential";
                    break;
                case "2":
                    grade = "Commercial";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            Console.WriteLine("Possible options:\n" +
                "0 - Any\n" +
                "1 - 18 Volt\n" +
                "2 - 24 Volt\n" +
                "Enter voltage:");
            string ?voltage = Console.ReadLine();
            switch (voltage)
            {
                case "0":
                    voltage = "Any";
                    break;
                case "1":
                    voltage = "18";
                    break;
                case "2":
                    voltage = "24";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            
            List<Appliance> found = new List<Appliance>();
            
            foreach (var appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    if ((grade == "Any" || grade == vacuum.Grade) &&
                        (voltage == "Any" || vacuum.BatteryVoltage == Convert.ToInt16(voltage)))
                    {
                        found.Add(vacuum);
                    }
                }
            }
            foreach (var appliance in Appliances)
            {
               if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Vacuum)
               {
                   Vacuum vacuum = (Vacuum)appliance;
                   if (grade == "Any")
                   {
                       if (voltage == "Any")
                       {
                           found.Add(vacuum);
                       }
                       else if (vacuum.BatteryVoltage == Convert.ToInt16(voltage))
                       {
                          found.Add(vacuum);
                       }
                   }
                   else if (grade == "Residential")
                   {
                       if (voltage == "Any")
                       {
                            found.Add(vacuum);
                       }
                       else if (vacuum.BatteryVoltage == Convert.ToInt16(voltage)) { found.Add(vacuum); }
                   }
                   else 
                   {
                       if (voltage == "Any")
                       {
                            found.Add(vacuum);
                       }
                       else if (vacuum.BatteryVoltage == Convert.ToInt16(voltage)) { found.Add(vacuum); }
                   }

               }
            }
            DisplayAppliancesFromList(found, 0);
            Console.WriteLine(found.Count());

           

        }


  
        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            char roomType;
            bool flag = true;
            do 
            {
                Console.WriteLine("Possible options:\n" +
                "0 - Any\n" +
                "1 - Kitchen\n" +
                "2 - Work site\n" +
                "Enter room type:");
                roomType = Convert.ToChar(Console.ReadLine());
                if (roomType - '0' >= 0 && roomType - '0' <= 2) { flag = false; } else { Console.WriteLine("Invalid input! Enter Again"); }
                // if (Convert.ToInt32(new string(roomType, 1)) >= 0 && Convert.ToInt32(new string(roomType, 1)) <= 2) { flag = false; } else { Console.WriteLine("Invalid input! Enter Again"); }
            } while (flag);


            
           
            switch (roomType)
            {
                case '0':
                    roomType = 'A';
                    break;
                case '1':
                    roomType = 'K';
                    break;
                case '2':
                    roomType = 'W';
                    break;
            }
            
            List<Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        found.Add(microwave);
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);
            

        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            
            string soundRating;
           
            bool flag = true;
            do {
                Console.WriteLine("Possible options:\n" +
                "0 - Any\n" +
                "1 - Quietest\n" +
                "2 - Quieter\n" +
                "3 - Quiet\n" +
                "4 - Moderate\n" +
                "Enter sound rating:");
                soundRating = Console.ReadLine();
                Dictionary<string, string> sounRatingDictionary = new Dictionary<string, string>
                {
                    {"0", "Any"},
                    {"1", "Qt"},
                    {"2", "Qr"},
                    {"3", "Qu"},
                    {"4", "M"}
                };
                if (sounRatingDictionary.ContainsKey(soundRating))
                {
                    soundRating = sounRatingDictionary[soundRating];
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Invalid value! Enter again");
                }
            } while (flag);
            
          
            
            
            List <Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances) 
            {
                if(Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if(soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        found.Add(appliance);
                    }    
                }
            }
            DisplayAppliancesFromList(found, 0);
           
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            Console.WriteLine("Appliance Types\n" +
                "0 - Any\n" +
                "1 – Refrigerator\n" +
                "2 – Vacuums\n" +
                "3 – Microwaves\n" +
                "4 – Dishwashers\n" +
                "Enter type of appliance:");
           
            string applianceType = Console.ReadLine();
            Console.WriteLine("Enter number of appliances: ");
            int numOfAppliances = Convert.ToInt32(Console.ReadLine());

            List<Appliance> found = new List<Appliance>();
            foreach(Appliance appliance in Appliances)
            {
                switch (applianceType)
                {
                    case "0":
                        found.Add(appliance);
                        break;
                    case "1":
                        if(Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Refrigerator) { found.Add(appliance); }
                        break;
                    case "2":
                        if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Vacuum) { found.Add(appliance); }
                        break;
                    case "3":
                        if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Microwave) { found.Add(appliance); }
                        break;
                    case "4":
                        if (Appliance.DetermineApplianceTypeFromItemNumber(appliance.ItemNumber) == Appliance.ApplianceTypes.Dishwasher) { found.Add(appliance); }
                        break;
                    default:
                        Console.WriteLine("Invalid Value!");
                        break;
                }
            }
            found.Sort(new RandomComparer());
            DisplayAppliancesFromList(found, numOfAppliances);
            

        }
    }
}
