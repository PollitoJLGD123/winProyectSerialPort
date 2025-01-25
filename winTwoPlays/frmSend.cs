﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winTwoPlays
{
    public partial class frmSend : Form
    {
        claseSendRecive conexion;
        Image imagen_redimensionada;
        delegate void hacerMetodoSecundario(string mensaje);
        hacerMetodoSecundario delegadoMetodo;

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
        }

        private void llego_Mensaje(object o, string mm)
        {
            Invoke(delegadoMetodo, mm);
        }

        private void MostrandoMensaje(string texto)
        {
            txtConversacion.Text += $" COM2: {texto} \t\t\t";
        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMensaje.Text.Length < 0)
                {
                    MessageBox.Show("Ingresa texto válido");
                }
                else
                {
                    string texto = txtMensaje.Text.Trim();
                    conexion.enviarMensaje(texto);
                    txtConversacion.Text += $" COM 1: {texto} \t\t\t";
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
                fileDialog.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image imagen = Image.FromFile(fileDialog.FileName);
                     
                    imagen_redimensionada = ResizeImage(imagen, 150, 150);

                    pictureBox.Image = imagen_redimensionada;
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


        private Image ResizeImage(Image originalImage, int width, int height)
        {
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedBitmap;
        }
    }
}
