using Entidades;

namespace Tests
{
    [TestClass]
    public class ConsolaTest
    {
        [TestMethod]
        public void MostrarInformacionResumida_DeberiaRetornarInformacionResumida()
        {
            // Arrange
            Consola consolaA = new Xbox("Xbox360", 500, "Halo", 500, true);
            Consola consolaB = new Nintendo("NintendoNes", 1000, "Pokemon", "Pistola");
            Consola consolaC = new PlayStation("PS5", 2000, "Uncharted", 4, true, true);

            // Act
            string infoResumidaA = consolaA.MostrarInformacion();
            string infoResumidaB = consolaB.MostrarInformacion();
            string infoResumidaC = consolaC.MostrarInformacion();

            // Assert
            Assert.AreEqual("- Consola Xbox360 - 500 GB - Incluye XboxLiveGold - 500 GB Nube", infoResumidaA);
            Assert.AreEqual("- Consola NintendoNes - 1000 GB - Incluye Pistola", infoResumidaB);
            Assert.AreEqual("- Consola PS5 - 2000 GB - Incluye PsPlus - 4 controles", infoResumidaC);

        }
    }
}