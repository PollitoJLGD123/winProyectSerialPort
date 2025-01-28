using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winTwoPlays
{
    public partial class frmSend : Form
    {
        claseSendRecive conexion;

        delegate void hacerMetodoSecundario(string mensaje);

        delegate void porcentajeEnvio(float cantidad, float bytes_actuales, float total);

        delegate void avisarImagen(string ruta);

        delegate void porcentajeRecibir(float cantidad, float bytes_actuales, float total);

        hacerMetodoSecundario delegadoMetodo;
        porcentajeEnvio delegadoPorcentaje;

        avisarImagen delegadoLlegoImagen;

        porcentajeRecibir delegadoPorcentajeRecibir;

        String rutaArchivo;

        public frmSend()
        {
            InitializeComponent();
        }

        public frmSend(string name,claseSendRecive conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            lblTitulo.Text += $" {name}";

            conexion.LlegoMensaje += new claseSendRecive.HandlerTxRx(llego_Mensaje);
            delegadoMetodo = new hacerMetodoSecundario(MostrandoMensaje);

            conexion.PorcentajeImagen += new claseSendRecive.DelegadoPorcentaje(porcentaje_actual);
            delegadoPorcentaje = new porcentajeEnvio(llenarBarra);

            conexion.AvisarImagen += new claseSendRecive.DelegadoAvisarArchivo(ruta_archivo_enviado);
            delegadoLlegoImagen = new avisarImagen(llenarRutaArchivoLlego);

            conexion.PorcentajeImagenRecibir += new claseSendRecive.DelegadoPorcentajeRecibir(porcentaje_recibir);
            delegadoPorcentajeRecibir = new porcentajeRecibir(llenarBarraRecibir);

        }

        private void porcentaje_recibir(object o, float cantidad, float bytes_actuales, float total)
        {
            Invoke(delegadoPorcentajeRecibir, cantidad, bytes_actuales, total);
        }

        private void llenarBarraRecibir(float cantidad, float bytes_actuales, float total)
        {
            barraRecibir.Value = (int)Math.Ceiling(cantidad);
            lblBytesConstruccion.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";
            if (bytes_actuales < total)
            {
                checkRecibir.Checked = false;
                checkRecibir.ForeColor = Color.Red;
            }
        }

        private void ruta_archivo_enviado(object o, string ruta)
        {
            Invoke(delegadoLlegoImagen, ruta);
        }

        private void llenarRutaArchivoLlego(string ruta)
        {
            txtRutaEnviada.Text = $"\n Llego un archivo exitosamente: {ruta}";
            checkRecibir.Checked = true;
            checkRecibir.ForeColor = Color.Green;
            MessageBox.Show($"Llego un archivo exitosamente: {ruta}");
        }

        private void porcentaje_actual(object o, float cantidad, float bytes_actuales, float total)
        {
            Invoke(delegadoPorcentaje, cantidad, bytes_actuales, total);
        }

        private void llenarBarra(float cantidad, float bytes_actuales, float total)
        {
            barraProgreso.Value = (int) Math.Ceiling(cantidad);
            lblBytesEnvio.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

            if(bytes_actuales == total)
            {
                checkEnviado.Checked = true;
                checkEnviado.ForeColor = Color.Green;
            }
        }

        private void llego_Mensaje(object o, string mm)
        {
            Invoke(delegadoMetodo, mm);
        }

        private void MostrandoMensaje(string texto)
        {
            string parte = conexion.puerto.PortName == "COM1" ? "COM 2" : "COM 1";
            txtConversacion.Text += $"\n {parte}: {texto}";
        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMensaje.Text.Length <= 0 || txtMensaje.Equals(""))
                {
                    MessageBox.Show("Ingresa texto válido");
                }
                else
                {
                    string texto = txtMensaje.Text.Trim();
                    conexion.enviarMensaje(texto);
                    string parte = conexion.puerto.PortName == "COM1" ? "COM 1" : "COM 2"; 
                    txtConversacion.Text += $"\n {parte}: {texto}";
                    txtMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {

            try
            {
                fileDialog.Filter = "Todos los archivos (*.*)|*.*"; 
                fileDialog.Title = "Seleccionar un archivo";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = fileDialog.FileName;

                    txtRuta.Text = "\n" + rutaArchivo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConstruir_Click(object sender, EventArgs e)
        {

        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {
            int lenghtText = txtMensaje.TextLength;
            lblLenght.Text = string.Format("{0:00}", lenghtText);
        }

        private void txtMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMensaje.Text.Length < 0 || txtMensaje.Text.Equals(""))
                {
                    MessageBox.Show("Ingresa texto válido");
                }
                else
                {
                    e.SuppressKeyPress = true;
                    string texto = txtMensaje.Text.Trim();
                    conexion.enviarMensaje(texto);
                    string parte = conexion.puerto.PortName == "COM1" ? "COM 1" : "COM 2";
                    txtConversacion.Text += $"\n {parte}: {texto}";
                    txtMensaje.Text = "";
                }
            }
        }

        private void btnEnviarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRuta.Text.Equals(""))
                {
                    MessageBox.Show("Elige un archivo primero");
                }
                else
                {
                    checkEnviado.Checked = false;
                    checkEnviado.ForeColor = Color.Red;
                    conexion.IniciaEnvioArchivo(rutaArchivo);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSend_Load(object sender, EventArgs e)
        {

        }
    }
}
