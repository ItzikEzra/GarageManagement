namespace Ex03.GarageLogic
{
    public class MotorBike : Vehicles
    {
        public enum eTypeOfLicense
        {
            A = 1,
            A1,
            AA,
            B
        }

        private readonly eTypeOfLicense r_eTypeOfLicense;
        private readonly int r_EngineSize;
        public const float k_MaxElectricEnergyMotorBike = 1.2f;
        public const float k_MaxFuelEnergyMotorBike = 7f;
        public const float k_MaxAirPressureMotorBike = 30f;
        public const float k_MotorBikeTiers = 2f;

        public MotorBike(eTypeOfLicense i_TypeOfLicense, int i_EngineSize, string i_VehicleModelName, string i_VehicleLicenseNum, float i_EnergyPercent, string i_Manufactor, float i_CurrentAirPressure, EnergyType.eTypeOfEnergy i_TypeOfEnergy)
        : base(i_VehicleModelName, i_VehicleLicenseNum, i_EnergyPercent)
        {
            r_EngineSize = i_EngineSize;
            r_eTypeOfLicense = i_TypeOfLicense;
            for (int i = 0; i < k_MotorBikeTiers; i++)
            {
                m_Tire.Add(new Tire(i_Manufactor, i_CurrentAirPressure, k_MaxAirPressureMotorBike));
            }

            if (i_TypeOfEnergy == EnergyType.eTypeOfEnergy.Electric)
            {
                base.m_EnergyType = new ElectricVehicle(k_MaxElectricEnergyMotorBike, (float)(i_EnergyPercent * k_MaxElectricEnergyMotorBike / 100));
                base.m_TypeOfEnergy = EnergyType.eTypeOfEnergy.Electric;
            }
            else
            {
               base.m_EnergyType = new FueledVehicle(k_MaxFuelEnergyMotorBike, (float)(i_EnergyPercent * k_MaxFuelEnergyMotorBike / 100), FueledVehicle.eTypeOfFuel.Octan95);
                base.m_TypeOfEnergy = EnergyType.eTypeOfEnergy.Fuel;
            }
        }

        public eTypeOfLicense TypeOfLicense
        {
            get
            {
                return r_eTypeOfLicense;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_EngineSize;
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"The type: Bike
{0}
Type Of License: {1}
Engine Size: {2}", VehicleDetails(), TypeOfLicense.ToString(), EngineSize);
            return str;
        }
    }
}
