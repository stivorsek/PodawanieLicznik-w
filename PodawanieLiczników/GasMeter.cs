namespace PodawanieLiczników
{
    public class GasMeter : Media
    {
        public const string FileName = "ListaGazu.txt";
        public float gasDiff { get; set; }

        private List<float> gasList = new List<float>();
        public GasMeter(float Licznik)
        {
                MediaReader(Licznik);
                using (var writer = File.AppendText(FileName))
                {
                    var OstatniWpis = gasList.Last();
                    if (Licznik > OstatniWpis)
                    {
                        writer.WriteLine(Licznik);
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
                File.WriteAllText(FileName, "0");
            }
            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var nextLine = float.Parse(line);
                    gasList.Add(nextLine);
                    line = reader.ReadLine();
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
