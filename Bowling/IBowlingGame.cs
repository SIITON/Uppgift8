using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift8.Bowling
{
    public interface IBowlingGame
    {
        void Roll(int pins_striked);
        int Score();

    }
}
