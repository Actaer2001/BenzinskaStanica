using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class PumpingManager
    {
        public delegate void PumpingHandler(object sender);

        public static event PumpingHandler? OnPumped;

        public static void Pumped(object sender)
        {
            OnPumped?.Invoke(sender);
        }
    }
}
