using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EindProject.Models;

namespace EindProject.Services
{
    public class SuncalculatorService
    {
        public double calculateSunWattM2(WheaterData wheaterData)
        {
                return wheaterData.forecast.Where(x => x.gr_w != "").Sum(x => Convert.ToDouble(x.gr_w.Replace('.', ',')));   
        }

        public double calculateWattsPerPanal(double wattM2, double efficentie)
        {
            return Math.Round(wattM2 * 1.6335 / 100 * efficentie);
        }

        public double calculateWattsTotal(double wattM2, double efficentie, int amountOfPanels)
        {
            return Math.Round(calculateWattsPerPanal(wattM2, efficentie) * amountOfPanels);
        }
    }
}
