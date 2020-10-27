namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly float r_TireAirMaxPressure;
        private readonly string r_TireModelName;
        private float m_TireCurrentAirPressure;

        public Tire(string i_Manufactor, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_TireModelName = i_Manufactor;
            r_TireAirMaxPressure = i_MaxAirPressure;
            m_TireCurrentAirPressure = i_CurrentAirPressure;
        }

        public string TireModelName
        {
            get
            {
                return r_TireModelName;
            }
        }

        public float TireMaxPressure
        {
            get
            {
                return r_TireAirMaxPressure;
            }
        }

        public float TireCurrentPressure
        {
            get
            {
                return m_TireCurrentAirPressure;
            }

            set
            {
                m_TireCurrentAirPressure = value;
            }
        }

        internal void inflateTire(float i_AirToInflate)
        {
            if (TireCurrentPressure + i_AirToInflate <= TireMaxPressure && i_AirToInflate > 0)
            {
                TireCurrentPressure += i_AirToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(0, TireMaxPressure - TireCurrentPressure);
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"Air pressure: {0}
Manufacturer: {1}",
            TireCurrentPressure, TireModelName);
            return str;
        }
    }
}
