namespace PodawanieLiczników
{
    public class Occupant
    {
        public string waterAddTime { get; private set; }
        public string gasAddTime { get; private set; }
        public string electricityAddTime { get; private set; }
        public float gasBill { get; private set; }
        public float waterBill { get; private set; }
        public float electricityBill { get; private set; }
        public delegate void MeterAddedDelegate(object sender, EventArgs args);
        public event MeterAddedDelegate NewMeterAdded;
        public Occupant()
        {
            this.gasBill = 0;
            this.waterBill = 0;
            this.electricityBill = 0;
            this.waterAddTime = "0";
            this.gasAddTime = "0";
            this.electricityAddTime = "0";

        }

        public void ChoseMedia(string media)
        {
            if (char.TryParse(media, out char mediaNumber))
            {
                this.ChoseMedia(mediaNumber);
            }
            else
            {
                throw new Exception("Podana wartość nie jest cyfrą proszę spróbować jeszcze raz");
            }
        }
        public void ChoseMedia(char media)
        {
            switch (media)
            {
                case '1':
                    Console.WriteLine("Poniżej podaj licznik gazu:");
                    var gas = Console.ReadLine();
                    AddGasCount(gas);
                    break;

                case '2':
                    Console.WriteLine("Poniżej podaj licznik wody:");
                    var watter = Console.ReadLine();
                    AddWaterCount(watter);
                    break;

                case '3':
                    Console.WriteLine("Poniżej podaj licznik prądu:");
                    var electricity = Console.ReadLine();
                    AddElectricityCount(electricity);
                    break;
                case '4':
                    Bills();
                    break;
                case '5':
                    GetAllWaterBills();
                    break;
                default:
                    throw new Exception("Wybrano zły numer proszę wybrać jeden z podany: 1 2 lub 3");


            }

        }
        
        public GasMeter GetMediaGas(float Gas)
        {
            var newReadingGasMeter = new GasMeter(Gas);
            this.gasAddTime = newReadingGasMeter.gasAddTime.Last();
            this.gasBill = newReadingGasMeter.GetGasConst().gasCost;
            NewMeterAdded(this, new EventArgs());
            return newReadingGasMeter;
        }
        public WaterMeter GetMediaWater(float water)
        {
            var newReadingWaterMeter = new WaterMeter(water);
            this.waterAddTime = newReadingWaterMeter.waterAddTime.Last();
            this.waterBill = newReadingWaterMeter.GetAquaCost().waterCost;
            NewMeterAdded(this, new EventArgs());
            return newReadingWaterMeter;
        }
        public ElectricityMeter GetMediaElectricity(float electricity)
        {
            var newReadingElectricityMeter = new ElectricityMeter(electricity);
            this.electricityAddTime = newReadingElectricityMeter.electricityAddTime.Last();
            this.electricityBill = newReadingElectricityMeter.GetElectricityCost().electricityCost;
            NewMeterAdded(this, new EventArgs());
            return newReadingElectricityMeter;
        }

        public void AddGasCount(string Count)
        {
            if (float.TryParse(Count, out float CountInFloat))
            {
                this.GetMediaGas(CountInFloat);
            }
            else
            {
                throw new Exception("Podany licznik nie jest podany w zły formacie, spróbuj ponownie");
            }
        }
        public void AddWaterCount(string Count)
        {
            if (float.TryParse(Count, out float CountInFloat))
            {
                this.GetMediaWater(CountInFloat);
            }
            else
            {
                throw new Exception("Podany licznik nie jest podany w zły formacie, spróbuj ponownie");
            }
        }
        public void AddElectricityCount(string Count)
        {
            if (float.TryParse(Count, out float CountInFloat))
            {
                this.GetMediaElectricity(CountInFloat);
            }
            else
            {
                throw new Exception("Podany licznik nie jest podany w zły formacie, spróbuj ponownie");
            }
        }
        public void GetAllWaterBills()
        {
            Console.WriteLine("");
            Console.WriteLine("Poniżej rachunki za wode");
            var WaterBill = new WaterMeter();
            Console.WriteLine("");
            Console.WriteLine("Poniżej rachunki za gas");
            var GasBill = new GasMeter();
            Console.WriteLine(""); 
            Console.WriteLine("Poniżej rachunki za prad");
            var ElectricityBill = new ElectricityMeter();
        }
        public void Bills()
        {
            if (gasAddTime != "0" || electricityAddTime != "0" || waterAddTime != "0")
            {
                Console.WriteLine("Poniżej opłaty z obecnego okresu rozliczeniowego");
                Console.WriteLine("");
                if (gasAddTime != "0")
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Proszę zapłacić {gasBill} zł za gaz");
                    Console.WriteLine("");
                    Console.WriteLine($"Licznik podano {gasAddTime}");
                    Console.WriteLine("------------------------------------------------");
                }
                if (waterAddTime != "0")
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Proszę zapłacić {waterBill} zł za wode");
                    Console.WriteLine("");
                    Console.WriteLine($"Licznik podano {waterAddTime}");
                    Console.WriteLine("------------------------------------------------");
                }
                if (electricityAddTime != "0")
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Proszę zapłacić {electricityBill} zł za prad");
                    Console.WriteLine("");
                    Console.WriteLine($"Licznik podano {electricityAddTime}");
                    Console.WriteLine("------------------------------------------------");
                }
            }
            else
            {
                throw new Exception("Brak podanych liczników");
            }
        }
    }
}
