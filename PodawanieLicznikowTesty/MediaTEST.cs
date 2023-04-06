using PodawanieLiczników;

namespace PodawanieLicznikowTesty
{
    public class MediaTEST
    {

        [Test]
        public void TestThatAquaIsStillDividedByRate()
        {
            // Aby porównanie działało trzeba zwiększy zmiennną testAquaONE o 1 
            var TestowyUzytkownik = new Occupant("Damian", "Dzieciol");
            float testAquaONE = 10002;
            TestowyUzytkownik.GetMediaAqua(testAquaONE);
            float testAquaTWO = TestowyUzytkownik.wodaSum;
            float x = (float)(1 * 13.67);
            Assert.AreEqual(testAquaTWO, x);

        }
        [Test]
        public void TestThatGasIsStillDividedByRate()
        {
            // Aby porównanie działało trzeba zwiększy zmiennną testGasONE o 1 
            var TestowyUzytkownik = new Occupant("Damian", "Dzieciol");
            float testGasONE = 10002;
            TestowyUzytkownik.GetMediaGas(testGasONE);
            float testGasTWO = TestowyUzytkownik.gasSum;
            float y = (float)(1 * 3.67);

            Assert.AreEqual(testGasTWO, y);

        }
        [Test]
        public void TestThatElecticityIsStillDividedByRate()
        {

            // Aby porównanie działało trzeba zwiększy zmiennną testElectricityONE o 1 
            var TestowyUzytkownik = new Occupant("Damian", "Dzieciol");
            float testElectricityONE = 10002;
            TestowyUzytkownik.GetMediaPrad(testElectricityONE);
            float testElectricityTWO = TestowyUzytkownik.pradSum;
            float z = (float)(1 * 1.67);

            Assert.AreEqual(testElectricityTWO, z);

        }
    }
}