namespace PodawanieLiczników
{
    public class Occupant
    {
        public string nazwisko { get; private set; }
        public string imie { get; private set; }

        public float gasBill { get; private set; }
        public float waterBill { get; private set; }
        public float electricityBill { get; private set; }
        public Occupant(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.gasBill = 0;
            this.waterBill = 0;
            this.electricityBill = 0;
            
        }

        public void ChoseMedia(char media)
        {
            switch (media)
            {
                case '1':
                    Console.WriteLine("Poniżej podaj nicznik gazu:");
                    var gas = Console.ReadLine();
                    AddGasCount(gas);
                    break;

                case '2':
                    Console.WriteLine("Poniżej podaj nicznik wody:");
                    var watter = Console.ReadLine();
                    AddWaterCount(watter);
                    break;

                case '3':
                    Console.WriteLine("Poniżej podaj nicznik prądu:");
                    var electricity = Console.ReadLine();
                    AddElectricityCount(electricity);
                    break;
                default:
                    throw new Exception("Wybrano zły numer proszę wybrać jeden z podany: 1 2 lub 3");


            }

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
        public GasMeter GetMediaGas(float Gas)
        {
            var newReadingGasMeter = new GasMeter(Gas);
            var newGasCostCalculate = newReadingGasMeter.GetGasConst();
            this.gasBill = newGasCostCalculate.gasCost;
            return newReadingGasMeter;
        }
        public Water GetMediaWater(float water)
        {
            var newReadingWaterMeter = new Water(water);
            var newWaterCostCalculate = newReadingWaterMeter.GetAquaCost();
            this.waterBill = newWaterCostCalculate.waterCost;
            return newReadingWaterMeter;
        }

        public ElectricityMeter GetMediaElectricity(float electricity)
        {
            var newReadingElectricityMeter = new ElectricityMeter(electricity);
            var newElectricityCostCalculate = newReadingElectricityMeter.GetElectricityCost();
            this.electricityBill = newElectricityCostCalculate.pradCost;
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

    }
}
