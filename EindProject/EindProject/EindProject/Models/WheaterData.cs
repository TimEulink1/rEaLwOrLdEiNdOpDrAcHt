using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindProject.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Current
    {
        public string station { get; set; }
        public string time { get; set; }
        public string cet { get; set; }
        public string elev { get; set; }
        public string az { get; set; }
        public string temp { get; set; }
        public string gr_w { get; set; }
        public string gr { get; set; }
        public string sd { get; set; }
        public string tc { get; set; }
        public string vis { get; set; }
        public string prec { get; set; }
        public string sr { get; set; }
        public string ss { get; set; }
    }

    public class Forecast
    {
        public string time { get; set; }
        public string cet { get; set; }
        public string elev { get; set; }
        public string az { get; set; }
        public string temp { get; set; }
        public string gr_w { get; set; }
        public string gr { get; set; }
        public string sd { get; set; }
        public string tc { get; set; }
        public string lc { get; set; }
        public string mc { get; set; }
        public string hc { get; set; }
        public string vis { get; set; }
        public string prec { get; set; }
    }

    public class Plaatsnaam
    {
        public string plaats { get; set; }
    }

    public class WheaterData
    {
        public List<Plaatsnaam> plaatsnaam { get; set; }
        public List<Current> current { get; set; }
        public List<Forecast> forecast { get; set; }
    }
}
