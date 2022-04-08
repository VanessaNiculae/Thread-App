using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public uint handle1;
        public uint handle2;
        public uint handle3;

        WinApiClass.LPTHREAD_START_ROUTINE thread1;
        WinApiClass.LPTHREAD_START_ROUTINE thread2;
        WinApiClass.LPTHREAD_START_ROUTINE thread3;

        public uint firstThread(IntPtr a)
        {
            GCHandle h = (GCHandle)a;
            ProgressBar obj = h.Target as ProgressBar;

            for (int i = obj.Minimum; i < obj.Maximum; i++)
            {
                obj.PerformStep();
            }
            return 0;
        }
         

              
        /*
        public uint secondThread(IntPtr y)
        {
            for (int j = progressBar2.Minimum; j < progressBar2.Maximum; j++)
            {
                progressBar2.PerformStep();
            }
            return 0;
        }
        public uint thirdThread(IntPtr z)
        {
            for (int k = progressBar3.Minimum; k < progressBar3.Maximum; k++)
            {
                progressBar3.PerformStep();
            }
            return 0;
        }*/
        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            GCHandle h1 = GCHandle.Alloc(progressBar1);
            IntPtr objRef1 = GCHandle.ToIntPtr(h1);

            GCHandle h2 = GCHandle.Alloc(progressBar2);
            IntPtr objRef2 = GCHandle.ToIntPtr(h2);

            GCHandle h3 = GCHandle.Alloc(progressBar3);
            IntPtr objRef3 = GCHandle.ToIntPtr(h3);

            thread1 = new WinApiClass.LPTHREAD_START_ROUTINE(firstThread);
            uint id_thread1;

            handle1 = WinApiClass.CreateThread(IntPtr.Zero, 0, thread1, objRef1, (WinApiClass.ThreadState)0x00000004, out id_thread1);
            thread2 = new WinApiClass.LPTHREAD_START_ROUTINE(firstThread);
            uint id_thread2;

            handle2 = WinApiClass.CreateThread(IntPtr.Zero, 0, thread2, objRef2, (WinApiClass.ThreadState)0x00000004, out id_thread2);
            thread3 = new WinApiClass.LPTHREAD_START_ROUTINE(firstThread);
            uint id_thread3;

            handle3 = WinApiClass.CreateThread(IntPtr.Zero, 0, thread3, objRef3, (WinApiClass.ThreadState)0x00000004, out id_thread3);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Suspend")
            {
                WinApiClass.SuspendThread((IntPtr)handle1);
                button1.Text = "Resume";
            }
            else if(button1.Text == "Resume")
            {
                WinApiClass.ResumeThread((IntPtr)handle1);
                button1.Text = "Suspend";
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Suspend")
            {
                WinApiClass.SuspendThread((IntPtr)handle2);
                button3.Text = "Resume";
            }
            else if (button3.Text == "Resume")
            {
                WinApiClass.ResumeThread((IntPtr)handle2);
                button3.Text = "Suspend";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Suspend")
            {
                WinApiClass.SuspendThread((IntPtr)handle3);
                button2.Text = "Resume";
            }
            else if (button2.Text == "Resume")
            {
                WinApiClass.ResumeThread((IntPtr)handle3);
                button2.Text = "Suspend";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WinApiClass.TerminateThread(handle1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WinApiClass.TerminateThread(handle2, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WinApiClass.TerminateThread(handle3, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                WinApiClass.FILETIME CreationTime, ExitTime, KernelTime, UserTime;
                WinApiClass.GetThreadTimes((IntPtr)handle1, out CreationTime, out ExitTime, out KernelTime, out UserTime);
                WinApiClass.SYSTEMTIME x, y, z, w;
                WinApiClass.FileTimeToSystemTime(ref CreationTime, out x);
                WinApiClass.FileTimeToSystemTime(ref ExitTime, out y);
                WinApiClass.FileTimeToSystemTime(ref KernelTime, out z);
                WinApiClass.FileTimeToSystemTime(ref UserTime, out w);
                richTextBox1.Text = richTextBox1.Text + "Creation time: " + x.Day + "/" + x.Month + "/" + x.Year + " " + x.Hour + ":" + x.Minute + ":" + x.Second + "\n";
                richTextBox1.Text = richTextBox1.Text + "Exit Time: " + y.Day + "/" + y.Month + "/" + y.Year + " " + y.Hour + ":" + y.Minute + ":" + y.Second + "\n";
                richTextBox1.Text = richTextBox1.Text + "Kernel Time: " + z.Milliseconds + "\n";
                richTextBox1.Text = richTextBox1.Text + "User Time: " + w.Milliseconds;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
                WinApiClass.FILETIME CreationTime, ExitTime, KernelTime, UserTime;
                WinApiClass.GetThreadTimes((IntPtr)handle1, out CreationTime, out ExitTime, out KernelTime, out UserTime);
                WinApiClass.SYSTEMTIME x, y, z, w;
                WinApiClass.FileTimeToSystemTime(ref CreationTime, out x);
                WinApiClass.FileTimeToSystemTime(ref ExitTime, out y);
                WinApiClass.FileTimeToSystemTime(ref KernelTime, out z);
                WinApiClass.FileTimeToSystemTime(ref UserTime, out w);
                richTextBox4.Text = richTextBox4.Text + "Creation time: " + x.Day + "/" + x.Month + "/" + x.Year + " " + x.Hour + ":" + x.Minute + ":" + x.Second + "\n";
                richTextBox4.Text = richTextBox4.Text + "Exit Time: " + y.Day + "/" + y.Month + "/" + y.Year + " " + y.Hour + ":" + y.Minute + ":" + y.Second + "\n";
                richTextBox4.Text = richTextBox4.Text + "Kernel Time: " + z.Milliseconds + "\n";
                richTextBox4.Text = richTextBox4.Text + "User Time: " + w.Milliseconds;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
                WinApiClass.FILETIME CreationTime, ExitTime, KernelTime, UserTime;
                WinApiClass.GetThreadTimes((IntPtr)handle3, out CreationTime, out ExitTime, out KernelTime, out UserTime);
                WinApiClass.SYSTEMTIME x, y, z, w;
                WinApiClass.FileTimeToSystemTime(ref CreationTime, out x);
                WinApiClass.FileTimeToSystemTime(ref ExitTime, out y);
                WinApiClass.FileTimeToSystemTime(ref KernelTime, out z);
                WinApiClass.FileTimeToSystemTime(ref UserTime, out w);
                richTextBox5.Text = richTextBox5.Text + "Creation time: " + x.Day + "/" + x.Month + "/" + x.Year + " " + x.Hour + ":" + x.Minute + ":" + x.Second + "\n";
                richTextBox5.Text = richTextBox5.Text + "Exit Time: " + y.Day + "/" + y.Month + "/" + y.Year + " " + y.Hour + ":" + y.Minute + ":" + y.Second + "\n";
                richTextBox5.Text = richTextBox5.Text + "Kernel Time: " + z.Milliseconds + "\n";
                richTextBox5.Text = richTextBox5.Text + "User Time: " + w.Milliseconds;
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
