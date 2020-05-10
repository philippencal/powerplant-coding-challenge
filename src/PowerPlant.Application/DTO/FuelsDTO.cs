using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PowerPlant.Application.DTO
{
    [JsonObject]
    public class FuelsDTO
    {
        [JsonProperty("gas(euro/MWh)")]
        [Range(1, int.MaxValue, ErrorMessage = "Inform the gas price per MWh")]
        public decimal Gas { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        [Range(1, int.MaxValue, ErrorMessage = "Inform the kerosine price per MWh")]
        public decimal Kerosine { get; set; }

        [JsonProperty("co2(euro/ton)")]
        [Range(1, int.MaxValue, ErrorMessage = "Inform the co2 cost per ton")]
        public decimal Co2 { get; set; }

        [JsonProperty("wind(%)")]
        [Range(0, 100, ErrorMessage = "Inform the wind percentage between 0 and 100")]
        public decimal Wind { get; set; }
    }
}
