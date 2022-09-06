using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class CloseManager
    {
        public delegate void CloseHandler(object sender);

        public static event CloseHandler? OnClose;

        public static event CloseHandler? OnClosed;

        public static event CloseHandler? OnPumpClosed;

        public static void Close(object sender)
        {
            OnClose?.Invoke(sender);
        }
        public static void PumpClosed(object sender)
        {
            OnPumpClosed?.Invoke(sender);
        }
        public static void Closed(object sender)
        {
            OnClosed?.Invoke(sender);
        }
    }
}
