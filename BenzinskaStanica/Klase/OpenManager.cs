using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinskaStanica.Klase
{
    public class OpenManager
    {
        public delegate void OpenHandler(object sender);

        public static event OpenHandler? OnOpen;

        public static void Open(object sender)
        {
            OnOpen?.Invoke(sender);
        }
    }
}
