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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

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

                conexion = new claseSendRecive();
                conexion.Inicializar(com_port, baud_rate, data_bits, stop_bits, parity_bits);

                barraProgreso.Value = 100;
                lblEstado.Text = "ON";
                lblEstado.ForeColor = Color.Green;
                checkConectado.Checked = true;

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
            if (conexion.EstaAbierto())
            {
                conexion.cerrarPuerto();
                barraProgreso.Value = 0;
                lblEstado.Text = "OFF";
                lblEstado.ForeColor = Color.Red;
                checkConectado.Checked = false;
            }
            else
            {
                MessageBox.Show("El Puerto No ha Sido abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.EstaAbierto())
            {
                frmSend accion = new frmSend(conexion);
                accion.Visible = true;
            }
            else
            {
                MessageBox.Show("El Puerto No ha Sido abierto Aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
