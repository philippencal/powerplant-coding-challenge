using System;

namespace PowerPlant.Domain.Models
{
    public class WindTurbinePlant : PowerPlant
    {
        /// <summary>
        /// wind in percentage
        /// </summary>
        private decimal Wind { get; }

        public WindTurbinePlant(decimal wind)
        {
            Wind = wind;
        }

        public override decimal CalculateEnergyCost()
        {
            return decimal.Zero;
        }

        public override int ProducePower(int load)
        {
            var windMinimumPowerAmount = (int)(Wind * MinimumPowerAmount) / 100;
            var windMaximumPowerAmount = (int)(Wind * MaximumPowerAmount) / 100;

            if (windMinimumPowerAmount > load)
            {
                return 0;
            }

            return load > windMaximumPowerAmount ? windMaximumPowerAmount : load;
        }

        public override bool CanOperate()
        {
            return Efficiency > 0 && MaximumPowerAmount > 0 && Wind > 0;
        }
    }
}
