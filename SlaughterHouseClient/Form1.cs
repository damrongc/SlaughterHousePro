using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SlaughterHouseClient
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.DataReceived += port_DataReceived;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            InputData = serialPort1.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }
        private void SetText(string text)
        {
            try
            {
                if (text.Length == 40)
                    textBox1.AppendText(text);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
