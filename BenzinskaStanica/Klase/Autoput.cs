using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class Autoput
    {
        public Stanica Stanica { get; set; }

        public Autoput(Stanica stanica)
        {
            Stanica = stanica;
            SledeciId = 1;
            DodajAuta();
        }

        public int SledeciId { get; set; }

        public async void DodajAuta()
        {
            var r = new Random();
            var auto = new Automobil()
            {
                Id = SledeciId,
                KapacitetRezervoara = 50
            };
            SledeciId++;
            Stanica.RedCekanja.Add(auto);
            await Task.Delay(r.Next(500, 1000));
            if (Stanica.CloseFlag)
                return;
            if (Stanica.RedCekanja.Count < 20)
                DodajAuta();
            else
            {
                Provera();
                return;
            }
        }

        private async void Provera()
        {
            if (Stanica.RedCekanja.Count < 20)
                DodajAuta();
            else
            {
                await Task.Delay(100);
                Provera();
            }
        }
    }
}
