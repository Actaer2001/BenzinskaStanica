using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class Automobil
    {
        public int Id { get; set; }
        public int KapacitetRezervoara { get; set; }
        public double TrGorivo { get; set; }

        public Automobil()
        {
            PostaviRezervoar();
        }

        private void PostaviRezervoar()
        {
            var r = new Random();
            int procenat = r.Next(10, 30);
            TrGorivo = (double)procenat / 100;
        }
    }
}
