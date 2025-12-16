*Transportation Management System*
This project implements a transportation management system that handles drivers and routes for both buses and cars. The system loads data from CSV files, associates each driver with a route based on a shared unit number, and displays available rides along with their corresponding stops.
Class Structure and Inheritance
The program is organized around two main inheritance hierarchies: drivers and routes.

*Driver Hierarchy*
DriverBase
This abstract class defines the shared attributes and behaviors for all drivers. It includes fields such as name, ID number, vehicle capacity, unit route, and password. It also provides methods for password validation, formatting driver information, and retrieving driver details. The property UnitRoute exposes the internal route number.
BusDriver
Inherits from DriverBase. Represents bus drivers and uses all functionality provided by the base class.
CarDriver
Inherits from DriverBase. Represents car drivers and extends the base functionality by adding a ride date, a minimum price, and a method to determine whether the ride is still available based on the current date.

*Route Hierarchy*
RouteBase
This abstract class manages route information. It stores all routes in an internal dictionary where the key is the unit number and the value is a list of stops. It includes methods to load routes from a file, save new routes, update existing routes, and retrieve the stops associated with a specific unit number.
BusRoute
Inherits from RouteBase. Handles bus routes using the file routes.csv. It provides methods to load, save, and update bus routes.
CarRoute
Inherits from RouteBase. Handles car routes using the file car_routes.csv. It provides methods to load and save routes but does not support updating them.

*How the Program Works*
When the program starts, it loads all route data into memory by calling the load methods of BusRoute and CarRoute. It then loads all driver data from the corresponding CSV files. The internal dictionary in RouteBase is populated with the routes, allowing the program to retrieve the stops for any unit number efficiently.
The user interacts with the system through a menu. They can view available bus rides, available car rides, or perform other actions depending on the program’s design. When viewing car rides, the program retrieves all car drivers, filters out those whose ride dates are in the past, and displays the remaining drivers. For each driver, the program retrieves the associated route using the unit number stored in the driver object. The route is then printed as a list of stops.
The program requires that the CSV files follow specific formats. Driver files use commas as separators, while route files use a semicolon to separate the unit number from the list of stops. Prices in the car driver file must use a decimal point, and the program reads them using an invariant culture setting to ensure correct parsing regardless of system locale.
This structure, based on inheritance and clear separation of responsibilities, allows the system to manage drivers and routes consistently. It ensures that data loading, storage, and display are handled in a predictable and maintainable way, suitable for academic and production-level development.
