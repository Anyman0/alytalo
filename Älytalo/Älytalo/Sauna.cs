using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Älytalo
{
   
    class Sauna
    {
        
        public bool SaunaKytkin { get; set; }
        public DispatcherTimer SaunaTimer = new DispatcherTimer();
        public DispatcherTimer SaunaOffTimer = new DispatcherTimer();
        public int saunanLämmöt;
        
        
        public Sauna()
        {
            SaunaTimer.Tick += SaunanLämpö_Tick;
            SaunaTimer.Interval = new TimeSpan(0, 0, 1);
            

            SaunaOffTimer.Tick += SaunanLämpöOff_Tick;
            SaunaOffTimer.Interval = new TimeSpan(0, 0, 1);

            
        }

        private void SaunanLämpöOff_Tick(object sender, EventArgs e)
        {
            saunanLämmöt = saunanLämmöt - 3;
            if (saunanLämmöt == 0)
            {
                SaunaOffTimer.Stop();
                
            }
        }

        public void SaunanLämpö_Tick(object sender, EventArgs e)
        {
            saunanLämmöt = saunanLämmöt + 3;
            if (saunanLämmöt == 90)
            {
                SaunaTimer.Stop();
                
            }
            
        }


        public void SaunaPäällä()
        {
            SaunaKytkin = true;            
            SaunaTimer.Start();
            SaunaOffTimer.Stop();
                
        }

        public void SaunaPoisPäältä()
        {         
                SaunaTimer.Stop();
                SaunaKytkin = false;
                SaunaOffTimer.Start();
        }

       
    }
}
