namespace PodawanieLiczników
{
    public class MediaCostAfterMeter
    {
        public float gasCost { get; private set ; }
        public float electricityCost { get; private set; }
        public float waterCost { get; private set; }
        public MediaCostAfterMeter()
        {
            this.waterCost = waterCost;
            this.gasCost = gasCost;
            this.electricityCost = electricityCost;
        }
        public void WaterCallculate(float watterDiff) => this.waterCost = (float)(watterDiff * 13.67);
        public void GasCallculate(float gasDiff) => this.gasCost = (float)(gasDiff * 3.67);
        public void ElectricityCallculate(float electricityDiff) => this.electricityCost = (float)(electricityDiff * 1.67);
        
    }
}
