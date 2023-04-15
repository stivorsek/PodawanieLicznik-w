namespace PodawanieLiczników
{
    public class WaterMeter : MediaBase
    {
        public const string FileName = "ListaWody.txt";
        public float waterDiff { get; set; }

        private List<float> waterList = new List<float>();

        public List<string> waterAddTime = new List<string>();

        public WaterMeter()
        {
            MediaReader(1);
            var MeterPlusDate = waterList.Zip(waterAddTime, (m, d) => new { Meter = m, Date = d });
            foreach (var water in MeterPlusDate)
            {
                var waterCount = water.Meter.ToString();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Warosc licznika: {waterCount}   Data: {water.Date}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public WaterMeter(float Licznik)
        {
            MediaReader(Licznik);

            using (var writer = File.AppendText(FileName))
            {
                var OstatniWpis = waterList.Last();

                if (Licznik > OstatniWpis)
                {
                    var localDateInString = DateTime.Now.ToString();
                    var LineInFile = Licznik.ToString() + " | " + localDateInString;
                    waterAddTime.Add(localDateInString);
                    writer.WriteLine(LineInFile);
                    this.waterDiff = Licznik - OstatniWpis;
                    GetAquaCost();
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
            else
            {
                using (var reader = File.OpenText(FileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (line != "0")
                        {
                            var watterCountInList = line.Remove(line.Length - 21, 21);
                            float.TryParse(watterCountInList, out float CountInFloat);
                            var DateInList = line.Remove(0, watterCountInList.Length + 3);
                            waterList.Add(CountInFloat);
                            waterAddTime.Add(DateInList);
                            line = reader.ReadLine();
                        }
                        else
                        {
                            var nextLine = float.Parse(line);
                            waterList.Add(nextLine);
                            line = reader.ReadLine();
                        }
                    }

                }
            }
        }
        public MediaCostAfterMeter GetAquaCost()
        {
            var MediaCost = new MediaCostAfterMeter();
            MediaCost.WaterCallculate(waterDiff);
            return MediaCost;
        }

    }
}
