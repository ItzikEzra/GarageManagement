namespace Ex03.GarageLogic
{
    public class Truck : Vehicles
    {
        public const float k_MaxFuelEnergyTruck = 120f;
        public const float k_MaxAirPressureTruck = 28f;
        public const float k_TruckTiers = 16f;
        private readonly bool r_IsCarryToxics;
        private readonly float r_CargoSize;

        public Truck(float i_CargoSize, bool i_IsToxic, string i_VehicleModelName, string i_VehicleLicenseNum, float i_EnergyPercent, string i_Manufactor, float i_CurrentAirPressure)
           : base(i_VehicleModelName, i_VehicleLicenseNum, i_EnergyPercent)
        {
            r_CargoSize = i_CargoSize;
            r_IsCarryToxics = i_IsToxic;
            for (int i = 0; i < k_TruckTiers; i++)
            {
                m_Tire.Add(new Tire(i_Manufactor, i_CurrentAirPressure, k_MaxAirPressureTruck));
            }

            base.m_EnergyType = new FueledVehicle(k_MaxFuelEnergyTruck, (float)(i_EnergyPercent * k_MaxFuelEnergyTruck / 100), FueledVehicle.eTypeOfFuel.Soler);
            base.m_TypeOfEnergy = EnergyType.eTypeOfEnergy.Fuel;
        }

        public bool IsCarryToxics
        {
            get
            {
                return r_IsCarryToxics;
            }
        }

        public float SizeOfCargo
        {
            get
            {
                return r_CargoSize;
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"The type: Truck
{0}
Is the truck cargo toxic: {1}
Truck's size of cargo is: {2}",
            VehicleDetails(), IsCarryToxics, SizeOfCargo);
            return str;
        }
    }
}
