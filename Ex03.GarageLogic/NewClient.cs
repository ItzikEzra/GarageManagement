using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NewClient
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed,
            Paid
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private Vehicles m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public NewClient(string i_OwnerName, string i_OwnerPhoneNumber, Vehicles i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }

        public eVehicleStatus Vehiclestatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicles Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string newClientDetails;
            newClientDetails = string.Format(
@"Owner name: {0}
Owner phone: {1}
Vehicle status: {2}{3}",
            OwnerName, OwnerPhoneNumber, Vehiclestatus.ToString(), Environment.NewLine);
            str.Append(newClientDetails);
            str.Append(Vehicle.ToString());
            return str.ToString();
        }
    }
}

