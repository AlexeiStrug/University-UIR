using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        
        }

       #region Fields

        Clock MyClock;

        #endregion Fields

       #region Methods
        //Перевод из градусов в радианы;
        private double ToRadians(double grad)
        {
            return (grad * Math.PI) / 180;
        }

        #endregion Methods

       #region Events handlers

        private void GetInfo(object sender,MySendlerEvent e)
        {
            MyClock = e.Clock;
            timer1.Start();
        }








        //Обработчик события загрузки формы;
        private void Form1_Load(object sender, EventArgs e)
        {



            string currTime = DateTime.Now.ToString("HH:mm:ss");
            string[] Timepack = currTime.Split(':');

            MyClock = new Clock(Convert.ToInt32(Timepack[0]), Convert.ToInt32(Timepack[1]), Convert.ToInt32(Timepack[2]));
            timer1.Start();


        }

        //Обработчик отрисовки( в нашем случае стрелок и некоторых элементов циферблата);
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pensec = new Pen(Color.Black,1);
            Pen penmin = new Pen(Color.Black, 3);
            Pen penhour = new Pen(Color.Black, 5);
           
            double xsec = Math.Cos(ToRadians(MyClock.anglesec)) * 125;
            double ysec = Math.Sin(ToRadians(MyClock.anglesec)) * 125;
            double xmin = Math.Cos(ToRadians(MyClock.anglemin)) * 125;
            double ymin = Math.Sin(ToRadians(MyClock.anglemin)) * 125;
            double xhour = Math.Cos(ToRadians(MyClock.anglehour)) * 60;
            double yhour = Math.Sin(ToRadians(MyClock.anglehour)) * 60;
           

            
            e.Graphics.FillEllipse(Brushes.Black, 120, 120, 10, 10);      
            e.Graphics.DrawLine(pensec, 125, 125, Convert.ToInt32(xsec) + 125, Convert.ToInt32(ysec) + 125);
            
            e.Graphics.DrawLine(penmin, 125, 125, Convert.ToInt32(xmin) + 125, Convert.ToInt32(ymin) + 125);
            e.Graphics.DrawLine(penhour, 125, 125, Convert.ToInt32(xhour) + 125, Convert.ToInt32(yhour) + 125);
            

        }

        //Обработчик события таймера "клик" (как часть алгоритма перестановки стрелок);
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            MyClock.timercount++;
            MyClock.anglesec+=6;
            if (MyClock.timercount != 0 && MyClock.timercount % 60 == 0)
            {
                MyClock.anglemin += 6;
            }
            if (MyClock.timercount != 0 && MyClock.timercount % 3600 == 0)
            {
                MyClock.anglehour += 30;
            }
        }

        
       

        
         #endregion Events handlers

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            ModelTime form = new ModelTime();
            form.SetNewTime_Event += new ModelTime.SetModelTime(GetInfo);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            string currTime = DateTime.Now.ToString("HH:mm:ss");
            string[] Timepack = currTime.Split(':');

            MyClock = new Clock(Convert.ToInt32(Timepack[0]), Convert.ToInt32(Timepack[1]), Convert.ToInt32(Timepack[2]));
            timer1.Start();
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           MoveForm(e);

        }

        private void button2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           MoveForm(e);
            
        }
        //Обработка события нажатия клавиш для изменения координат расположения формы на экране монитора;
        public void MoveForm(PreviewKeyDownEventArgs e)
        {
            int x = Convert.ToInt32(this.Location.X.ToString());
            int y = Convert.ToInt32(this.Location.Y.ToString());




            if (e.KeyCode == Keys.Up)
            {
                this.Location = new Point(x, y - 10);
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.Location = new Point(x, y + 10);
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.Location = new Point(x + 10, y);
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.Location = new Point(x - 10, y);
            }
        }

        
    }
}
