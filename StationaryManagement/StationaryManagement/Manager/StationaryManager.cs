using System.Collections.Generic;
using StationaryManagement.Gateway;
using StationaryManagement.Models;

namespace StationaryManagement.Manager
{
    public class StationaryManager
    {
        StationaryGateway stationaryGateway = new StationaryGateway();

        public int SaveStationary(Stationary stationary)
        {
            return stationaryGateway.SaveStationary(stationary);
        }

        public List<Stationary> ViewSelectedStationary(int typeId)
        {
            return stationaryGateway.ViewSelectedStationary(typeId);
        }

        public decimal GettotalPrice(int typeId)
        {
            return stationaryGateway.GettotalPrice(typeId);
        }


    }
}