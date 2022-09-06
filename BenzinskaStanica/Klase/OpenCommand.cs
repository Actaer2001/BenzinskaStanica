using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BenzinskaStanica.Klase
{
    public class OpenCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Stanica Stanica { get; set; }

        public OpenCommand(Stanica stanica)
        {
            Stanica = stanica;
        }

        public bool CanExecute(object? parameter)
        {
            if (Stanica.Otvoreno || Stanica.CloseFlag)
                return false;
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenManager.Open(Stanica);
        }
    }
}
