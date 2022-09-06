using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class Pumpa : INotifyPropertyChanged
    {
        public int Index { get; set; }
        public Stanica Stanica { get; set; }

        private Automobil? trAuto;
        public Automobil? TrAuto
        {
            get { return trAuto; }
            set {
                trAuto = value;
                OnPropertyChanged("TrAuto");
            }
        }


        public Pumpa(Stanica stanica)
        {
            Stanica = stanica;
            KreniTocenje();
        }

        public async void KreniTocenje()
        {
            if (Stanica?.RedCekanja.Count > 0)
            {
                var auto = Stanica.RedCekanja.FirstOrDefault();
                if (auto != null)
                {
                    TrAuto = auto;
                    switch (Index)
                    {
                        case 1:
                            Stanica.Pump1Text = TrAuto.Id.ToString();
                            break;
                        case 2:
                            Stanica.Pump2Text = TrAuto.Id.ToString();
                            break;
                        case 3:
                            Stanica.Pump3Text = TrAuto.Id.ToString();
                            break;
                        case 4:
                            Stanica.Pump4Text = TrAuto.Id.ToString();
                            break;
                    }
                    Stanica.RedCekanja.Remove(auto);
                    while (true)
                    {
                        TrAuto.TrGorivo += 0.02;
                        switch (Index)
                        {
                            case 1:
                                Stanica.Pump1Width = 400 * TrAuto.TrGorivo;
                                break;
                            case 2:
                                Stanica.Pump2Width = 400 * TrAuto.TrGorivo;
                                break;
                            case 3:
                                Stanica.Pump3Width = 400 * TrAuto.TrGorivo;
                                break;
                            case 4:
                                Stanica.Pump4Width = 400 * TrAuto.TrGorivo;
                                break;
                        }
                        if (TrAuto.TrGorivo >= 1)
                        {
                            TrAuto.TrGorivo = 100;
                            PumpingManager.Pumped(this);
                            break;
                        }
                        await Task.Delay(100);
                    }
                    if (Stanica?.CloseFlag == true)
                    {
                        CloseManager.PumpClosed(this);
                        return;
                    }
                }
                KreniTocenje();
            }
            else
            {
                Provera();
                return;
            }
        }

        private async void Provera()
        {
            if (Stanica.RedCekanja.Count > 0)
                KreniTocenje();
            else
            {
                await Task.Delay(150);
                Provera();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
