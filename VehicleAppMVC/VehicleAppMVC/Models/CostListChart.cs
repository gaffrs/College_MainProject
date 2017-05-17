using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleAppMVC.Models
{
    public class CostListChart
    {
        public IEnumerable<Cost> CostsList;
        public double[] CostRunningCost;
    }
}