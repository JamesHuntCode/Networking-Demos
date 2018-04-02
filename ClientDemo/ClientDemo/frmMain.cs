using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace ClientDemo
{
    public partial class frmMain : Form
    {
        string serverIP = "localhost";
        int portNumber = 8080;

        public frmMain()
        {
            InitializeComponent();
        }

        public void frmMain_Load(object sender, EventArgs e)
        {

        }

        // capture data submitted by user
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtMessage.Text.Length > 0)
            {
                TcpClient client = new TcpClient(serverIP, portNumber);

                int byteCount = Encoding.ASCII.GetByteCount(this.txtMessage.Text + 1);

                byte[] sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes(this.txtMessage.Text + ";");

                NetworkStream stream = client.GetStream();

                stream.Write(sendData, 0, sendData.Length);

                stream.Close();
                client.Close();
            }
        }
    }
}
