using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace PoolLevelMonitor
{
    public partial class PoolLevel : Form
    {
        delegate void SetTextCallback(string text);

        delegate void SetErrorCallback(string text);

        delegate void MeasureLevelCallback( );

        private static System.Timers.Timer aTimer;
        const string FILE_PATH = @"/home/pi/DistanceSensor/";
        const string FILE_NAME = @"PoolLog.txt";
        public string Version = "2.0";
        const int TRIAL_SIZE = 200;
        int readingCount = 0;
        public int timerLength = 20;
        public int rtbLineCount = 0;
        public int rtbRawCount = 0;
        public double sum = 0, ave = 0, baseLevel = 0.0, baseChange = -10.0;
       // decimal[] rawData = new decimal[TRIAL_SIZE];
        double[] rawData = new double[TRIAL_SIZE];
    
        public PoolLevel()
        {
            InitializeComponent();
            lbl_Version.Text = "Version " + Version;
            SetTimer();
        }
        public void MeasureLevel()
        {
            
            //sets the number of data points taken per entry
           // rtb_RawData.Clear();
            
            try
            {
                SetRawText("");
                string stringToWrite;
                int tries =  Convert.ToInt32(tb_ReadingsPerCycle.Text);
                SerialPort ardP = new SerialPort("/dev/ttyACM0", 9600, Parity.None, 8);   //serial port for pi             
               // SerialPort ardP = new SerialPort("COM3", 9600, Parity.None, 8);           //serial port on pc
               // SerialPort ardP = new SerialPort("COM4", 9600, Parity.None, 8);           //serial port on pc

                //decimal[] rawData = new decimal[TRIAL_SIZE];
                
                ardP.Open(); //open serial port
                Thread.Sleep(500); //delay 500 millis
                //if (2 == 2) return;
                for (int i = 0; i < tries; i++)
                {                    
                    ardP.WriteLine("");                 //sends command to arduino to take reading
                    Thread.Sleep(200);                  //delay to allow reading to complete
                    rawData[i] = ReadSerial(ardP);      //calls read function and returns distance
                    
                    
                   // rtb_RawData.AppendText(i.ToString() + "  " + rawData[i].ToString("F3") + "  " + (rawData[i]/2.54).ToString("F3") + "\n");
                    SetRawText(i.ToString() + "  " + rawData[i].ToString("F3") + "  " + (rawData[i] / 2.54).ToString("F3") + "\n");
                    if (rawData[i] == 0)                //if pi reads a distance of 0, data is thrown out
                        i--;
                }
                ardP.Close();                           //serial port closed
               // if (2 == 2) return;
                sum = 0.0;
                for (int i = 0; i < tries; i++)
                {
                    sum = sum + rawData[i];
                }
                ave = sum/tries;
                if (baseLevel == -10.0)
                {
                    tb_Base.Text = ave.ToString();
                }
                baseLevel = Convert.ToDouble(tb_Base.Text);

                baseChange = (ave - baseLevel)/2.54;
               // tb_LevelChange.Text = baseChange.ToString("F3");

                // WriteToFile(ave.ToString("F2"));      //average of of data points rounded to mm written to file                       
                stringToWrite = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ", " + ave.ToString("F3") + "cm,  " + (ave / 2.54).ToString("F3") + "in,  " + baseChange.ToString("F3") + " chg  " ;
                WriteToFile(stringToWrite);
                readingCount++;
                if (readingCount > 20)
                {
                    readingCount = 0;
                   // rtb_Readings.Clear();
                    SetRawText("");
                }
                SetText(stringToWrite + "\n");
               // rtb_Readings.AppendText(stringToWrite + "\n");
                // ardP.Close();                           //serial port closed
            }
            catch (Exception ex)
            {
                Console.WriteLine("From Measure Level " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message);
                SetErrorText("Measure Level error " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message + "\n");
                              
            }

        }
        //*******************************************************************************************

        private void SetRawText(string text)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {

                if (this.rtb_RawData.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetRawText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    if (rtbRawCount > 500 || text == "")
                    {
                        rtb_RawData.ResetText();
                        rtbRawCount = 0;
                        string dateString = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        tb_ErrorList.AppendText(dateString + "  Reset rtb_RawData \n");
                    }
                    this.rtb_RawData.AppendText(text);
                    rtbRawCount++;

                }


            }
            catch (Exception ex)
            {
                SetErrorText("SetRawText error " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message + "\n");
               
            }

        }
        private void SetText(string text)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {

                if (this.rtb_Readings.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    if (rtbLineCount > 500 || text == "" )
                    {
                        rtb_Readings.ResetText();
                        rtbLineCount = 0;
                        string dateString = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        tb_ErrorList.AppendText(dateString + "  Reset rtb_Readings \n");
                    }
                    this.rtb_Readings.AppendText(text);
                    rtbLineCount++;
                    tb_LevelChange.Text = baseChange.ToString("F3");
                }


            }
            catch (Exception ex)
            {
                //SetErrorText("SetText error " + ex.Message + "\n");
                SetErrorText("SetText error " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message + "\n");
                
            }

        }
        //*******************************************************************************************
        private void SetErrorText(string text)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {

                if (this.tb_ErrorList.InvokeRequired)
                {
                    SetErrorCallback d = new SetErrorCallback(SetErrorText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.tb_ErrorList.AppendText(text);
                }


            }
            catch (Exception ex)
            {
                // If we get an error here put it in the datalist
               // SetText("SetText error " + ex.Message + "\n");
                Console.WriteLine("From SetErrorText " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message);
            }

        }
        private void SetTimer()
        {
            // Create a timer 
            // timerLength is in seconds. Timer expects milliseconds
            aTimer = new System.Timers.Timer(timerLength * 1000);
            // Hook up the Elapsed event for the timer. 

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timerLength = Convert.ToInt32(tb_Period.Text);
            aTimer.Interval = timerLength * 1000;
            MeasureLevel();
        }
        private  double ReadSerial(SerialPort sp)
        {
            string serialDat = "";
            try
            {
                
                byte[] buf = new byte[sp.BytesToRead];

                if (sp.BytesToRead == 0)        //if 0 bytes to read, serial data is not ready yet
                {
                    Thread.Sleep(100);
                    return 0;
                }
                sp.Read(buf, 0, buf.Length);    //reads serial from arduino           

                foreach (Byte b in buf)         //constructs the distance string one byte at a time
                {
                    if (Convert.ToChar(b) != '\n')       //checks for newline character and removes it from end of string
                        serialDat += Convert.ToChar(b);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("From ReadSerial " + ex.Message);
                SetErrorText("ReadSerial error " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "  " + ex.Message + "\n");
                //Console.ReadLine();
                serialDat = "";
            }
            return Convert.ToDouble(serialDat);    //converts distance string to decimal and returns value
        }

        private static void WriteToFile(string distance)
        {
            string fullPath = FILE_PATH + FILE_NAME;
            string stringToWrite;
           // stringToWrite = distance + " cm " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            stringToWrite = distance;
            
            using (StreamWriter sw = new StreamWriter(fullPath, append: true))   //create streamwrite
            {
                
                sw.WriteLine(stringToWrite);             //write to text file
                
            }
            return;
        }

        private void btn_Measure_Click(object sender, System.EventArgs e)
        {
            MeasureLevel();
        }

        private void btn_ResetBase_Click(object sender, EventArgs e)
        {
            tb_Base.Text = ave.ToString();
        }        

    }
}
