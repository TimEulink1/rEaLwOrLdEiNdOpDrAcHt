using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EindProject.Models
{
    public class EnvBenefits
    {
        public GasEmissionSaved gasEmissionSaved { get; set; }
        public double treesPlanted { get; set; }
        public double lightBulbs { get; set; }
    }
}
