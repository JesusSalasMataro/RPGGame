using RPGGame.Aliados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Guerrero : Aliado
    {
        public override void Atacar(Personaje Enemigo, int Danyo)
        {
            base.Atacar(Enemigo, Danyo);
            Vida += Fuerza / 5;
        }
    }
}
