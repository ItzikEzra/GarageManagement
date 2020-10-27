namespace Ex03.GarageLogic
{
    public class ElectricVehicle : EnergyType
    {
        public ElectricVehicle(float i_MaxEnergy, float i_CurrentEnergy)
        : base(i_MaxEnergy, i_CurrentEnergy)
        {
        }

        internal void RechargeBatteryVehicle(float i_TimeToBattery)
        {
            if (i_TimeToBattery + CurrentEnergy <= MaxEnergy && i_TimeToBattery > 0)
            {
                CurrentEnergy += i_TimeToBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Current amount of battery : {0}
Max amount of battrey : {1}",
            CurrentEnergy, MaxEnergy);
        }
    }
}
