using RPGGame.Aliados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Mago : Aliado
    {
        public int PoderMagico { get; set; }

        public void Curar(Personaje Aliado)
        {
            Aliado.Curarse(PoderMagico);
        }
    }
}
