using System;

namespace Ex03.GarageLogic
{
    public class FueledVehicle : EnergyType
    {
        public enum eTypeOfFuel
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eTypeOfFuel r_eTypeOfFuel;

        public FueledVehicle(float i_MaxEnergy, float i_CurrentEnergy, eTypeOfFuel i_TypeOfFuel)
            : base(i_MaxEnergy, i_CurrentEnergy)
        {
            r_eTypeOfFuel = i_TypeOfFuel;
        }

        public eTypeOfFuel TypeOfFuel
        {
            get
            {
                return r_eTypeOfFuel;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Current amount of fuel : {0}
Max amount of fuel : {1}
Fuel Type: {2}",
            CurrentEnergy, MaxEnergy, TypeOfFuel);
        }

        internal void RefuelVehicle(float i_FuelToAdd, eTypeOfFuel i_TypeOfFuel)
        {
            if (i_TypeOfFuel == TypeOfFuel)
            {
                if (CurrentEnergy + i_FuelToAdd <= MaxEnergy && i_FuelToAdd > 0)
                {
                    CurrentEnergy += i_FuelToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
