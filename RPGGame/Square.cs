﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public class Square
    {
        public Posicion Location { get; set; }
        public int Height { get; set; }
        public SquareType Type { get; set; }
    }
}
