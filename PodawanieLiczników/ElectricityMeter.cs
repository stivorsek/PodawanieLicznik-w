namespace PodawanieLiczników
{
    public class ElectricityMeter : MediaBase
    {
        public const string FileName = "ListaPradu.txt";
        public float electricityDiff { get; set; }

        private List<float> electricityList = new List<float>();
        public List<string> electricityAddTime = new List<string>();
        public ElectricityMeter()
        {
            MediaReader(1);
            var MeterPlusDate = electricityList.Zip(electricityAddTime, (m, d) => new { Meter = m, Date = d });
            foreach (var electricity in MeterPlusDate)
            {
                var electricityCount = electricity.Meter.ToString();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Warosc licznika: {electricityCount}   Data: {electricity.Date}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public ElectricityMeter(float Licznik)
        {
            
            MediaReader(Licznik);
            using (var writer = File.AppendText(FileName))
            {
                var OstatniWpis = electricityList.Last();
                if (Licznik > OstatniWpis)
                {
                    var localDateInString = DateTime.Now.ToString();
                    var LineInFile = Licznik.ToString() + " | " + localDateInString;
                    writer.WriteLine(LineInFile);
                    electricityAddTime.Add(localDateInString);
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

                File.WriteAllText(FileName, "0" + Environment.NewLine);

            }
            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (line != "0")
                    {
                        var electricityCountInList = line.Remove(line.Length - 21, 21);
                        float.TryParse(electricityCountInList, out float CountInFloat);
                        var DateInList = line.Remove(0, electricityCountInList.Length + 3);
                        electricityList.Add(CountInFloat);
                        electricityAddTime.Add(DateInList);
                        line = reader.ReadLine();
                    }
                    else
                    {
                        var nextLine = float.Parse(line);
                        electricityList.Add(nextLine);
                        line = reader.ReadLine();
                    }
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