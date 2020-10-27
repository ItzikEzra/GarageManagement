namespace Ex03.GarageLogic
{
    public abstract  class EnergyType
    {
        public enum eTypeOfEnergy
        {
            Electric = 1,
            Fuel
        }

        protected readonly float r_MaxEnergy;
        protected float m_CurrentEnergy;

        public EnergyType(float i_MaxEnergy, float i_CurrentEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }


    }
}
