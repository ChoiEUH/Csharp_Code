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


            serialPort.DataReceived += SerialPort_DataReceived;

      

            serialPort.Open();
          
            if(radioButton2.Checked)
            {
                serialPort.Close();
         
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

            }
        }

    }
}
