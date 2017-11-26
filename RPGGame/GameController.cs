using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class GameController
    {
        public int DiferenciaAltura(Square square1, Square square2)
        {
            return Math.Abs(square2.Height - square1.Height);
        }

        public decimal ModificadorAtaque(Square square1, Square square2)
        {
            int diferenciaAlturaCasillas = DiferenciaAltura(square1, square2);
            float modificadorAtaque = 0;

            if (square2.Height > square1.Height)
            {
                modificadorAtaque = 1 - (float)0.15 * diferenciaAlturaCasillas;

                if (modificadorAtaque < 0)
                {
                    modificadorAtaque = 0;
                }
            }
            else if (square2.Height < square1.Height)
            {
                modificadorAtaque = 1 + (float)0.1 * diferenciaAlturaCasillas;
            }

            return Math.Round((decimal)modificadorAtaque, 2);
        }

        public void MoverPersonaje(Level level, Square initialSquare, Square finalSquare)
        {
            
        }
    }
}
