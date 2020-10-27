namespace Ex03.GarageLogic
{
    public static class Factory
    {
        public static Vehicles InsertNewCar(Car.eCountOfDoors i_NumOfDoors, Car.eColor i_Color, string i_ModelName, string i_LicenseNum, float i_EnergyCurrent, string i_TireManufactor, float i_TireCurPressure, EnergyType.eTypeOfEnergy i_TypeOfEnergy)
        {
            Vehicles newCar = new Car(i_NumOfDoors, i_Color, i_ModelName, i_LicenseNum, i_EnergyCurrent, i_TireManufactor, i_TireCurPressure, i_TypeOfEnergy);

            return newCar;
        }

        public static Vehicles InsertNewTruck(float i_SizeOfCargo, bool i_IsToxic, string i_ModelName, string i_LicenseNum, float i_EnergyCurrent, string i_TireManufactor, float i_TireCurPressure)
        {
            Vehicles newTruck = new Truck(i_SizeOfCargo, i_IsToxic, i_ModelName, i_LicenseNum, i_EnergyCurrent, i_TireManufactor, i_TireCurPressure);
            return newTruck;
        }

        public static Vehicles InsertNewMotorBike(MotorBike.eTypeOfLicense i_TypeOfLicense, int i_EngineSize, string i_ModelName, string i_LicenseNum, float i_EnergyCurrent, string i_TireManufactor, float i_TireCurPressure, EnergyType.eTypeOfEnergy i_TypeOfEnergy)
        {
            Vehicles newMotorBike = new MotorBike(i_TypeOfLicense, i_EngineSize, i_ModelName, i_LicenseNum, i_EnergyCurrent, i_TireManufactor, i_TireCurPressure, i_TypeOfEnergy);
            return newMotorBike;
        }
    }
}
