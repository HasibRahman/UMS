using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StationaryManagement.Gateway;
using StationaryManagement.Models;

namespace StationaryManagement.Manager
{
    public class StationaryTypeManager
    {
        StationaryTypeGateway stationaryTypeGateway = new StationaryTypeGateway();
        public List<StationaryType> ViewAllStationaryType()
        {
            return stationaryTypeGateway.ViewAllStationaryType();
        }
    }
}