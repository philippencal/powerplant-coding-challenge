namespace PowerPlant.Domain.Models
{
    public abstract class PowerPlant
    {
        public string Name { get; set; }
        public decimal Efficiency { get; set; }
        public int MinimumPowerAmount { get; set; }
        public int MaximunPowerAmount { get; set; }

        public abstract decimal CalculateEnergyCost();
        public abstract decimal ProducePower(int load);
    }
}
