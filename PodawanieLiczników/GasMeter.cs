namespace PodawanieLiczników
{
    public class GasMeter : MediaBase
    {
        public const string FileName = "ListaGazu.txt";
        public float gasDiff { get; set; }

        private List<float> gasList = new List<float>();
        public List<string> gasAddTime = new List<string>();
        public GasMeter()
        {
            MediaReader(1);
            var MeterPlusDate = gasList.Zip(gasAddTime, (m, d) => new { Meter = m, Date = d });         
            foreach (var gas in MeterPlusDate)
            {
                var gasCount = gas.Meter.ToString();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Warosc licznika: {gasCount}   Data: {gas.Date}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public GasMeter(float Licznik)
        {
                MediaReader(Licznik);
                using (var writer = File.AppendText(FileName))
                {
                    var OstatniWpis = gasList.Last();
                    if (Licznik > OstatniWpis)
                    {
                        var localDateInString = DateTime.Now.ToString();
                        var LineInFile = Licznik.ToString() + " | " + localDateInString;
                        gasAddTime.Add(localDateInString);
                        writer.WriteLine(LineInFile);
                        this.gasDiff = Licznik - OstatniWpis;
                        GetGasConst();
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
                File.WriteAllText(FileName, "0 | 00.00.2022 00:00:00" + Environment.NewLine);
            }
            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (line != "0")
                    {
                        var gasCountInList = line.Remove(line.Length - 21, 21);
                        float.TryParse(gasCountInList, out float CountInFloat);
                        var DateInList = line.Remove(0, gasCountInList.Length + 3);
                        gasList.Add(CountInFloat);
                        gasAddTime.Add(DateInList);
                        line = reader.ReadLine();
                    }
                    else
                    {
                        var nextLine = float.Parse(line);
                        gasList.Add(nextLine);
                        line = reader.ReadLine();
                    }
                }
            }
        }
        public MediaCostAfterMeter GetGasConst()
        {
            var GasConst = new MediaCostAfterMeter();
            GasConst.GasCallculate(gasDiff);
            return GasConst;
            
        }

    }
}
