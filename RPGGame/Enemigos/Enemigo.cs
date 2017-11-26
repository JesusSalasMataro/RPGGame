using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Enemigos
{
    public class Enemigo : Personaje
    {
        public Tesoro Tesoro { get; set; }
        public int RangoVision { get; set; }
    }
}
