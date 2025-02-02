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

        delegate void porcentajeEnvio(float cantidad, float bytes_actuales, float total, int orden);

        delegate void avisarImagen(string ruta);

        delegate void porcentajeRecibir(float cantidad, float bytes_actuales, float total, int orden);

        delegate void avisarForm(int archivo_acabo);

        hacerMetodoSecundario delegadoMetodo;
        porcentajeEnvio delegadoPorcentaje;

        avisarImagen delegadoLlegoImagen;

        porcentajeRecibir delegadoPorcentajeRecibir;

        avisarForm delegadoForm;

        String rutaArchivo;

        Dictionary<int, Boolean> disponibles;
        //Dictionary<int, ProgressBar> objetos;


        int number = 0;
        int id = 0;

        public frmSend()
        {
            InitializeComponent();
        }

        public frmSend(string name,claseSendRecive conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            lblTitulo.Text += $" {name}";

            disponibles = new Dictionary<int, Boolean>
            {
                { 0, true},
                { 1, true},
                { 2, true},
                { 3, true},
                { 4, true},
            };

            conexion.LlegoMensaje += new claseSendRecive.HandlerTxRx(llego_Mensaje);
            delegadoMetodo = new hacerMetodoSecundario(MostrandoMensaje);

            conexion.PorcentajeImagen += new claseSendRecive.DelegadoPorcentaje(porcentaje_actual);
            delegadoPorcentaje = new porcentajeEnvio(llenarBarra);

            conexion.AvisarImagen += new claseSendRecive.DelegadoAvisarArchivo(ruta_archivo_enviado);
            delegadoLlegoImagen = new avisarImagen(llenarRutaArchivoLlego);

            conexion.PorcentajeImagenRecibir += new claseSendRecive.DelegadoPorcentajeRecibir(porcentaje_recibir);
            delegadoPorcentajeRecibir = new porcentajeRecibir(llenarBarraRecibir);

            conexion.AvisarForm1 += new claseSendRecive.DelegadoAvisarForm1(avisar_form);
            delegadoForm = new avisarForm(reducir_number);

        }

        private void avisar_form(object oo,int numero_acabo)
        {
            Invoke(delegadoForm,numero_acabo);
        }

        private void reducir_number(int numero_acabo)
        {
            Console.WriteLine("Se libro el archivo: " + numero_acabo);

            disponibles[numero_acabo] = true;
        }

        private int retornarVacio(Dictionary<int, Boolean> diccionario)
        {
            foreach (var i in diccionario.OrderBy(k => k.Key))
            {
                if (i.Value)
                {
                    return i.Key;
                }
            }
            return -1;
        }

        private void porcentaje_recibir(object o, float cantidad, float bytes_actuales, float total, int orden)
        {
            Invoke(delegadoPorcentajeRecibir, cantidad, bytes_actuales, total, orden);
        }

        private void llenarBarraRecibir(float cantidad, float bytes_actuales, float total, int orden)
        {
            if (orden == 0)
            {
                barraRecibir.Value = (int)Math.Ceiling(cantidad);
                lblBytesConstruccion.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";
                if (bytes_actuales == total)
                {
                    checkRecibir.Checked = true;
                }
                else
                {
                    checkRecibir.Checked = false;
                }
            }
            if (orden == 1)
            {
                barraRecibir1.Value = (int)Math.Ceiling(cantidad);
                lblBytesConstruccion1.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkRecibir1.Checked = true;
                }
                else
                {
                    checkRecibir1.Checked = false;
                }
            }
            if (orden == 2)
            {
                barraRecibir2.Value = (int)Math.Ceiling(cantidad);
                lblBytesConstruccion2.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkRecibir2.Checked = true;
                }
                else
                {
                    checkRecibir2.Checked = false;
                }
            }
            if (orden == 3)
            {
                barraRecibir3.Value = (int)Math.Ceiling(cantidad);
                lblBytesConstruccion3.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkRecibir3.Checked = true;
                }
                else
                {
                    checkRecibir3.Checked = false;
                }
            }
            if (orden == 4)
            {
                barraRecibir4.Value = (int)Math.Ceiling(cantidad);
                lblBytesConstruccion4.Text = $"Bytes de Construccion: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkRecibir4.Checked = true;
                }
                else
                {
                    checkRecibir4.Checked = false;
                }
            }
        }

        private void ruta_archivo_enviado(object o, string ruta)
        {
            Invoke(delegadoLlegoImagen, ruta);
        }

        private void llenarRutaArchivoLlego(string ruta)
        {
            txtRutaEnviada.Text = $"\n Llego un archivo exitosamente: {ruta}";
            //MessageBox.Show($"Llego un archivo exitosamente: {ruta}");
        }

        private void porcentaje_actual(object o, float cantidad, float bytes_actuales, float total, int orden)
        {
            Invoke(delegadoPorcentaje, cantidad, bytes_actuales, total,orden);
        }

        private void llenarBarra(float cantidad, float bytes_actuales, float total, int orden)
        {
            if (orden == 0)
            {
                barraProgreso.Value = (int)Math.Ceiling(cantidad);
                lblBytesEnvio.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkEnviado.Checked = true;
                }
                else
                {
                    checkEnviado.Checked = false;
                }
            }
            if (orden == 1)
            {
                barraProgreso1.Value = (int)Math.Ceiling(cantidad);
                lblBytesEnvio1.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkEnviado1.Checked = true;
                }
                else
                {
                    checkEnviado1.Checked = false;
                }
            }
            if (orden == 2)
            {
                barraProgreso2.Value = (int)Math.Ceiling(cantidad);
                lblBytesEnvio2.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkEnviado2.Checked = true;
                }
                else
                {
                    checkEnviado2.Checked = false;
                }
            }
            if (orden == 3)
            {
                barraProgreso3.Value = (int)Math.Ceiling(cantidad);
                lblBytesEnvio3.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkEnviado3.Checked = true;
                }
                else
                {
                    checkEnviado3.Checked = false;
                }
            }
            if (orden == 4)
            {
                barraProgreso4.Value = (int)Math.Ceiling(cantidad);
                lblBytesEnvio4.Text = $"Bytes Enviados: {bytes_actuales.ToString()}/{total.ToString()}";

                if (bytes_actuales == total)
                {
                    checkEnviado4.Checked = true;
                }

                else
                {
                    checkEnviado4.Checked = false;
                }
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
                if (txtMensaje.Text.Length <= 0 || txtMensaje.Text.Equals(""))
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
                    number = retornarVacio(disponibles);
                    // 
                    if(number != -1)
                    {
                        disponibles[number] = false; //ocupado
                        id++;
                        conexion.IniciaEnvioArchivo(rutaArchivo, id, number);
                    }
                    else
                    {
                        MessageBox.Show("Cantidad Completa");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("error al enviar: " + ex.Message);
            }
        }

        private void frmSend_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkEnviado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkRecibir1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar5_Click(object sender, EventArgs e)
        {

        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }
    }
}
