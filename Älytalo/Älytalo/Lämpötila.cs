using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Älytalo
{
    class Lämpötila
    {
        private bool TermoKytkin { get; set; }

        public void TermostaattiOn()
        {
            TermoKytkin = true;
        }

        public void TermostaattiOff()
        {
            TermoKytkin = false;
            
        }
    }
}
