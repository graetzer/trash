using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace ConsoleApplication1
{
    class Program
    {
        static SerialPort port = new SerialPort();

        static void Main(string[] args)
        {
            port.BaudRate = 115200;
            port.DataBits = 8;
            port.StopBits = StopBits.One;

            for (int i = 1; i < 10; i++)
            {
                try
                {
                    port.PortName = "COM" + i.ToString();
                    port.Open();
                }
                catch { }
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            }
            if (!port.IsOpen)
                Console.WriteLine("PORT anschliessen");
            while (port.IsOpen) { }

        }

        static int i = 0;
        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(i%2 == 0)
                Console.Write(Convert.ToString(port.ReadByte(), 2));
            else
                Console.WriteLine(Convert.ToString(port.ReadByte(), 2));
            i++;
        }
    }
}
