using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {   
        // Initialize DriversManager and BusRoute, loading existing data
        DriversManager driversManager = new DriversManager();
        driversManager.LoadBusDrivers();
        driversManager.LoadCarDrivers(); 
        
        BusRoute busRoute = new BusRoute();
        CarRoute carRoute = new CarRoute();
        busRoute.LoadRoutes();
        carRoute.LoadRoutes();
        Destinations modifyDestinations = new Destinations();

        // Display Main Menu
        DisplayMenuOptions(1, "Register as Driver");
        DisplayMenuOptions(2, "Find Services");
        DisplayMenuOptions(3, "Exit");
        Console.Write("Please select an option: ");
        int menuOption = int.Parse(Console.ReadLine());

        switch (menuOption)
        {
            case 1:
                DisplayMenuOptions(1, "Register new Driver.");
                DisplayMenuOptions(2, "Modify Bus Route.");
                DisplayMenuOptions(3, "Add Car Route.");
                DisplayMenuOptions(4, "Exit.");
                Console.Write("Please select an option: ");

                int subMenuOption = int.Parse(Console.ReadLine());

                if (subMenuOption == 1)
                {
                    Console.WriteLine("What vehicle will you be driving?");
                    DisplayMenuOptions(1, "Register Bus driver.");
                    DisplayMenuOptions(2, "Register Car driver.");
                    DisplayMenuOptions(3, "Exit.");
                    Console.Write("Please select an option: ");

                    int vehicleOption = int.Parse(Console.ReadLine());
                    switch (vehicleOption)
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
                            List<string> routeStops = modifyDestinations.indexesToRoute(routeData);
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
                            driversManager.SaveDriver(unitNumber, busDriver, "drivers.csv");
                            Console.WriteLine("Your route is the following:");
                            Console.WriteLine("Bus Driver registered successfully!");
                            return;

                            // Register a car driver
                        case 2:
                            Console.WriteLine("The next information is required to register a new Car Driver:");
                            Console.Write("Full name: ");
                            string carName = Console.ReadLine();
                            Console.Write("ID number: ");
                            string carIdNumber = Console.ReadLine();
                            Console.Write("Unit number: ");
                            string carUnitNumber = Console.ReadLine();
                            Console.Write("Vehicle capacity: ");
                            string carVehicleCapacity = Console.ReadLine();
                            Console.Write("Password for your user: ");
                            string carUserPassword = Console.ReadLine();
                            Console.Write("Date of the ride (YYYY-MM-DD): ");
                            DateTime rideDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Minimum price for the ride: ");
                            decimal minimumPrice = decimal.Parse(Console.ReadLine());

                            Console.Clear();
                            // Display a list of route stops, and gather route data from user based on indexes from the destinations list
                            Console.WriteLine("Thanks for the information. Now, please provide the route data.");
                            Console.WriteLine("Here is the list of available destinations:");

                            // Display available destinations
                            modifyDestinations.DisplayAllDestinations();

                            Console.WriteLine();
                            Console.WriteLine("Please enter the indexes of your route stops, separated by commas (e.g., 1,3,5): ");
                            string carRouteData = Console.ReadLine();

                            // Convert route indexes to actual destination names
                            List<string> carRouteStops = modifyDestinations.indexesToRoute(carRouteData);
                            Console.WriteLine("Your route stops are:");

                            // Display the route stops
                            foreach (string stop in carRouteStops)
                            {
                                Console.WriteLine($"- {stop}");
                            }
                            Console.WriteLine();

                            // Create CarDriver object
                            CarDriver carDriver = new CarDriver(
                                carName,
                                carIdNumber,
                                carVehicleCapacity,
                                int.Parse(carUnitNumber),
                                carUserPassword,
                                rideDate,
                                minimumPrice
                                );

                            // Save the CarRoute (no edit, only save)
                            carRoute.SaveRoute(int.Parse(carUnitNumber), carRouteStops);

                            // Save the CarDriver using DriversManager
                            driversManager.SaveDriver(carUnitNumber, carDriver, "car_drivers.csv");
                            Console.WriteLine("Your route is the following:");
                            Console.WriteLine("Car Driver registered successfully!");
                            return;
                            
                        default:
                            Console.WriteLine("Invalid option. Exiting...");
                            return;
                    }
                }
                
                // Modify Bus Route
                else if (subMenuOption == 2)
                {
                    bool logInAttempt = true;

                    // Login process for modifying route crating an instance of DriverBase
                    DriverBase attemptingDriver = null;
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
                    List<string> ModifiedStops = modifyDestinations.indexesToRoute(modifiedRoute);
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
                }

                // Add Car Route
                else if (subMenuOption == 3)
                {
                    bool carLogInAttempt = true;
                    DriverBase attemptingCarDriver = null;
                    string carLoginUnitNumber = "";
                    Console.WriteLine("Please log in to add a new car route.");

                    while (carLogInAttempt)
                    {
                        Console.Write("Unit number: ");
                        carLoginUnitNumber = Console.ReadLine();
                        Console.Write("Password: ");
                        string carLoginPassword = Console.ReadLine();

                        if (carLoginUnitNumber.ToUpper() == "EXIT")
                        {
                            Console.WriteLine("Exiting login process.");
                            return;
                        }

                        // Get the driver attempting to log in from DriversManager
                        attemptingCarDriver = driversManager.GetDriver(carLoginUnitNumber);

                        // Validate that the driver is a CarDriver and the password is correct
                        if (attemptingCarDriver == null ||
                            attemptingCarDriver is not CarDriver ||
                            !attemptingCarDriver.ValidatePassword(carLoginPassword))
                        {
                            Console.WriteLine("Invalid unit number or password. Please try again. Or type 'EXIT' to quit.");
                        }
                        else
                        {
                            Console.WriteLine("Login successful. Welcome back!\n");
                            carLogInAttempt = false;
                        }
                    }

                    // Successful login for Car Driver
                    Console.WriteLine(attemptingCarDriver.GetDriverInfo());
                    Console.WriteLine();

                    // Display available destinations
                    Console.WriteLine("Please provide your new car route stops.");
                    Console.WriteLine("Here is the list of available destinations:");
                    modifyDestinations.DisplayAllDestinations();

                    Console.WriteLine();
                    Console.WriteLine("Please enter the indexes of your NEW route stops, separated by commas (e.g., 1,3,5): ");
                    string newCarRoute = Console.ReadLine();

                    List<string> newCarStops = modifyDestinations.indexesToRoute(newCarRoute);

                    Console.WriteLine("Your new car route stops are:");
                    foreach (string stop in newCarStops)
                    {
                        Console.WriteLine($"- {stop}");
                    }
                    Console.WriteLine();

                    // Guardamos la nueva ruta (no update, solo save)
                    carRoute.SaveRoute(int.Parse(carLoginUnitNumber), newCarStops);

                    Console.WriteLine("Your new car route has been saved successfully!");
                    return;
                }

                else
                {
                    Console.WriteLine("Exiting...");
                    return;
                }
            break;

            case 2:
                DisplayMenuOptions(1, "Find Bus Services");
                DisplayMenuOptions(2, "Available car rides");
                Console.Write("Please select an option: ");

                int serviceOption = int.Parse(Console.ReadLine());

                if (serviceOption == 1)
                {
                    // Find Services
                    Console.WriteLine("Find the fastest bus routes near you.");
                    Console.Write("From: ");
                    string fromLocation = Console.ReadLine();
                    Console.Write("To: ");
                    string toLocation = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(fromLocation) || string.IsNullOrWhiteSpace(toLocation))
                    {
                        Console.WriteLine("Both 'From' and 'To' locations must be provided. Please try again.");
                        Console.Write("From: ");
                        fromLocation = Console.ReadLine();
                        Console.Write("To: ");
                        toLocation = Console.ReadLine();
                    }

                    // Placeholder for route finding logic
                    Console.Clear();
                    Console.WriteLine($"Searching for routes from {fromLocation} to {toLocation}...");

                    UserRoute userRoute = new UserRoute(busRoute.GetAllRoutes());

                    var options = userRoute.FindAllRoutes(fromLocation, toLocation);

                    Console.WriteLine("Available route options:\n");

                    foreach (var option in options)
                    {
                        Console.WriteLine("- " + option);
                    }

                    
                }
                else if (serviceOption == 2)
                {
                   Console.WriteLine("Available Car Rides:");
                    List<CarDriver> carDrivers = driversManager.GetAllCarDrivers();

                    foreach (CarDriver carDriver in carDrivers)
                    {
                        //Verfy if the ride is available
                        if (!carDriver.IsRideAvailable())
                            continue;

                        //Display driver info
                        Console.WriteLine(carDriver.GetDriverInfo());
                        Console.WriteLine();

                        // Display route stops
                        Console.WriteLine("Route Stops:");
                        List<string> currentStops = carRoute.GetCurrentRouteStops(carDriver.UnitRoute);

                        foreach (string stop in currentStops)
                        {
                            Console.WriteLine($"- {stop}");
                        }

                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid option. Exiting...");
                    return;
                }
                break;
                
            case 3:
                Console.WriteLine("Exiting the program. Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid option. Exiting...");
                return;
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
