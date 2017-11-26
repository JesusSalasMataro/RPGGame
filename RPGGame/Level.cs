using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Level
    {
        public Square[][] Squares { get; set; }

        public Level(int levelWidth, int levelHeight)
        {
            Squares = new Square[levelWidth][];

            for (int i = 0; i < levelWidth; i++)
            {
                Squares[i] = new Square[levelHeight];

                for (int ii = 0; ii < levelHeight; ii++)
                {
                    Squares[i][ii] = new Square();
                }
            }
        }
    }
}
