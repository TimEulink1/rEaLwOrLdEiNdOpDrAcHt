using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindProject.Models
{
    public class CurrentPower
    {
        public double power { get; set; }
    }

    public class LastDayData
    {
        public double energy { get; set; }
    }

    public class LastMonthData
    {
        public double energy { get; set; }
    }

    public class LastYearData
    {
        public double energy { get; set; }
    }

    public class LifeTimeData
    {
        public double energy { get; set; }
    }

    public class Overview
    {
        public string lastUpdateTime { get; set; }
        public LifeTimeData lifeTimeData { get; set; }
        public LastYearData lastYearData { get; set; }
        public LastMonthData lastMonthData { get; set; }
        public LastDayData lastDayData { get; set; }
        public CurrentPower currentPower { get; set; }
        public string measuredBy { get; set; }
    }

    public class InverterResult
    {
        public Overview overview { get; set; }
    }


}
