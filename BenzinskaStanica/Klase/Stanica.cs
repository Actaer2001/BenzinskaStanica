using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BenzinskaStanica.Klase
{
    public class Stanica : INotifyPropertyChanged, IDisposable
    {
        public List<Pumpa> Pumpe { get; set; }
        public ObservableCollection<Automobil> RedCekanja { get; set; }

        public Autoput Autoput { get; set; }

        private bool otvoreno;
        public bool Otvoreno
        {
            get { return otvoreno; }
            set {
                otvoreno = value;
                OnPropertyChanged("Otvoreno");
            }
        }

        private int pumpsClosed;
        public int PumpsClosed
        {
            get { return pumpsClosed; }
            set {
                pumpsClosed = value;
                OnPropertyChanged("PumpsClosed");
            }
        }


        private bool closeFlag;

        public bool CloseFlag
        {
            get { return closeFlag; }
            set {
                closeFlag = value;
                OnPropertyChanged("CloseFlag");
            }
        }

        private string pump1Text;

        public string Pump1Text
        {
            get { return pump1Text; }
            set {
                pump1Text = value;
                OnPropertyChanged("Pump1Text");
            }
        }

        private string pump2Text;

        public string Pump2Text
        {
            get { return pump2Text; }
            set
            {
                pump2Text = value;
                OnPropertyChanged("Pump2Text");
            }
        }

        private string pump3Text;

        public string Pump3Text
        {
            get { return pump3Text; }
            set
            {
                pump3Text = value;
                OnPropertyChanged("Pump3Text");
            }
        }

        private string pump4Text;

        public string Pump4Text
        {
            get { return pump4Text; }
            set
            {
                pump4Text = value;
                OnPropertyChanged("Pump4Text");
            }
        }

        private double pump1Width;

        public double Pump1Width
        {
            get { return pump1Width; }
            set {
                pump1Width = value;
                OnPropertyChanged(nameof(Pump1Width));
            }
        }

        private double pump2Width;

        public double Pump2Width
        {
            get { return pump2Width; }
            set
            {
                pump2Width = value;
                OnPropertyChanged(nameof(Pump2Width));
            }
        }

        private double pump3Width;

        public double Pump3Width
        {
            get { return pump3Width; }
            set
            {
                pump3Width = value;
                OnPropertyChanged(nameof(Pump3Width));
            }
        }

        private double pump4Width;

        public double Pump4Width
        {
            get { return pump4Width; }
            set
            {
                pump4Width = value;
                OnPropertyChanged(nameof(Pump4Width));
            }
        }



        public MainWindow MainWindow { get; set; }

        public OpenCommand OpenCommand { get; set; }
        public CloseCommand CloseCommand { get; set; }
        public Stanica()
        {
            OpenCommand = new OpenCommand(this);
            CloseCommand = new CloseCommand(this);

            Pump1Width = Pump2Width = Pump3Width = Pump4Width = 0;
            Pump1Text = Pump2Text = Pump3Text = Pump4Text = string.Empty;
            Pumpe = new List<Pumpa>();
            RedCekanja = new ObservableCollection<Automobil>();
            CloseFlag = false;
            Otvoreno = true;
            Autoput = new Autoput(this);    
            for (int i = 0; i < 4; i++)
            {
                Pumpe.Add(new Pumpa(this)
                {
                    Index = i + 1,
                });
            }
            CloseManager.OnClose += CloseManager_OnClose;
            CloseManager.OnPumpClosed += CloseManager_OnPumpClosed;
            CloseManager.OnClosed += CloseManager_OnClosed;
            OpenManager.OnOpen += OpenManager_OnOpen;
        }

        private void OpenManager_OnOpen(object sender)
        {
            Otvoreno = true;
            for (int i = 0; i < 4; i++)
            {
                Pumpe.Add(new Pumpa(this)
                {
                    Index = i + 1,
                });
            }
            Autoput = new Autoput(this);
        }

        private void CloseManager_OnClosed(object sender)
        {
            PumpsClosed = 0;
            RedCekanja.Clear();
            Pumpe = new List<Pumpa>(4);
            Pump1Width = Pump2Width = Pump3Width = Pump4Width = 0;
            CloseFlag = false;
            Otvoreno = false;
            Pump1Text = Pump2Text = Pump3Text = Pump4Text = string.Empty;
        }

        private void CloseManager_OnPumpClosed(object sender)
        {
            PumpsClosed++;
            if (PumpsClosed == 4)
            {
                CloseManager.Closed(this);
            }
        }

        private void CloseManager_OnClose(object sender)
        {
            CloseFlag = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }

        public void Dispose()
        {
            CloseManager.OnClose -= CloseManager_OnClose;
            CloseManager.OnPumpClosed -= CloseManager_OnPumpClosed;
            CloseManager.OnClosed -= CloseManager_OnClosed;
        }
    }
}
