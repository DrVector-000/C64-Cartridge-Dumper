using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C64CartridgeDumper
{
    public partial class Form1 : Form
    {

        #region Variabili (accesso privato)

        private SerialPort _serialPort;

        #endregion

        #region Costruttore

        public Form1()
        {
            InitializeComponent();

            // Inizializza porta seriale
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 500000; //115200;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.PortName = "COM5";
            _serialPort.DtrEnable = false;

            // Enumerazione porte seriali disponibili
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cBSerialPorts.Items.Add(port);
            }
            if (cBSerialPorts.Items.Count > 0)
            {
                cBSerialPorts.SelectedIndex = 0;
                bConnetti.Enabled = true;
            }

            // Display the timer frequency and resolution.
            if (Stopwatch.IsHighResolution)
            {
                tBInfo.AppendText("Timer di sistema ad alta risoluzione disponibile." + "\r\n");
            }
            else
            {
                tBInfo.AppendText("Timer di sistema ad alta risoluzione non disponibile." + "\r\n");
            }
        }

        #endregion

        #region Event handler Form

        private void bConnetti_Click(object sender, EventArgs e)
        {
            if (Connetti())
            {
                Thread.Sleep(5000);

                String firmw = LeggiFirmware();
                if (firmw != "")
                {
                    tBInfo.Text = "";
                    tBInfo.AppendText("Firmware version " + firmw + "\r\n");
                    tBInfo.AppendText("---------------------------------------------\r\n");
                    tBInfo.AppendText("\r\n");

                    bDisconnetti.Enabled = true;
                    bConnetti.Enabled = false;
                    cBSerialPorts.Enabled = false;
                    bGetInfo.Enabled = true;
                    bDump.Enabled = true;
                    //bRAMDump.Enabled = true;
                    //bRAMWrite.Enabled = true;
                    toolStripStatusLabel1.Text = "Dispositivo connesso";
                }
                else
                {
                    Disconnetti();
                }
            }
        }

        private void cBSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _serialPort.PortName = cBSerialPorts.SelectedItem.ToString();
            bConnetti.Enabled = true;
        }

        private void bDisconnetti_Click(object sender, EventArgs e)
        {
            if (Disconnetti())
            {
                bDisconnetti.Enabled = false;
                bConnetti.Enabled = true;
                cBSerialPorts.Enabled = true;
                bGetInfo.Enabled = false;
                bDump.Enabled = false;
                //bRAMDump.Enabled = false;
                //bRAMWrite.Enabled = false;
                toolStripStatusLabel1.Text = "Dispositivo non connesso";
            }
        }

        private void bGetInfo_Click(object sender, EventArgs e)
        {
            string sgame = GetCommandString("GETGAME");
            string sexrom = GetCommandString("GETEXROM");

            tBInfo.AppendText("GAME: " + sgame + "\r\n");
            tBInfo.AppendText("EXROM: " + sexrom + "\r\n");
            tBInfo.AppendText("\r\n");
        }

        private void bDump_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string path = "";
            string name = "";
            int nbanks = 1;
            try
            {
                FDumping fdumping = new FDumping();
                if (fdumping.ShowDialog() == DialogResult.OK)
                {
                    name = fdumping.CRTName;
                    path = fdumping.CRTPath;
                    nbanks = fdumping.CRTBanks;

                    if ((path == "") || (name == ""))
                    {
                        tBInfo.AppendText("Errore inserimento dati ROM \r\n");
                    }

                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                }

                List<byte> datas = new List<byte>();
                progressBar1.Maximum = nbanks;
                progressBar1.Value = 0;

                tBInfo.AppendText("Inizio salvataggio ROM \r\n");
                tBInfo.AppendText(DateTime.Now.ToString("HH:mm:ss") + "\r\n");

                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();

                for (int i = 0; i < nbanks; i++)
                {
                    progressBar1.Value = i + 1;
                    DumpBank(i, datas);

                    string filename = path + @"\" + name + "_" + i.ToString("00") + ".bin";
                    using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                    {
                        byte[] buffer = datas.ToArray();
                        writer.Write(buffer, 0, buffer.Length);
                    }
                    datas.Clear();
                }

                tBInfo.AppendText("Salvataggio ROM terminato\r\n");
                tBInfo.AppendText(DateTime.Now.ToString("HH:mm:ss") + "\r\n");
                tBInfo.AppendText("\r\n");

                /*
                    saveFileDialog1.FileName = "dumping.bin";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        tBInfo.AppendText("Inizio salvataggio ROM \r\n");
                        tBInfo.AppendText(DateTime.Now.ToString("HH:mm:ss") + "\r\n");

                        _serialPort.DiscardInBuffer();
                        _serialPort.DiscardOutBuffer();

                        //for (int i = 0; i < nbanks; i++)
                        int i = 1;
                        {
                            progressBar1.Value = i + 1;
                            DumpBank(i, datas);
                        }

                        using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog1.FileName, FileMode.Create)))
                        {
                            byte[] buffer = datas.ToArray();
                            writer.Write(buffer, 0, buffer.Length);
                        }
                        //progressBar1.Value = 0;
                        tBInfo.AppendText("Salvataggio ROM terminato\r\n");
                        tBInfo.AppendText(DateTime.Now.ToString("HH:mm:ss") + "\r\n");
                        tBInfo.AppendText("\r\n");
                    }
                */
            }
            catch { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Metodi (accesso privato)

        private bool Connetti()
        {
            try
            {
                _serialPort.Open();
                return _serialPort.IsOpen;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool Disconnetti()
        {
            _serialPort.Close();
            return !_serialPort.IsOpen;
        }


        private string LeggiFirmware()
        {
            String s = "";
            try
            {
                _serialPort.Write("VERSION=?\r");

                // 5 secondi di timeout
                int ExpiredTick = Environment.TickCount + 5000;
                while (Environment.TickCount < ExpiredTick)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        s = _serialPort.ReadLine();
                        string[] split = s.Trim('\r').Split(new char[] { '=' });
                        if (split[0] == "+VERSION")
                        {
                            s = split[1];
                            break;
                        }
                    }
                }
                return s;
            }
            catch
            {
                return s;
            }
        }

        private void DumpBank(int bank, List<byte> datas)
        {
            string s = "";
            try
            {
                _serialPort.Write("DUMPROMBANK=" + bank.ToString() + "\r");

                byte[] buffer = new byte[0x2000];
                int offset = 0;
                // 60 secondi di timeout
                //int ExpiredTick = Environment.TickCount + 60000;
                while (true) //(Environment.TickCount < ExpiredTick)
                {
                    ////s = _serialPort.ReadLine();


                    int count = _serialPort.BytesToRead;
                    if (count > 0)
                    {
                        _serialPort.Read(buffer, offset, count);
                        offset += count;
                    }

                    if (offset == 0x2000)
                    {
                        datas.AddRange(buffer);
                        break;
                    }
                }
            }
            catch { }
        }

        private string GetCommandString(string cmd)
        {
            String s = "";
            try
            {
                _serialPort.Write(cmd + "=?\r");

                // 5 secondi di timeout
                int ExpiredTick = Environment.TickCount + 5000;
                while (Environment.TickCount < ExpiredTick)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        s = _serialPort.ReadLine();
                        string[] split = s.Trim('\r').Split(new char[] { '=' });
                        if (split[0] == "+" + cmd)
                        {
                            s = split[1];
                            break;
                        }
                    }
                }
                return s;
            }
            catch
            {
                return s;
            }
        }

        #endregion

    }
}
