namespace PodawanieLiczników
{
    public class Water : Media
    {
        public const string FileName = "ListaWody.txt";
        public float waterDiff { get; set; }

        private List<float> waterList = new List<float>();
        public Water(float Licznik)
        {
            MediaReader(Licznik); 

            using (var writer = File.AppendText(FileName))
            {
                var OstatniWpis = waterList.Last();
                if (Licznik > OstatniWpis)
                {
                    writer.WriteLine(Licznik);
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

                File.WriteAllText(FileName, "0");

            }
            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var nextLine = float.Parse(line);
                    waterList.Add(nextLine);
                    line = reader.ReadLine();
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
