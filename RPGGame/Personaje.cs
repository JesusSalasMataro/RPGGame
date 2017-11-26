using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public abstract class Personaje
    {
        private int _Vida;

        public int Vida {
            get 
            {
                return _Vida;
            }
            set 
            {
                if (value < 0)
                {
                    _Vida = 0;
                }
                else if (value > 100)
                {
                    _Vida = 100;
                }
                else
                {
                    _Vida = value;
                }                
            }
        }

        public int Rango { get; set; }
        public int Fuerza { get; set; }
        public Posicion Posicion { get; set; }
        public int Velocidad { get; set; }

        public Personaje()
        {
            Vida = 100;
            Posicion = new Posicion();
        }

        #region Métodos públicos
        
        public virtual void Desplazar(Posicion NuevaPosicion)
        {
            if (Vivo())
            {
                Posicion.CoordenadaX = NuevaPosicion.CoordenadaX;
                Posicion.CoordenadaZ = NuevaPosicion.CoordenadaZ;
            }
        }

        public virtual void Atacar(Personaje Enemigo, int Danyo)
        {
            if (Vivo() && EnemigoDentroRango(Enemigo))
            {
                Enemigo.RecibirDaño(Danyo);
            }          
        }

        public void Curarse(int PoderMagico)
        {
            Vida += PoderMagico;
        }

        public bool Vivo()
        {
            return Vida > 0;
        }

        #endregion

        #region Protected methods
        
        protected virtual void RecibirDaño(int Danyo)
        {
            Vida -= Danyo;
        }

        protected virtual bool NuevaPosicionEnRango(Posicion NuevaPosicion)
        {
            return Math.Abs(NuevaPosicion.CoordenadaX - Posicion.CoordenadaX) +
                Math.Abs(NuevaPosicion.CoordenadaZ - Posicion.CoordenadaZ) <= Velocidad;
        }

        #endregion

        #region Private methods

        private bool EnemigoDentroRango(Personaje Enemigo)
        {
            return Math.Abs(Enemigo.Posicion.CoordenadaX - Posicion.CoordenadaX) +
                Math.Abs(Enemigo.Posicion.CoordenadaZ - Posicion.CoordenadaZ) <= Rango;
        }
        #endregion

    }
}
