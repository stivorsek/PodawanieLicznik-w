namespace PodawanieLiczników
{
    public class MediaCostAfterMeter
    {
        public float gasCost { get; private set ; }
        public float pradCost { get; private set; }
        public float waterCost { get; private set; }
        public MediaCostAfterMeter()
        {
            this.waterCost = 0;
            this.gasCost = 0;
            this.pradCost = 0;
        }
        public void WaterCallculate(float watterDiff)
        {
            this.waterCost = (float)(watterDiff * 13.67);
        }
        public void GasCallculate(float gasDiff)
        {
             this.gasCost = (float)(gasDiff * 3.67);
        }

        public void ElectricityCallculate(float electricityDiff)
        {
            this.pradCost = (float)(electricityDiff * 1.67);
        }

    }
}
