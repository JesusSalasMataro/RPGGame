using RPGGame.Aliados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Arquero : Aliado
    {
        public Arquero() : base()
        {
            Vida = 80;
        }

        public void Atacar(Personaje Enemigo1, Personaje Enemigo2, int Danyo)
        {
            base.Atacar(Enemigo1, Danyo / 2);
            base.Atacar(Enemigo2, Danyo / 2);
        }

        protected override bool NuevaPosicionEnRango(Posicion NuevaPosicion)
        {
            return Math.Abs(NuevaPosicion.CoordenadaX - Posicion.CoordenadaX) +
                Math.Abs(NuevaPosicion.CoordenadaZ - Posicion.CoordenadaZ) <= Velocidad * 1.5;
        }

        protected override void RecibirDaño(int Danyo)
        {
            if (Vida - Danyo <= 0 && Sobrevivir())
            {
                Vida = 5;
            }
            else
            {
                base.RecibirDaño(Danyo);
            }            
        }

        private bool Sobrevivir()
        {
            Random Random = new Random();
            int NumAleatorio = Random.Next(100);

            return NumAleatorio <= 30;
        }
    }
}
