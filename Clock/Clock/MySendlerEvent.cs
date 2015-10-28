using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class MySendlerEvent
    {
        public  Clock Clock;
        public MySendlerEvent(string time)
        {
            string currTime = time;
            string[] Timepack = currTime.Split(':');
            
            Clock = new Clock(Convert.ToInt32(Timepack[0]), Convert.ToInt32(Timepack[1]), Convert.ToInt32(Timepack[2]));
            
        }
    }
}
