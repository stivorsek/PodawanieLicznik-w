namespace PodawanieLiczników
{
    public class ElectricityMeter : Media
    {
        public const string FileName = "ListaPradu.txt";
        public float electricityDiff { get; set; }

        private List<float> electricityList = new List<float>();
        public ElectricityMeter(float Licznik)
        {
            
            MediaReader(Licznik);
            using (var writer = File.AppendText(FileName))
            {
                var OstatniWpis = electricityList.Last();
                if (Licznik > OstatniWpis)
                {
                    writer.WriteLine(Licznik);
                    this.electricityDiff = Licznik - OstatniWpis;
                    GetElectricityCost();
                }
                else
                {
                    throw new Exception("Podany wpis jest niższy o ostatniego wpisz go ponownie");
                }
            }
        }
        public override void MediaReader(float Licznik)
        {
            if (!File.Exists(FileName))
            {

                File.WriteAllText(FileName, "0");

            }
            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var nextLine = float.Parse(line);
                    electricityList.Add(nextLine);
                    line = reader.ReadLine();
                }
            }
        }
        public MediaCostAfterMeter GetElectricityCost()
        {
            var MediaCost = new MediaCostAfterMeter();
            MediaCost.ElectricityCallculate(electricityDiff);
            return MediaCost;
        }
    }

}