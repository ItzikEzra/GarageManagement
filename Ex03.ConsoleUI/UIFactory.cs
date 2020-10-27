using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class UIFactori
    {
        internal static Vehicles InsertVehicle()
        {
            Vehicles.eTypeOfVehicle typeOfVehicle = UI.GetTypeOfVehicle();
            string modelName = UI.GetVehicleModel();
            string licenseNum = UI.GetLicensePlate();
            float energyPercent = UI.GetEnergyPercent();
            string tireManufactor = UI.GetTireManufactor();
            Vehicles newVehicle = null;

            try
            {
                switch (typeOfVehicle)
                {
                    case Vehicles.eTypeOfVehicle.Car:
                        newVehicle = createCar(modelName, licenseNum, energyPercent, UI.GetTypeOfEnergy(), tireManufactor, UI.GetCurrentAirPressure(Car.k_MaxAirPressureCar));
                        break;
                    case Vehicles.eTypeOfVehicle.Truck:
                        newVehicle = createTruck(modelName, licenseNum, energyPercent, tireManufactor, UI.GetCurrentAirPressure(Truck.k_MaxAirPressureTruck));
                        break;
                    case Vehicles.eTypeOfVehicle.MotorBike:
                        newVehicle = createMotorBike(modelName, licenseNum, energyPercent, UI.GetTypeOfEnergy(), tireManufactor, UI.GetCurrentAirPressure(MotorBike.k_MaxAirPressureMotorBike));
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            return newVehicle;
        }

        private static Vehicles createCar(string i_ModelName, string i_LicenseNum, float i_EnergyPercent, EnergyType.eTypeOfEnergy i_TypeOfEnergy, string i_TireManufactor, float i_TireCurPressure)
        {
            Car.eCountOfDoors numberDoors = UI.GetNumberOfDoors();
            Car.eColor color = UI.GetColor();
            return Factory.InsertNewCar(numberDoors, color, i_ModelName, i_LicenseNum, i_EnergyPercent, i_TireManufactor, i_TireCurPressure, i_TypeOfEnergy);
        }

        private static Vehicles createMotorBike(string i_ModelName, string i_LicenseNum, float i_EnergyPercent, EnergyType.eTypeOfEnergy i_TypeOfEnergy, string i_TireManufactor, float i_TireCurPressure)
        {
            MotorBike.eTypeOfLicense typeOfLicense = UI.GetTypeOfMotorBikeLicense();
            int motorBikeEngineSize = UI.GetMotorBikeEngineSize();
            return Factory.InsertNewMotorBike(typeOfLicense, motorBikeEngineSize, i_ModelName, i_LicenseNum, i_EnergyPercent, i_TireManufactor, i_TireCurPressure, i_TypeOfEnergy);
        }

        private static Vehicles createTruck(string i_ModelName, string i_LicenseNum, float i_EnergyCurrent, string i_TireManufactor, float i_TireCurPressure)
        {
            bool isCarryToxics = UI.GetIsCarryToxics();
            float volumeOfCargo = UI.GetSizeOfCargo();
            return Factory.InsertNewTruck(volumeOfCargo, isCarryToxics, i_ModelName, i_LicenseNum, i_EnergyCurrent, i_TireManufactor, i_TireCurPressure);
        }

        public static void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
