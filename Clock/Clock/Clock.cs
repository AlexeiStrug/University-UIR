using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
       #region Fields

       public double anglesec; //Угол сек. стрелки
       public double anglemin; //Угол мин. стрелки
       public double anglehour; //Угол час. стрелки
       public int timercount; //Счетчик секунд;
       

        #endregion Fields

       #region Constructor
       public Clock(int hour, int min, int sec)
       {
           
          
          
           //Начальные положения стрелок;
           anglehour = -90 + hour * 30;
           anglemin = -90 + min * 6;
           anglesec = -90 + sec * 6;
           timercount = sec+min*60+hour*3600;
       }

       #endregion Constructor
    }
}
