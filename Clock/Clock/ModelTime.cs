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
    public partial class ModelTime : Form
    {
        public delegate void SetModelTime(object sender, MySendlerEvent e);
        public event SetModelTime SetNewTime_Event;

        public string sendtime; 
        public ModelTime()
        {
            InitializeComponent();
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            sendtime = timePicker.Value.Hour.ToString() + ':' + timePicker.Value.Minute.ToString() + ':' + timePicker.Value.Second.ToString();
            MySendlerEvent args = new MySendlerEvent(sendtime);

            SetNewTime_Event(this, args);
            this.Close();
        }

       

        private void ModelTime_Load(object sender, EventArgs e)
        {

        }
    }
}
