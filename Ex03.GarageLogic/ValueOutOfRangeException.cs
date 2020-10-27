using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float  m_MaxValue;
        private readonly float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        : base(string.Format(@"The number need to be between {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
