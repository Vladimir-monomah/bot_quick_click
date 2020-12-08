using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BotClicker
{
    public partial class Form1 : Form
    {
        int clicks = 0;


        public Form1()
        {
            InitializeComponent();
            track_count_Scroll(null, null);
            track_time_Scroll(null, null);
        }

        private void track_count_Scroll(object sender, EventArgs e)
        {
            label_show_count.Text = track_count.Value.ToString() + "кликов";
        }

        private void track_time_Scroll(object sender, EventArgs e)
        {
            label_show_time.Text = track_time.Value.ToString() + "мc";
        }

        

        private void button_start_Click(object sender, EventArgs e)
        {
            start_clicker();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            make_click();
        }

        void start_clicker()
        {
            clicks = track_count.Value;
            button_start.Enabled = false;
            timer.Interval = track_time.Value;
            timer.Enabled = true;
        }

        void make_click()
        {
            clicks--;
            DoMouseClick();
            if (clicks == 0)
                stop_clicker();
        }

        void stop_clicker()
        {
            timer.Enabled = false;
            button_start.Enabled = true;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
    }
}
