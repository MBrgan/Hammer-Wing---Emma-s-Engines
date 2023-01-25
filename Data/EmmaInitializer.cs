using EmmaProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmmaProject.Data
{
    public class EmmaInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            EmmaProjectContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<EmmaProjectContext>();
            try
            {
                context.Database.Migrate();

                //Seeding data for Employees
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            EmpFirst = "Eileen",
                            EmpLast = "Welsh",
                            EmpUserName = "EWelsh",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Gabrielle",
                            EmpLast = "Vallieres",
                            EmpUserName = "GVallieres",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Jasmine",
                            EmpLast = "Ramsay",
                            EmpUserName = "JRamsay",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Vince",
                            EmpLast = "Reid",
                            EmpUserName = "VReid",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Clement",
                            EmpLast = "Carr",
                            EmpUserName = "CCarr",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Carlo",
                            EmpLast = "Brisebois",
                            EmpUserName = "CBrisebois",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Fernand",
                            EmpLast = "McFarlane",
                            EmpUserName = "FMcFarlane",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Julia",
                            EmpLast = "St-Pierre",
                            EmpUserName = "JStPierre",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Judy",
                            EmpLast = "Dumas",
                            EmpUserName = "JDumas",
                            EmpPassword = "Password"
                        },

                        new Employee
                        {
                            EmpFirst = "Chad",
                            EmpLast = "Rodrigue",
                            EmpUserName = "CRodrigue",
                            EmpPassword = "Password"
                        });
                    context.SaveChanges();
                }
                //Seeding data for Customers
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            CustFirst = "Ben",
                            CustLast = "Audet",
                            CustPhone = "2638746671",
                            CustAddress = "3400 Center St",
                            CustCity = "Vulcan",
                            CustProvince = "Alberta",
                            CustPostal = "T0L 2B0"
                        },
                        new Customer
                        {
                            CustFirst = "Jean",
                            CustLast = "Legault",
                            CustPhone = "4034700566",
                            CustAddress = "1217 Islington Ave",
                            CustCity = "Toronto",
                            CustProvince = "Ontario",
                            CustPostal = "M8V 3B6"
                        },
                        new Customer
                        {
                            CustFirst = "Sylvie",
                            CustLast = "Wall",
                            CustPhone = "2043810624",
                            CustAddress = "1752 St Jean Baptiste St",
                            CustCity = "St Prosper De Dorchester",
                            CustProvince = "Quebec",
                            CustPostal = "G0M 1Y0"
                        },
                        new Customer
                        {
                            CustFirst = "Clayton",
                            CustLast = "Langlois",
                            CustPhone = "3436471532",
                            CustAddress = "4474 Toy Avenue",
                            CustCity = "Ajax Pickering",
                            CustProvince = "Ontario",
                            CustPostal = "L1W 3N9"
                        },
                        new Customer
                        {
                            CustFirst = "Leo",
                            CustLast = "Lepine",
                            CustPhone = "5194440181",
                            CustAddress = "794 Jade St",
                            CustCity = "Richmond",
                            CustProvince = "British Columbia",
                            CustPostal = "V7E 2E4"
                        },
                        new Customer
                        {
                            CustFirst = "Dominique",
                            CustLast = "Milne",
                            CustPhone = "2899957489",
                            CustAddress = "3833 White Point Road",
                            CustCity = "Shelburne",
                            CustProvince = "Nova Scotia",
                            CustPostal = "B0T 1W0"
                        },
                        new Customer
                        {
                            CustFirst = "Wanda",
                            CustLast = "Deslauriers",
                            CustPhone = "2893238002",
                            CustAddress = "4146 Bay Street",
                            CustCity = "Toronto",
                            CustProvince = "Ontario",
                            CustPostal = "M5J 2R8"
                        },
                        new Customer
                        {
                            CustFirst = "Sheri",
                            CustLast = "Han",
                            CustPhone = "3438772169",
                            CustAddress = "220 A Avenue",
                            CustCity = "Edmonton",
                            CustProvince = "Alberta",
                            CustPostal = "T5J 0K7"
                        },
                        new Customer
                        {
                            CustFirst = "Alexander",
                            CustLast = "Onge",
                            CustPhone = "2496322220",
                            CustAddress = "3872 Sixth Street",
                            CustCity = "New Westminster",
                            CustProvince = "British Columbia",
                            CustPostal = "V3L 3C1"
                        },
                        new Customer
                        {
                            CustFirst = "Emma",
                            CustLast = "Mohammed",
                            CustPhone = "2364725460",
                            CustAddress = "1136 Granville St",
                            CustCity = "Halifax",
                            CustProvince = "Nova Scotia",
                            CustPostal = "B3K 1N7"
                        });
                    context.SaveChanges();
                }
                //Seeding data for Inventory
                if (!context.Inventories.Any())
                {
                    context.Inventories.AddRange(
                        new Inventory
                        {
                            InvName = "Mower Blade",
                            InvSize = "\t(S) - 8\" Length x 4\" Width",
                            InvAdjustedPrice = 10.99M,
                            InvQuantity = "3-Pack",
                            InvMarkupPrice = 13.99M,
                            InvCurrent = 'Y'

                        },
                        new Inventory
                        {
                            InvName = "Saw Blade",
                            InvSize = "\t(L) - 12\' Length x 5\' Width",
                            InvAdjustedPrice = 13.00M,
                            InvQuantity = "3-Pack",
                            InvMarkupPrice = 15.99M,
                            InvCurrent = 'Y'
                        },
                        new Inventory
                        {
                            InvName = "Atlas Lawnmower Engine Brake Cable",
                            InvSize = "54\" (137 cm) cable",
                            InvAdjustedPrice = 6.99M,
                            InvQuantity = "1",
                            InvMarkupPrice = 8.99M,
                            InvCurrent = 'N'
                        },
                        new Inventory
                        {
                            InvName = "Champion 224cc OHV Horizontal Gas Engine",
                            InvSize = "Shaft dimensions (D x L): 2.4 D x 3/4\" D",
                            InvAdjustedPrice = 97.99M,
                            InvQuantity = "1",
                            InvMarkupPrice = 113.99M,
                            InvCurrent = 'N'
                        },
                        new Inventory
                        {
                            InvName = "MTD Replacement Blade Adapter",
                            InvSize = "Fits 7/8\" crankshaft with 3/16\" key",
                            InvAdjustedPrice = 15.99M,
                            InvQuantity = "1",
                            InvMarkupPrice = 18.99M,
                            InvCurrent = 'Y'                        },
                        new Inventory
                        {
                            InvName = "Mower Sulky Caster Wheels",
                            InvSize = "11\" pneumatic caster wheels",
                            InvAdjustedPrice = 91.99M,
                            InvQuantity = "1",
                            InvMarkupPrice = 122.99M,
                            InvCurrent = 'Y'
                        },
                        new Inventory
                        {
                            InvName = "Starter Rope W/Handle",
                            InvSize = "4.5 mm Rope. 43\" Long (110cm)",
                            InvAdjustedPrice = 5.99M,
                            InvQuantity = "3-Pack",
                            InvMarkupPrice = 6.99M,
                            InvCurrent = 'N'
                        },
                        new Inventory
                        {
                            InvName = "Proslide XT Gas Spring",
                            InvSize = "6mm-15mm",
                            InvAdjustedPrice = 12.99M,
                            InvQuantity = "3-Pack",
                            InvMarkupPrice = 15.99M,
                            InvCurrent = 'N'
                        },
                        new Inventory
                        {
                            InvName = "Walker 6610 Dethatcher Tines For A10",
                            InvSize = "WIDTH: 4\" THICKNESS: 0.1600\" OVERALL LENGTH: 8\"",
                            InvAdjustedPrice = 86.99M,
                            InvQuantity = "20",
                            InvMarkupPrice = 100.99M,
                            InvCurrent = 'Y'
                        },
                        new Inventory
                        {
                            InvName = "Battery Powered Sprayer",
                            InvSize = "4 Gallons",
                            InvAdjustedPrice = 42.99M,
                            InvQuantity = "1",
                            InvMarkupPrice = 49.99M,
                            InvCurrent = 'Y'
                        });
                    context.SaveChanges();
                }
                //Seeding data for Suppliers
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(
                        new Supplier
                        {
                            SupName = "Jason Momoa",
                            SupPhone = "3439787551",
                            SupEmail = "jasonm@domain.ca",
                            SupAddress = "1251 Kinchant St",
                            SupCity = "Quesnel",
                            SupProvince = "British Columbia",
                            SupPostal = "V2J 2R5"
                        },
                        new Supplier
                        {
                            SupName = "Cherry Fox",
                            SupPhone = "5142935101",
                            SupEmail = "cherryfox2023@domain.ca",
                            SupAddress = "2883 Duke Street",
                            SupCity = "Montreal",
                            SupProvince = "Quebec",
                            SupPostal = "H3C 5K4"
                        },
                        new Supplier
                        {
                            SupName = "Janet's Workshop",
                            SupPhone = "2268239976",
                            SupEmail = "janetedmonton@domain.ca",
                            SupAddress = "1329 137th Avenue",
                            SupCity = "Edmonton",
                            SupProvince = "Alberta",
                            SupPostal = "T5J 2Z2"
                        },
                        new Supplier
                        {
                            SupName = "Myrna Milne",
                            SupPhone = "7059770898",
                            SupEmail = "milnem1@domain.ca",
                            SupAddress = "557 rue Saint-Antoine",
                            SupCity = "Granby",
                            SupProvince = "Quebec",
                            SupPostal = "J2H 2H5"
                        },
                        new Supplier
                        {
                            SupName = "Cowboy Motors",
                            SupPhone = "4744058261",
                            SupEmail = "cowboymotor23@domain.ca",
                            SupAddress = "4189 Haaglund Rd",
                            SupCity = "Peachland",
                            SupProvince = "British Columbia",
                            SupPostal = "V0H 1X0"
                        },
                        new Supplier
                        {
                            SupName = "Royal Smashers",
                            SupPhone = "2495679487",
                            SupEmail = "royalsmashers@domain.ca",
                            SupAddress = "894 Poplar Street",
                            SupCity = "Alberton",
                            SupProvince = "Prince Edward Island",
                            SupPostal = "C0B 1B0"
                        },
                        new Supplier
                        {
                            SupName = "Brandon Malik",
                            SupPhone = "4743331639",
                            SupEmail = "bmalik123@domain.ca",
                            SupAddress = "4129 Silver Springs Blvd",
                            SupCity = "Calgary",
                            SupProvince = "Alberta",
                            SupPostal = "T3E 0K6"
                        },
                        new Supplier
                        {
                            SupName = "Cameron Guimond",
                            SupPhone = "2043328769",
                            SupEmail = "camerong11@domain.ca",
                            SupAddress = "3487 Yonge Street",
                            SupCity = "Toronto",
                            SupProvince = "Ontario",
                            SupPostal = "M4W 1J7"
                        },
                        new Supplier
                        {
                            SupName = "Rainbow Ace",
                            SupPhone = "3438554948",
                            SupEmail = "rainbowace@domain.ca",
                            SupAddress = "3791 St Marys Rd",
                            SupCity = "Winnipeg",
                            SupProvince = "Manitoba",
                            SupPostal = "R3C 0C4"
                        },
                        new Supplier
                        {
                            SupName = "Kikkoman",
                            SupPhone = "2898086253",
                            SupEmail = "kikkomanquebec@domain.ca",
                            SupAddress = "251 Saskatchewan Dr",
                            SupCity = "Quebec",
                            SupProvince = "Quebec",
                            SupPostal = "S4P 3Y2"
                        });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
