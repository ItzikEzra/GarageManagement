using System.Collections.Generic;

namespace Ex03.GarageLogic
{
  public abstract class Vehicles
    {
        public enum eTypeOfVehicle
        {
            Car = 1,
            MotorBike,
            Truck
        }

        protected EnergyType m_EnergyType;
        protected eTypeOfVehicle m_TypeOfVehicle;
        protected EnergyType.eTypeOfEnergy m_TypeOfEnergy;
        protected readonly string r_VehicleModelName;
        protected readonly string r_VehicleLicenseNum;
        protected float m_VehicleEnergyPercent;
        protected readonly List<Tire> m_Tire;
       
        public Vehicles(string i_VehicleModelName, string i_VehicleLicenseNum, float i_VehicleEnergyPercent)
        {
            r_VehicleModelName = i_VehicleModelName;
            r_VehicleLicenseNum = i_VehicleLicenseNum;
            m_VehicleEnergyPercent = i_VehicleEnergyPercent;
            m_Tire = new List<Tire>();
        }

        public string VehicleModelName
        {
            get
            {
                return r_VehicleModelName;
            }
        }

        public string VehicleLicenseNum
        {
            get
            {
                return r_VehicleLicenseNum;
            }
        }

        public float VehicleEnergyPercent
        {
            get
            {
                return m_VehicleEnergyPercent;
            }

            set
            {
                m_VehicleEnergyPercent = value;
            }
        }

        public List<Tire> CollectionOfTires
        {
            get
            {
                return m_Tire;
            }
        }

        public EnergyType TypeOfEnergy
        {
            get
            {
                return m_EnergyType;
            }
        }

        public string VehicleDetails()
        {
            string details;
            details = string.Format(
@"Vehicel license plate: {0}
Vehicel model name: {1}
Tires information:
{2}
Energy Percent: {3}%
Type Of Energy:{4}
{5}",
VehicleLicenseNum, VehicleModelName, CollectionOfTires[0].ToString(),
m_EnergyType.CurrentEnergy/m_EnergyType.MaxEnergy * 100, m_TypeOfEnergy.ToString(), TypeOfEnergy.ToString());
            return details;
        }
    }
}
