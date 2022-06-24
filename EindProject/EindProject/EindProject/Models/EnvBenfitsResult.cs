using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EindProject.Models
{
    public class EnvBenfitsResult
    {

        [JsonPropertyName("envBenefits")]
        public EnvBenefits EnvBenefits { get; set; }
    }
}
