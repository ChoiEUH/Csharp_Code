namespace industry_iot_form
{
    using System.IO.Ports;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort();
        SerialPort PLCPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            serialPort.PortName = "COM7";
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;

               PLCPort.PortName = "COM3";
               PLCPort.BaudRate = 9600;
               PLCPort.Parity = Parity.None;
               PLCPort.DataBits = 8;
               PLCPort.StopBits = StopBits.One;

             


            serialPort.DataReceived += SerialPort_DataReceived;

      

            serialPort.Open();
              PLCPort.Open();
          
            if(radioButton2.Checked)
            {
                serialPort.Close();
                PLCPort.Close();
         
            }


        }
       



        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (radioButton1.Checked)
            {
                string data = serialPort.ReadLine();

                string time = DateTime.Now.ToString("HH:mm:ss");

                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add($"[{time}]{data}");

                }));
               if (PLCPort.IsOpen)
               {
                  PLCPort.WriteLine(data + "\r\n");
               }

            }
        }

    }
}
