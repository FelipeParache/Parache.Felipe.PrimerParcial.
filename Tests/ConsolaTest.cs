using Entidades;
using static System.Formats.Asn1.AsnWriter;
using System;

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

        [TestMethod]
        public void Equals_ConsolasIguales_DeberiaRetornarTrue()
        {
            // Arrange
            Consola consolaA = new Xbox("Xbox360", 500, "Halo", 500, true);
            Consola consolaB = new Xbox("Xbox360", 500, "Halo", 500, true);

            // Act
            bool sonIguales = consolaA.Equals(consolaB);

            // Assert
            Assert.IsTrue(sonIguales);
        }

        [TestMethod]
        public void Equals_ConsolasDiferentes_DeberiaRetornarFalse()
        {
            // Arrange
            Consola consolaA = new Xbox("Xbox360", 500, "Halo", 500, true);
            Consola consolaB = new Xbox("Xbox360", 500, "Minecraft", 1000, false);

            // Act
            bool sonIguales = consolaA == consolaB;

            // Assert
            Assert.IsFalse(sonIguales);
        }

        [TestMethod]
        public void AgregarConsola_DeberiaAgregarConsola()
        {
            // Arrange
            GamingStore gamingStore = new GamingStore();
            Consola consola = new Nintendo("NintendoSwitch", 2000, "Pokemon", "GafasVR");

            // Act
            gamingStore += consola;

            // Assert
            Assert.AreEqual(1, gamingStore.listaConsolas.Count);
            Assert.IsTrue(gamingStore == consola);
        }

        [TestMethod]
        public void EliminarConsola_DeberiaEiminarConsola()
        {
            // Arrange
            GamingStore gamingStore = new GamingStore();
            Consola consolaA = new PlayStation("PS4", 1000, "GranTurismo", 2);
            Consola consolaB = new Xbox("XboxSeriesX", 2000, "Minecraft");
            gamingStore += consolaA;
            gamingStore += consolaB;

            // Act
            int indice = gamingStore.listaConsolas.IndexOf(consolaA);
            gamingStore -= indice;

            // Assert
            Assert.AreEqual(1, gamingStore.listaConsolas.Count);
            Assert.IsTrue(gamingStore == consolaB);
        }
    }
}