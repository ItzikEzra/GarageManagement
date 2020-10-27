namespace Ex03.GarageLogic
{
    public class Car : Vehicles
    {
        public enum eCountOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public enum eColor
        {
            Red = 1,
            White,
            Black,
            Gray
        }

        public const float k_MaxElectricEnergyCar = 2.1f;
        public const float k_MaxFuelEnergyCar = 60f;
        public const float k_MaxAirPressureCar = 32f;
        public const float k_CarTiers = 4f;
        private readonly eColor r_eColor;
        private readonly eCountOfDoors r_eCountOfDoors;
     

        public Car(eCountOfDoors i_CountOfDoors, eColor i_Color, string i_VehicleModelName, string i_VehicleLicenseNum, float i_EnergyPercent, string i_Manufactor, float i_CurrentAirPressure, EnergyType.eTypeOfEnergy i_TypeOfEnergy)
           : base(i_VehicleModelName, i_VehicleLicenseNum, i_EnergyPercent)
        {
            r_eColor = i_Color;
            r_eCountOfDoors = i_CountOfDoors;
            for (int i = 0; i < k_CarTiers ; i++)
            {
                m_Tire.Add(new Tire(i_Manufactor, i_CurrentAirPressure, k_MaxAirPressureCar));
            }

            if (i_TypeOfEnergy == EnergyType.eTypeOfEnergy.Electric)
            {
                base.m_EnergyType = new ElectricVehicle(k_MaxElectricEnergyCar, (float)(i_EnergyPercent * k_MaxElectricEnergyCar / 100));
                base.m_TypeOfEnergy = EnergyType.eTypeOfEnergy.Electric;
            }
            else
            {
                base.m_EnergyType = new FueledVehicle(k_MaxFuelEnergyCar, (float)(i_EnergyPercent * k_MaxFuelEnergyCar / 100), FueledVehicle.eTypeOfFuel.Octan96);
                base.m_TypeOfEnergy = EnergyType.eTypeOfEnergy.Fuel;
            }
        }

        public eColor Color
        {
            get
            {
                return r_eColor;
            }
        }

        public eCountOfDoors CountOfDoors
        {
            get
            {
                return r_eCountOfDoors;
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"The type: Car
{0}
Car's Color: {1}
Car's door quantity: {2}",
           VehicleDetails(), Color.ToString(), CountOfDoors.ToString());
            return str;
        }
    }
}

