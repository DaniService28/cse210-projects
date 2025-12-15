using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {   
        // Initialize DriversManager and BusRoute, loading existing data
        DriversManager driversManager = new DriversManager();
        driversManager.LoadDrivers();
        BusRoute busRoute = new BusRoute();
        busRoute.LoadRoutes();
        Destinations modifyDestinations = new Destinations();

        // Display Main Menu
        DisplayMenuOptions(1, "Register Bus route");
        DisplayMenuOptions(2, "Find Services");
        DisplayMenuOptions(3, "Register Vehicle");
        DisplayMenuOptions(4, "Exit");
        Console.Write("Please select an option: ");
        int menuOption = int.Parse(Console.ReadLine());

        switch (menuOption)
        {
            case 1:
                DisplayMenuOptions(1, "Start Registration.");
                DisplayMenuOptions(2, "Modify Route.");
                DisplayMenuOptions(3, "Exit.");
                Console.Write("Please select an option: ");

                int subMenuOption = int.Parse(Console.ReadLine());
                switch (subMenuOption)
                {
                    // Registration Process of a Bus Driver
                    case 1:
                        Console.WriteLine("The next information is required to register a new Bus Driver:");
                        Console.Write("Full name: ");
                        string name = Console.ReadLine();
                        Console.Write("ID number: ");
                        string idNumber = Console.ReadLine();
                        Console.Write("Unit number: ");
                        string unitNumber = Console.ReadLine();
                        Console.Write("Vehicle capacity: ");
                        string vehicleCapacity = Console.ReadLine();
                        Console.Write("Password for your user: ");
                        string userPassword = Console.ReadLine();

                        Console.Clear();
                        // Display a list of route stops, and gather route data from user based in indexes from the destinations list
                        Console.WriteLine("Thanks for the information. Now, please provide the route data.");
                        Console.WriteLine("Here is the list of available destinations:");

                        // Display available destinations
                        Destinations destinations = new Destinations();
                        destinations.DisplayAllDestinations();

                        Console.WriteLine();
                        Console.WriteLine("Please enter the indexes of your route stops, separated by commas (e.g., 1,3,5): ");
                        string routeData = Console.ReadLine();

                        // Covert route indexes to actual destination names
                        List<string> routeStops = busRoute.indexesToRoute(routeData);
                        Console.WriteLine("Your route stops are:");

                        // Display the route stops
                        foreach (string stop in routeStops)
                        {
                            Console.WriteLine($"- {stop}");
                        }
                        Console.WriteLine();

                        // Create BusRoute and BusDriver objects
                        BusDriver busDriver = new BusDriver(name, idNumber, vehicleCapacity, int.Parse(unitNumber), userPassword);

                        // Save the BusRoute
                        busRoute.SaveRoutes(int.Parse(unitNumber), routeStops);  

                        // Save the BusDriver using DriversManager
                        driversManager.SaveDriver(unitNumber, busDriver);
                        Console.WriteLine("Your route is the following:");
                        Console.WriteLine("Bus Driver registered successfully!");
                        return;

                    case 2:
                        bool logInAttempt = true;
                        BusDriver attemptingDriver = null;
                        string loginUnitNumber = "";
                        Console.WriteLine("Please log in to modify your route.");

                        while (logInAttempt)
                        {
                            Console.Write("Unit number: ");
                            loginUnitNumber = Console.ReadLine();
                            Console.Write("Password: ");
                            string loginPassword = Console.ReadLine();

                            if(loginUnitNumber.ToUpper() == "EXIT")
                            {
                                Console.WriteLine("Exiting login process.");
                                return;
                            }
    
                            // Get the driver attempting to log in from DriversManager
                            attemptingDriver = driversManager.GetDriver(loginUnitNumber);
                            if (attemptingDriver == null || !attemptingDriver.ValidatePassword(loginPassword))
                            {
                                Console.WriteLine("Invalid unit number or password. Please try again. Or type 'EXIT' to quit.");
                            }
                            else
                            {
                                Console.WriteLine("Login successful. Welcome back!\n");
                                logInAttempt = false; 
                            }
                        }  

                        // Attempt to log in the driver
                        Console.WriteLine(attemptingDriver.GetDriverInfo());
                        Console.WriteLine();

                        // Display available destinations
                        Console.WriteLine("This is your current route stops:");
                        List<string> currentStops = busRoute.GetCurrentRouteStops(int.Parse(loginUnitNumber));
            
                        foreach (string stop in currentStops)
                        {
                            Console.WriteLine($"- {stop}");
                        }
                        Console.WriteLine();
                        EnterToContinue("check the available route stops");

                        // Display available destinations for modification
                        Console.Clear();
                        Console.WriteLine("Here is the list of available destinations:");

                        // Display available destinations
                        modifyDestinations.DisplayAllDestinations();

                        Console.WriteLine();
                        Console.WriteLine("Please enter the indexes of your route stops, separated by commas (e.g., 1,3,5): ");
                        string modifiedRoute = Console.ReadLine();

                        // Covert route indexes to actual destination names
                        List<string> ModifiedStops = busRoute.indexesToRoute(modifiedRoute);
                        Console.WriteLine("Your updated route stops are:");

                        // Display the route stops
                        foreach (string stop in ModifiedStops)
                        {
                            Console.WriteLine($"- {stop}");
                        }
                        Console.WriteLine();

                        // Update the route in BusRoute
                        busRoute.UpdateRoute(int.Parse(loginUnitNumber), ModifiedStops);

                        Console.WriteLine("Your route has been updated successfully!");

                        return;

                    case 3:
                        Console.WriteLine("Exiting...");
                        return;
                }
                break;
            case 2:
                Console.WriteLine("Finding Services...");
                break;
            case 3:
                Console.WriteLine("Registering Vehicle...");
                break;      
            case 4:
                Console.WriteLine("Exiting...");    
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;

        }
    }

    static void DisplayMenuOptions(int number, string title)
    {
        Console.WriteLine($"{number}) {title}");
    }

    static void EnterToContinue(string indication)
    {
        // Utility method to pause until Enter is pressed
        Console.WriteLine("Press Enter to " + indication + "...");
        ConsoleKey pressedKey = ConsoleKey.NoName;

        while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = Console.ReadKey(true).Key;
            }
    }

}
