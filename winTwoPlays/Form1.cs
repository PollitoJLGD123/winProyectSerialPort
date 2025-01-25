using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace winTwoPlays
{
    public partial class Form1 : Form
    {
        claseSendRecive conexion;
        claseSendRecive conexion2;
        frmSend accion1;
        frmSend accion2;
        delegate void hacerMetodoSecundario(string mensaje);
        hacerMetodoSecundario delegadoMetodo;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            comboPort.Items.Clear();
            comboPort.Items.AddRange(puertos);
            comboPort.SelectedIndex = 0;
            comboDataBits.SelectedIndex = 0;
            comboParityBits.SelectedIndex = 0;
            comboBaud.SelectedIndex = 0;
            comboStopBits.SelectedIndex = 0;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarImagen_Click(object sender, EventArgs e)
        {

            try
            {
                string com_port = comboPort.Text;
                int baud_rate = Convert.ToInt32(comboBaud.Text);
                int data_bits = Convert.ToInt32(comboDataBits.Text);
                StopBits stop_bits = (StopBits)Enum.Parse(typeof(StopBits), comboStopBits.Text);
                Parity parity_bits = (Parity)Enum.Parse(typeof(Parity), comboParityBits.Text);

                if (com_port.Equals("COM1"))
                {
                    conexion = new claseSendRecive();
                    conexion.Inicializar(com_port, baud_rate, data_bits, stop_bits, parity_bits);
                    barraProgreso1.Value = 100;
                    lblEstado1.Text = "ON";
                    lblEstado1.ForeColor = Color.Green;
                    checkConectado1.Checked = true;
                }
                else
                {
                    conexion2 = new claseSendRecive();
                    conexion2.Inicializar(com_port, baud_rate, data_bits, stop_bits, parity_bits);
                    barraProgreso2.Value = 100;
                    lblEstado2.Text = "ON";
                    lblEstado2.ForeColor = Color.Green;
                    checkConectado2.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnConstruir_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (accion1.Visible == true)
            {
                MessageBox.Show("El Puerto 1 Esta En Uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conexion.EstaAbierto())
                {
                    conexion.cerrarPuerto();
                    barraProgreso1.Value = 0;
                    lblEstado1.Text = "OFF";
                    lblEstado1.ForeColor = Color.Red;
                    checkConectado1.Checked = false;
                }
                else
                {
                    MessageBox.Show("El Puerto 1 No ha Sido Abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.EstaAbierto())
            {
                accion1 = new frmSend("COM 1",conexion);
                accion1.Visible = true;
            }
            else
            {
                MessageBox.Show("El Puerto 1 No ha Sido abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {

            if (accion2.Visible == true)
            {
                MessageBox.Show("El Puerto 2 Esta En Uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conexion2.EstaAbierto())
                {
                    conexion2.cerrarPuerto();
                    barraProgreso2.Value = 0;
                    lblEstado2.Text = "OFF";
                    lblEstado2.ForeColor = Color.Red;
                    checkConectado2.Checked = false;
                }
                else
                {
                    MessageBox.Show("El Puerto 2 No ha Sido Abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIngresar2_Click(object sender, EventArgs e)
        {
            if (conexion2.EstaAbierto())
            {
                accion2 = new frmSend("COM 2",conexion2);
                accion2.Visible = true;
            }
            else
            {
                MessageBox.Show("El Puerto 2 No ha Sido abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
