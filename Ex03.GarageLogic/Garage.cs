using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, NewClient> m_VehicleList = new Dictionary<string, NewClient>();

        public Dictionary<string, NewClient> VehicleList
        {
            get
            {
                return m_VehicleList;
            }

            set
            {
                m_VehicleList = value;
            }
        }

        public string IsAlreadyInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicles i_Vehicle)
        {
            StringBuilder inGarageMessage = new StringBuilder();
            if (!VehicleList.ContainsKey(i_Vehicle.VehicleLicenseNum))
            {
                VehicleList.Add(i_Vehicle.VehicleLicenseNum, new NewClient(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle));
                ChangeStatus(i_Vehicle.VehicleLicenseNum, NewClient.eVehicleStatus.InRepair);
                inGarageMessage.Append( "The vehicle was inserted to the garage");
            }
            else
            {
                ChangeStatus(i_Vehicle.VehicleLicenseNum, NewClient.eVehicleStatus.InRepair);
                inGarageMessage.Append("The vehicle is already in the garage");
            }

            return inGarageMessage.ToString();
        }

        public List<string> GarageVehiclesList()
        {
            List<string> vehicleList = new List<string>();
            foreach (KeyValuePair<string, NewClient> vehicle in VehicleList)
            {
                vehicleList.Add(vehicle.Key);
            }

            return vehicleList;
        }

        public List<string> GarageVehiclesListByStatus(NewClient.eVehicleStatus i_Status)
        {
            List<string> vehicleList = new List<string>();
            foreach (KeyValuePair<string, NewClient> vehicle in VehicleList)
            {
                if (i_Status == vehicle.Value.Vehiclestatus)
                {
                    vehicleList.Add(vehicle.Key);
                }
            }

            return vehicleList;
        }

        public void ChangeStatus(string i_LicenseNum, NewClient.eVehicleStatus i_status)
        {
            if (isExist(i_LicenseNum))
            {
                VehicleList[i_LicenseNum].Vehiclestatus = i_status;
            }
        }

        public void TiresInflateToMax(string i_LicenseNum)
        {
            if (isExist(i_LicenseNum))
            {
                foreach (Tire wheel in VehicleList[i_LicenseNum].Vehicle.CollectionOfTires)
                {
                    wheel.inflateTire(wheel.TireMaxPressure - wheel.TireCurrentPressure);
                }
            }
        }

        public void RefuelVehicle(string i_LicenseNum, FueledVehicle.eTypeOfFuel i_Fuel, float i_Amount)
        {
            if (isExist(i_LicenseNum))
            {
                if (VehicleList[i_LicenseNum].Vehicle.TypeOfEnergy is FueledVehicle)
                {
                    ((FueledVehicle)VehicleList[i_LicenseNum].Vehicle.TypeOfEnergy).RefuelVehicle(i_Amount, i_Fuel);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void RechangeVehicle(string i_LicenseNum, float i_MinutesToCharge)
        {
            float houers = i_MinutesToCharge / 60;
            if (isExist(i_LicenseNum))
            {
                if (VehicleList[i_LicenseNum].Vehicle.TypeOfEnergy is ElectricVehicle)
                {
                    ((ElectricVehicle)VehicleList[i_LicenseNum].Vehicle.TypeOfEnergy).RechargeBatteryVehicle(houers);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public bool IsGarageEmpty()
        {
            bool isEmpty = false;
            if (m_VehicleList.Count == 0)
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        public string VehicleDetails(string i_LicenseNum)
        {
            string vehicleDetails = null;
            if (isExist(i_LicenseNum))
            {
                vehicleDetails = VehicleList[i_LicenseNum].ToString();
            }

            return vehicleDetails;
        }

        private bool isExist(string i_LicenseNum)
        {
            bool ifIsExist = true;
            if (!VehicleList.ContainsKey(i_LicenseNum))
            {
                throw new ArgumentException();
            }

            return ifIsExist;
        }
    }

}
