using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_GarageManger = new Garage();

        public Garage GarageManger
        {
            get
            {
                return m_GarageManger;
            }

            set
            {
                m_GarageManger = value;
            }
        }

        public void Run()
        {
            Console.WriteLine("Welocme to my garge");
            string startMessage = string.Format(
@"
1)Enter new vehicle to the garage.
2)Show the list of vehicle license numbers in the garage.
3)Changing vehicle status.
4)Inflate air in the wheels to MAX.
5)Refuel tha vehicle.
6)Recharge battery vehicle.
7)Show vehicle details

0)Quit ");
            int userActionChoice;
    
            while (true)
            {
                Console.WriteLine(startMessage);
                try
                {
                    userActionChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    wrongInputMessage();
                    continue;
                }

                switch (userActionChoice)
                {
                    case 1:
                        newVehicle();
                        continue;
                    case 2:
                        getVehicleListInGarage();
                        continue;
                    case 3:
                        changeStatus();
                        continue;
                    case 4:
                        tiresInflateToMax();
                        continue;
                    case 5:
                        refuelVehicle();
                        continue;
                    case 6:
                        rechangeVehicle();
                        continue;
                    case 7:
                        vehicleDetails();
                        continue;
                    case 0:
                        break;
                }

                if (userActionChoice == 0)
                {
                    Environment.Exit(0);
                }
            }
        }

        internal static Car.eCountOfDoors GetNumberOfDoors()
        {
            string countOfDoors = string.Format(@"Enter how many doors the car have:
2) 2 Doors
3) 3 Doors
4) 4 Doors
5) 5 Doors ");
            int numberOfDoors;
            while (true)
            {
                try
                {
                    Console.WriteLine(countOfDoors);
                    numberOfDoors = int.Parse(Console.ReadLine());
                    if (numberOfDoors >= 2 && numberOfDoors <= 5)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(2, 5);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }

            return (Car.eCountOfDoors)numberOfDoors;
        }

        internal static Car.eColor GetColor()
        {
            string color = string.Format(@"Enter the car color:
1) Red
2) White
3) Black
4) Grey ");
            int colorNumber;
            while (true)
            {
                try
                {
                    Console.WriteLine(color);
                    colorNumber = int.Parse(Console.ReadLine());
                    if (colorNumber >= 1 && colorNumber <= 4)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 4);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                    continue;
                }
            }

            return (Car.eColor)colorNumber;
        }

        internal static string GetVehicleModel()
        {
            string vehicleModelName;
            while (true)
            {
                Console.WriteLine("Enter Vehicle's Model Name Below :");
                vehicleModelName = Console.ReadLine();
                if (vehicleModelName.Length > 0)
                {
                    break;
                }
            }

            return vehicleModelName;
        }

        internal static string GetLicensePlate()
        {
            string licensePlateNumber;
            while (true)
            {
                Console.WriteLine("Enter Vehicle's License Number Below :");
                licensePlateNumber = Console.ReadLine();
                if (licensePlateNumber.Length > 0)
                {
                    break;
                }
            }

            return licensePlateNumber;
        }

        internal static float GetEnergyPercent()
        {
            bool isParsing;
            float energyPercent;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter vehicle's current energy percent below:");
                    isParsing = float.TryParse(Console.ReadLine(), out energyPercent);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    if (energyPercent < 0 || energyPercent > 100)
                    {
                        throw new ValueOutOfRangeException(0, 100);
                    }

                    break;
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return energyPercent;
        }

        internal static float GetCurrentAirPressure(float i_MaxPressure)
        {
            bool isParsing;
            float curAirPressure;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Current Tire Air Pressure Below, up to '{0}' :", i_MaxPressure);
                    isParsing = float.TryParse(Console.ReadLine(), out curAirPressure);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    if (curAirPressure > i_MaxPressure || curAirPressure < 0)
                    {
                        throw new ValueOutOfRangeException(0, i_MaxPressure);
                    }

                    break;
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return curAirPressure;
        }

        internal static Vehicles.eTypeOfVehicle GetTypeOfVehicle()
        {
            int choise;
            string chooseType = string.Format(@" Choose Type Of Vehicle:
1) Car
2) MotorBike
3) Truck");
            while (true)
            {
                try
                {
                    Console.WriteLine(chooseType);
                    choise = int.Parse(Console.ReadLine());
                    if (choise >= 1 && choise <= 3)
                    {
                        break;
                    }

                    throw new ValueOutOfRangeException(1, 3);
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return (Vehicles.eTypeOfVehicle)choise;
        }

        internal static EnergyType.eTypeOfEnergy GetTypeOfEnergy()
        {
            int choise;
            string chooseType = string.Format(@"Please Choose Type Of Energy:
1) Electric
2) Fuel ");
            while (true)
            {
                try
                {
                    Console.WriteLine(chooseType);
                    choise = int.Parse(Console.ReadLine());
                    if (choise >= 1 && choise <= 2)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 2);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return (EnergyType.eTypeOfEnergy)choise;
        }

        internal static string GetTireManufactor()
        {
            string tireManufactor;
            while (true)
            {
                Console.WriteLine("Enter Tire's ManuFactor Below :");
                tireManufactor = Console.ReadLine();
                if (tireManufactor.Length > 0)
                {
                    break;
                }
            }

            return tireManufactor;
        }

        internal static MotorBike.eTypeOfLicense GetTypeOfMotorBikeLicense()
        {
            int choise;
            string chooseType = string.Format(
@"Choose Type Of Bike License:
1) A
2) A1
3) AA
4) B {0}", Environment.NewLine);
            while (true)
            {
                try
                {
                    Console.Write(chooseType);
                    choise = int.Parse(Console.ReadLine());
                    if (choise >= 1 && choise <= 4)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 4);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                    continue;
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return (MotorBike.eTypeOfLicense)choise;
        }

        internal static int GetMotorBikeEngineSize()
        {
            bool isParsing;
            int engineSize;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter motorbike's Engine size Below :");
                    isParsing = int.TryParse(Console.ReadLine(), out engineSize);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                }
                catch (Exception )
                {
                    wrongInputMessage();
                }
            }

            return engineSize;
        }

        internal static bool GetIsCarryToxics()
        {
            string isToxics = string.Format(
@"The truck's is Carry Toxics?:
1) Yes
2) No{0}",
Environment.NewLine);
            bool isCarryToxics;
            int choice;
            Console.WriteLine(isToxics);
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 2)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 2);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            if (choice == 1)
            {
                isCarryToxics = true;
            }
            else
            {
                isCarryToxics = false;
            }

            return isCarryToxics;
        }

        internal static float GetSizeOfCargo()
        {
            bool isParsing;
            float sizeOfCargo;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the size of cargo truck's:");
                    isParsing = float.TryParse(Console.ReadLine(), out sizeOfCargo);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                    continue;
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return sizeOfCargo;
        }

        private static NewClient.eVehicleStatus GetStatus()
        {
            string status = string.Format(
@"Please Enter Status Of Vehicle :
1) InRepair
2) Fixed
3) Paid {0}",
Environment.NewLine);
            int statusNum;
            while (true)
            {
                try
                {
                    Console.WriteLine(status);
                    statusNum = int.Parse(Console.ReadLine());
                    if (statusNum >= 1 && statusNum <= 3)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 3);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return (NewClient.eVehicleStatus)statusNum;
        }

        private static FueledVehicle.eTypeOfFuel GetFuel()
        {
            string fuel = string.Format(
@"Please Enter Fuel to add :
1) Soler
2) Octan95
3) Octan96
4) Octan98 {0}",
Environment.NewLine);
            int fuelType;
            while (true)
            {
                try
                {
                    Console.WriteLine(fuel);
                    fuelType = int.Parse(Console.ReadLine());
                    if (fuelType >= 1 && fuelType <= 4)
                    {
                        break;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, 4);
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                    continue;
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return (FueledVehicle.eTypeOfFuel)fuelType;
        }

        private static float GetAmountFuel()
        {
            bool isParsing;
            float amount;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the amount fuel's :");
                    isParsing = float.TryParse(Console.ReadLine(), out amount);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                    continue;
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return amount;
        }


        private static float GetMinutesForCharge()
        {
            bool isParsing;
            float minutesToCharge;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter how manny minutes you ant to charge :");
                    isParsing = float.TryParse(Console.ReadLine(), out minutesToCharge);
                    if (!isParsing)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    wrongInputMessage();
                }
                catch (Exception)
                {
                    wrongInputMessage();
                }
            }

            return minutesToCharge;
        }

        private static string GetOwnerName()
        {
            string ownerName;
            while (true)
            {
                Console.WriteLine("Enter owner's name.");
                ownerName = Console.ReadLine();
                if (ownerName.Length > 0)
                {
                    break;
                }
            }

            return ownerName;
        }

        private static string GetOwnerPhoneNumber()
        {
            Console.WriteLine("Enter owner's Phone number below :");
            string ownerPhoneNumber;
            while (true)
            {
                ownerPhoneNumber = Console.ReadLine();
                if (ownerPhoneNumber.Length == 10 || ownerPhoneNumber.Length == 9)
                {
                    try
                    {
                        foreach (char charIsDigit in ownerPhoneNumber)
                        {
                            if (charIsDigit - '0' < 0 || charIsDigit - '0' > 9)
                            {
                                throw new FormatException();
                            }
                        }

                        break;
                    }
                    catch (Exception)
                    {
                        wrongInputMessage();
                    }
                }
                else
                {
                    wrongInputMessage();
                }
            }

            return ownerPhoneNumber;
        }

        private static void wrongInputMessage()
        {
            Console.WriteLine("Entered Wrong Input, Try Again.");
        }

        private void garageEmptyMessage()
        {
            Console.WriteLine("Garage Is Empty");
        }

        private void newVehicle()
        {
            string ownerName = GetOwnerName();
            string ownerPhoneNumber = GetOwnerPhoneNumber();
            string inGarageMessage = GarageManger.IsAlreadyInGarage(ownerName, ownerPhoneNumber, UIFactori.InsertVehicle());
            Console.WriteLine(inGarageMessage);
        }
        
        private void changeStatus()
        {
            if (!GarageManger.IsGarageEmpty())
            {
                try
                {
                    string licenseNumber = GetLicensePlate();
                    NewClient.eVehicleStatus status = GetStatus();
                    GarageManger.ChangeStatus(licenseNumber, status);
                    Console.WriteLine("The status was change insuccessfully");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("License Number Not exist in the garage");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void getVehicleListInGarage()
        {
            List<string> licenseNumberList = new List<string>();
            if (!GarageManger.IsGarageEmpty())
            {
                string chooseHowSortMessage = string.Format(@"Please Choose your preference:
1) All Vehicles In Garage.
2) Sort By Status In Garage. ");
                while (true)
                {
                    try
                    {
                        Console.WriteLine(chooseHowSortMessage);
                        int choise = int.Parse(Console.ReadLine());
                        if (choise == 1 || choise == 2)
                        {
                            switch (choise)
                            {
                                case 1:
                                    {
                                        licenseNumberList = GarageManger.GarageVehiclesList();
                                        break;
                                    }

                                case 2:
                                    {
                                        NewClient.eVehicleStatus statusToSortBy = GetStatus();
                                        licenseNumberList = GarageManger.GarageVehiclesListByStatus(statusToSortBy);
                                        break;
                                    }
                            }

                            printLicenseNumberList(licenseNumberList);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void tiresInflateToMax()
        {
            if (!GarageManger.IsGarageEmpty())
            {
                try
                {
                    string licenseNumber = GetLicensePlate();
                    GarageManger.TiresInflateToMax(licenseNumber);
                    Console.WriteLine("The tire's was inflated to max");
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void refuelVehicle()
        {
            if (!GarageManger.IsGarageEmpty())
            {
                string licenseNumber = GetLicensePlate();
                FueledVehicle.eTypeOfFuel fuel = GetFuel();
                float amount = GetAmountFuel();
                try
                {
                    GarageManger.RefuelVehicle(licenseNumber, fuel, amount);
                    Console.WriteLine("The vehicle was refueled successfully");
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong vehicle");
                }
                catch (Exception)
                {
                    Console.WriteLine("Errror");
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void rechangeVehicle()
        {
            if (!GarageManger.IsGarageEmpty())
            {
                try
                {
                    string licenseNumber = GetLicensePlate();
                    float minutes = GetMinutesForCharge();
                    GarageManger.RechangeVehicle(licenseNumber, minutes);
                    Console.WriteLine("The vehicle's battrery was charged successfully");
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("You cant charge a fuel base vehicle");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void vehicleDetails()
        {
            if (!GarageManger.IsGarageEmpty())
            {
                try
                {
                    string licenseNumber = GetLicensePlate();
                    string vehicleDetails = GarageManger.VehicleDetails(licenseNumber);
                    Console.WriteLine(vehicleDetails);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid Vehicle");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                garageEmptyMessage();
            }
        }

        private void printLicenseNumberList(List<string> i_LicenseNumberList)
        {
            if (i_LicenseNumberList.Count == 0)
            {
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("The List Of Vehicle's License Plate : ");
                foreach (string licenseNumber in i_LicenseNumberList)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }
    }
}
