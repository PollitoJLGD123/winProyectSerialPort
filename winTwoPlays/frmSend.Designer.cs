﻿namespace winTwoPlays
{
    partial class frmSend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSend));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkRecibir = new System.Windows.Forms.CheckBox();
            this.lblBytesConstruccion = new System.Windows.Forms.Label();
            this.barraRecibir = new System.Windows.Forms.ProgressBar();
            this.lblBytesEnvio = new System.Windows.Forms.Label();
            this.txtRutaEnviada = new System.Windows.Forms.RichTextBox();
            this.txtRuta = new System.Windows.Forms.RichTextBox();
            this.txtConversacion = new System.Windows.Forms.RichTextBox();
            this.lblLenght = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEnviarImagen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSeleccionarImagen = new System.Windows.Forms.Button();
            this.checkEnviado = new System.Windows.Forms.CheckBox();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.barraProgreso = new System.Windows.Forms.ProgressBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkRecibir);
            this.panel1.Controls.Add(this.lblBytesConstruccion);
            this.panel1.Controls.Add(this.barraRecibir);
            this.panel1.Controls.Add(this.lblBytesEnvio);
            this.panel1.Controls.Add(this.txtRutaEnviada);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.txtConversacion);
            this.panel1.Controls.Add(this.lblLenght);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnEnviarImagen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSeleccionarImagen);
            this.panel1.Controls.Add(this.checkEnviado);
            this.panel1.Controls.Add(this.btnEnviarMensaje);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMensaje);
            this.panel1.Controls.Add(this.barraProgreso);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 745);
            this.panel1.TabIndex = 1;
            // 
            // checkRecibir
            // 
            this.checkRecibir.AutoCheck = false;
            this.checkRecibir.AutoSize = true;
            this.checkRecibir.BackColor = System.Drawing.Color.White;
            this.checkRecibir.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRecibir.ForeColor = System.Drawing.Color.Red;
            this.checkRecibir.Location = new System.Drawing.Point(376, 699);
            this.checkRecibir.Name = "checkRecibir";
            this.checkRecibir.Size = new System.Drawing.Size(211, 21);
            this.checkRecibir.TabIndex = 26;
            this.checkRecibir.Text = "Archivo Recibido ✓ ✖";
            this.checkRecibir.UseVisualStyleBackColor = false;
            // 
            // lblBytesConstruccion
            // 
            this.lblBytesConstruccion.AutoSize = true;
            this.lblBytesConstruccion.Location = new System.Drawing.Point(328, 557);
            this.lblBytesConstruccion.Name = "lblBytesConstruccion";
            this.lblBytesConstruccion.Size = new System.Drawing.Size(118, 16);
            this.lblBytesConstruccion.TabIndex = 25;
            this.lblBytesConstruccion.Text = "Bytes Construidos:";
            // 
            // barraRecibir
            // 
            this.barraRecibir.Location = new System.Drawing.Point(331, 508);
            this.barraRecibir.Name = "barraRecibir";
            this.barraRecibir.Size = new System.Drawing.Size(270, 23);
            this.barraRecibir.TabIndex = 24;
            // 
            // lblBytesEnvio
            // 
            this.lblBytesEnvio.AutoSize = true;
            this.lblBytesEnvio.Location = new System.Drawing.Point(724, 597);
            this.lblBytesEnvio.Name = "lblBytesEnvio";
            this.lblBytesEnvio.Size = new System.Drawing.Size(104, 16);
            this.lblBytesEnvio.TabIndex = 23;
            this.lblBytesEnvio.Text = "Bytes Enviados:";
            // 
            // txtRutaEnviada
            // 
            this.txtRutaEnviada.Enabled = false;
            this.txtRutaEnviada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaEnviada.Location = new System.Drawing.Point(331, 585);
            this.txtRutaEnviada.Name = "txtRutaEnviada";
            this.txtRutaEnviada.Size = new System.Drawing.Size(301, 94);
            this.txtRutaEnviada.TabIndex = 22;
            this.txtRutaEnviada.Text = "";
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Adobe Song Std L", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(736, 196);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(270, 153);
            this.txtRuta.TabIndex = 21;
            this.txtRuta.Text = "";
            // 
            // txtConversacion
            // 
            this.txtConversacion.Enabled = false;
            this.txtConversacion.Location = new System.Drawing.Point(28, 413);
            this.txtConversacion.Name = "txtConversacion";
            this.txtConversacion.Size = new System.Drawing.Size(276, 268);
            this.txtConversacion.TabIndex = 20;
            this.txtConversacion.Text = "";
            // 
            // lblLenght
            // 
            this.lblLenght.AutoSize = true;
            this.lblLenght.Font = new System.Drawing.Font("Gabriola", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenght.Location = new System.Drawing.Point(106, 307);
            this.lblLenght.Name = "lblLenght";
            this.lblLenght.Size = new System.Drawing.Size(38, 42);
            this.lblLenght.TabIndex = 18;
            this.lblLenght.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 37);
            this.label9.TabIndex = 17;
            this.label9.Text = "Lenght:";
            // 
            // label8
            // 
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(403, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 176);
            this.label8.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(326, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Recibir Imagen:";
            // 
            // btnEnviarImagen
            // 
            this.btnEnviarImagen.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarImagen.Location = new System.Drawing.Point(778, 375);
            this.btnEnviarImagen.Name = "btnEnviarImagen";
            this.btnEnviarImagen.Size = new System.Drawing.Size(180, 43);
            this.btnEnviarImagen.TabIndex = 14;
            this.btnEnviarImagen.Text = "Enviar Archivo";
            this.btnEnviarImagen.UseVisualStyleBackColor = true;
            this.btnEnviarImagen.Click += new System.EventHandler(this.btnEnviarImagen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(741, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ruta Seleccionada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(371, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Selecciona Archivo a Enviar";
            // 
            // btnSeleccionarImagen
            // 
            this.btnSeleccionarImagen.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarImagen.Location = new System.Drawing.Point(389, 210);
            this.btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            this.btnSeleccionarImagen.Size = new System.Drawing.Size(226, 43);
            this.btnSeleccionarImagen.TabIndex = 9;
            this.btnSeleccionarImagen.Text = "Seleccionar Archivo";
            this.btnSeleccionarImagen.UseVisualStyleBackColor = true;
            this.btnSeleccionarImagen.Click += new System.EventHandler(this.btnSeleccionarImagen_Click);
            // 
            // checkEnviado
            // 
            this.checkEnviado.AutoCheck = false;
            this.checkEnviado.AutoSize = true;
            this.checkEnviado.BackColor = System.Drawing.Color.White;
            this.checkEnviado.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEnviado.ForeColor = System.Drawing.Color.Red;
            this.checkEnviado.Location = new System.Drawing.Point(764, 640);
            this.checkEnviado.Name = "checkEnviado";
            this.checkEnviado.Size = new System.Drawing.Size(205, 21);
            this.checkEnviado.TabIndex = 8;
            this.checkEnviado.Text = "Archivo Enviado ✓ ✖";
            this.checkEnviado.UseVisualStyleBackColor = false;
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMensaje.Location = new System.Drawing.Point(28, 248);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(234, 36);
            this.btnEnviarMensaje.TabIndex = 7;
            this.btnEnviarMensaje.Text = "Enviar Mensaje";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Script MT Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "Conversación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(722, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado de Envio de Archivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mensaje a Enviar:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(28, 150);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(276, 79);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            this.txtMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMensaje_KeyDown);
            // 
            // barraProgreso
            // 
            this.barraProgreso.Location = new System.Drawing.Point(727, 558);
            this.barraProgreso.Name = "barraProgreso";
            this.barraProgreso.Size = new System.Drawing.Size(270, 23);
            this.barraProgreso.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("MV Boli", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(268, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(256, 55);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Serial Port";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialog";
            // 
            // frmSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 743);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSend";
            this.Text = "frmSend";
            this.Load += new System.EventHandler(this.frmSend_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLenght;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEnviarImagen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSeleccionarImagen;
        private System.Windows.Forms.CheckBox checkEnviado;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.ProgressBar barraProgreso;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox txtConversacion;
        private System.Windows.Forms.RichTextBox txtRuta;
        private System.Windows.Forms.RichTextBox txtRutaEnviada;
        private System.Windows.Forms.Label lblBytesEnvio;
        private System.Windows.Forms.Label lblBytesConstruccion;
        private System.Windows.Forms.ProgressBar barraRecibir;
        private System.Windows.Forms.CheckBox checkRecibir;
    }
}