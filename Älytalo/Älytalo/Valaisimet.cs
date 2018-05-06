using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Älytalo
{
    
    class Valaisimet
    {
        
        private bool Switched { get; set; }
        public void ValoPäällä()
        {
            Switched = true;
            
        }

        public void ValoPoisPäältä()
        {
            Switched = false;
        }
        public void Hämärä()
        {
            ValoPäällä();
            

        }

        public void Puolivalot()
        {
            ValoPäällä();
        }

        public void Kirkas()
        {
            ValoPäällä();
        }
    }
}
