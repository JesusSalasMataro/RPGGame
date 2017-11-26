using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGGame;

namespace RPGGameTests
{
    [TestClass]
    public class RequisitosTests
    {
        [TestMethod]
        public void Personajes_Inician_Juego_Con_100_De_Vida()
        {
            // ARRANGE
            Guerrero guerrero;

            // ACT
            guerrero = new Guerrero();

            // ASSERT
            Assert.AreEqual(100, guerrero.Vida);
        }

        [TestMethod]
        public void Vida_Personajes_Tiene_Que_Estar_Entre_0_Y_100()
        {
            // ARRANGE
            Guerrero guerrero1 = new Guerrero();
            Guerrero guerrero2 = new Guerrero();

            // ACT
            guerrero1.Vida = 200;
            guerrero2.Vida = -10;

            // ASSERT
            Assert.AreEqual(100, guerrero1.Vida);
            Assert.AreEqual(0, guerrero2.Vida);
        }

        [TestMethod]
        public void Personaje_Muere_Con_Vida_0()
        {
            // ARRANGE
            Guerrero guerrero = new Guerrero();            

            // ACT
            guerrero.Vida = 0;

            // ASSERT
            Assert.IsFalse(guerrero.Vivo());            
        }

        [TestMethod]
        public void Personajes_Muertos_No_Pueden_Desplazarse()
        {
            // ARRANGE
            Guerrero guerrero = new Guerrero();

            // ACT
            guerrero.Vida = 0;
            Posicion nuevaPosicion = new Posicion();
            nuevaPosicion.CoordenadaX = 10;
            nuevaPosicion.CoordenadaZ = 12;
            guerrero.Desplazar(nuevaPosicion);

            // ASSERT
            Assert.AreEqual(0, guerrero.Posicion.CoordenadaX);
            Assert.AreEqual(0, guerrero.Posicion.CoordenadaZ);
        }

        [TestMethod]
        public void Personajes_Muertos_No_Pueden_Atacar()
        {
            // ARRANGE
            Guerrero guerrero1 = new Guerrero();
            Guerrero guerrero2 = new Guerrero();

            // ACT
            guerrero1.Vida = 0;
            guerrero1.Fuerza = 20;
            guerrero1.Atacar(guerrero2, guerrero1.Fuerza);

            // ASSERT
            Assert.AreEqual(100, guerrero2.Vida);            
        }

        [TestMethod]
        public void Personaje_Solo_Puede_Atacar_A_Otro_Dentro_De_Su_Rango_De_Ataque()
        {
            // ARRANGE
            Guerrero guerrero1 = new Guerrero();
            Guerrero guerrero2 = new Guerrero();

            // ACT
            guerrero1.Rango = 10;
            guerrero1.Fuerza = 20;
            Posicion posicion = new Posicion();
            posicion.CoordenadaX = 8;
            posicion.CoordenadaZ = 10;
            guerrero2.Posicion = posicion;
            guerrero1.Atacar(guerrero2, guerrero1.Fuerza);

            // ASSERT
            Assert.AreEqual(100, guerrero2.Vida);
        }

        [TestMethod]
        public void Guerreros_Recuperan_Vida_5_PorCiento_Danyo_Producido_Al_Atacar()
        {
            // ARRANGE
            Guerrero guerrero1 = new Guerrero();
            Guerrero guerrero2 = new Guerrero();

            // ACT
            guerrero1.Vida = 70;
            guerrero1.Fuerza = 20;
            guerrero1.Atacar(guerrero2, guerrero1.Fuerza);

            // ASSERT
            Assert.AreEqual(74, guerrero1.Vida);
        }

        [TestMethod]
        public void Magos_Pueden_Curar_A_Otros_Personajes()
        {
            // ARRANGE
            Mago mago = new Mago();
            Guerrero guerrero = new Guerrero();

            // ACT
            guerrero.Vida = 70;
            mago.PoderMagico = 10;
            mago.Curar(guerrero);            

            // ASSERT
            Assert.AreEqual(80, guerrero.Vida);
        }

        [TestMethod]
        public void Magos_Pueden_Curarse_A_Si_Mismos()
        {
            // ARRANGE
            Mago mago = new Mago();

            // ACT
            mago.Vida = 70;
            mago.PoderMagico = 10;
            mago.Curar(mago);

            // ASSERT
            Assert.AreEqual(80, mago.Vida);
        }

        [TestMethod]
        public void Arqueros_Empiezan_Con_80_De_Vida()
        {
            // ARRANGE
            Arquero arquero;

            // ACT
            arquero = new Arquero();

            // ASSERT
            Assert.AreEqual(80, arquero.Vida);
        }

        [TestMethod]
        public void Arqueros_Se_Desplazan_A_UnoYMedio_Por_Su_Velocidad()
        {
            // ARRANGE
            Arquero arquero = new Arquero();

            // ACT
            arquero.Velocidad = 10;
            Posicion nuevaPosicion = new Posicion();
            nuevaPosicion.CoordenadaX = 7;
            nuevaPosicion.CoordenadaZ = 8;
            arquero.Desplazar(nuevaPosicion);

            // ASSERT
            Assert.AreEqual(7, arquero.Posicion.CoordenadaX);
            Assert.AreEqual(8, arquero.Posicion.CoordenadaZ);
        }

        [TestMethod]
        public void Arqueros_Pueden_Atacar_A_2_Enemigos_A_La_Vez_Haciendo_La_Mitad_De_Danyo_A_Cada_Uno()
        {
            // ARRANGE
            Arquero arquero = new Arquero();
            Guerrero guerrero1 = new Guerrero();
            Guerrero guerrero2 = new Guerrero();

            // ACT
            guerrero2.Vida = 85;
            arquero.Fuerza = 20;
            arquero.Atacar(guerrero1, guerrero2, arquero.Fuerza);

            // ASSERT
            Assert.AreEqual(90, guerrero1.Vida);
            Assert.AreEqual(75, guerrero2.Vida);
        }

        [TestMethod]
        public void ModificadorAtaque_EsMenorA_1_Cuando_Se_Ataca_Desde_Una_Altura_Inferior()
        {
            // ARRANGE
            GameController gameController = new GameController();
            Square square1 = new Square();
            Square square2 = new Square();

            square1.Height = 2;
            square2.Height = 5;

            // ACT
            decimal expectedModificadorAtaque = (decimal)0.55;
            decimal actualModificadorAtaque = gameController.ModificadorAtaque(square1, square2);
                
            // ASSERT
            Assert.AreEqual(expectedModificadorAtaque, actualModificadorAtaque);
        }

        [TestMethod]
        public void ModificadorAtaque_EsMayorA_1_Cuando_Se_Ataca_Desde_Una_Altura_Inferior()
        {
            // ARRANGE
            GameController gameController = new GameController();
            Square square1 = new Square();
            Square square2 = new Square();

            square1.Height = 5;
            square2.Height = 2;

            // ACT
            decimal expectedModificadorAtaque = (decimal)1.3;
            decimal actualModificadorAtaque = gameController.ModificadorAtaque(square1, square2);

            // ASSERT
            Assert.AreEqual(expectedModificadorAtaque, actualModificadorAtaque);
        }
    }
}
