using Mole_Shooter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mole_Shooter
{
    //paveldi ImageBase klases funkcijas ir atributus
    class Cmole : ImageBase
    {
        private Rectangle moleSpot = new Rectangle();


        public Cmole() : base(Resources.Mole) // <- taip patenkama i Resources aplanka ir paimami reikalingi duomenys
        {
            moleSpot.X = left + 40;
            moleSpot.Y = top - 36;
            moleSpot.Width = 80;
            moleSpot.Height = 72;

        }


      
        public void Update(int X, int Y) //atnaujina esama Mole pozicija
        {
            left = X;
            top = Y;
            moleSpot.X = left + 20;
            moleSpot.Y = top - 1;
        }

        public bool Hit(int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1); //Create a cursor rect - quick way to check for hit.

            if (moleSpot.Contains(c))
            {
                return true;
            }
            return false;
        }
    }
}
