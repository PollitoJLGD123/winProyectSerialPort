namespace winTwoPlays
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.barraRecibir1 = new System.Windows.Forms.ProgressBar();
            this.checkRecibir1 = new System.Windows.Forms.CheckBox();
            this.lblBytesConstruccion1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.barraProgreso1 = new System.Windows.Forms.ProgressBar();
            this.lblBytesEnvio1 = new System.Windows.Forms.Label();
            this.checkEnviado1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.barraRecibir = new System.Windows.Forms.ProgressBar();
            this.checkRecibir = new System.Windows.Forms.CheckBox();
            this.lblBytesConstruccion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.barraProgreso = new System.Windows.Forms.ProgressBar();
            this.lblBytesEnvio = new System.Windows.Forms.Label();
            this.checkEnviado = new System.Windows.Forms.CheckBox();
            this.txtRutaEnviada = new System.Windows.Forms.RichTextBox();
            this.txtRuta = new System.Windows.Forms.RichTextBox();
            this.txtConversacion = new System.Windows.Forms.RichTextBox();
            this.lblLenght = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEnviarImagen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSeleccionarImagen = new System.Windows.Forms.Button();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtRutaEnviada);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.txtConversacion);
            this.panel1.Controls.Add(this.lblLenght);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnEnviarImagen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSeleccionarImagen);
            this.panel1.Controls.Add(this.btnEnviarMensaje);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMensaje);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1374, 703);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.barraRecibir1);
            this.groupBox6.Controls.Add(this.checkRecibir1);
            this.groupBox6.Controls.Add(this.lblBytesConstruccion1);
            this.groupBox6.Location = new System.Drawing.Point(985, 503);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(309, 150);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            // 
            // barraRecibir1
            // 
            this.barraRecibir1.Location = new System.Drawing.Point(23, 27);
            this.barraRecibir1.Name = "barraRecibir1";
            this.barraRecibir1.Size = new System.Drawing.Size(270, 23);
            this.barraRecibir1.TabIndex = 24;
            // 
            // checkRecibir1
            // 
            this.checkRecibir1.AutoCheck = false;
            this.checkRecibir1.AutoSize = true;
            this.checkRecibir1.BackColor = System.Drawing.Color.White;
            this.checkRecibir1.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRecibir1.ForeColor = System.Drawing.Color.Red;
            this.checkRecibir1.Location = new System.Drawing.Point(54, 110);
            this.checkRecibir1.Name = "checkRecibir1";
            this.checkRecibir1.Size = new System.Drawing.Size(211, 21);
            this.checkRecibir1.TabIndex = 26;
            this.checkRecibir1.Text = "Archivo Recibido ✓ ✖";
            this.checkRecibir1.UseVisualStyleBackColor = false;
            // 
            // lblBytesConstruccion1
            // 
            this.lblBytesConstruccion1.AutoSize = true;
            this.lblBytesConstruccion1.Location = new System.Drawing.Point(20, 70);
            this.lblBytesConstruccion1.Name = "lblBytesConstruccion1";
            this.lblBytesConstruccion1.Size = new System.Drawing.Size(118, 16);
            this.lblBytesConstruccion1.TabIndex = 25;
            this.lblBytesConstruccion1.Text = "Bytes Construidos:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.barraProgreso1);
            this.groupBox5.Controls.Add(this.lblBytesEnvio1);
            this.groupBox5.Controls.Add(this.checkEnviado1);
            this.groupBox5.Location = new System.Drawing.Point(994, 129);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(309, 163);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            // 
            // barraProgreso1
            // 
            this.barraProgreso1.Location = new System.Drawing.Point(18, 33);
            this.barraProgreso1.Name = "barraProgreso1";
            this.barraProgreso1.Size = new System.Drawing.Size(270, 23);
            this.barraProgreso1.TabIndex = 1;
            // 
            // lblBytesEnvio1
            // 
            this.lblBytesEnvio1.AutoSize = true;
            this.lblBytesEnvio1.Location = new System.Drawing.Point(15, 78);
            this.lblBytesEnvio1.Name = "lblBytesEnvio1";
            this.lblBytesEnvio1.Size = new System.Drawing.Size(104, 16);
            this.lblBytesEnvio1.TabIndex = 23;
            this.lblBytesEnvio1.Text = "Bytes Enviados:";
            // 
            // checkEnviado1
            // 
            this.checkEnviado1.AutoCheck = false;
            this.checkEnviado1.AutoSize = true;
            this.checkEnviado1.BackColor = System.Drawing.Color.White;
            this.checkEnviado1.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEnviado1.ForeColor = System.Drawing.Color.Red;
            this.checkEnviado1.Location = new System.Drawing.Point(55, 121);
            this.checkEnviado1.Name = "checkEnviado1";
            this.checkEnviado1.Size = new System.Drawing.Size(205, 21);
            this.checkEnviado1.TabIndex = 8;
            this.checkEnviado1.Text = "Archivo Enviado ✓ ✖";
            this.checkEnviado1.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.barraRecibir);
            this.groupBox3.Controls.Add(this.checkRecibir);
            this.groupBox3.Controls.Add(this.lblBytesConstruccion);
            this.groupBox3.Location = new System.Drawing.Point(636, 503);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 150);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // barraRecibir
            // 
            this.barraRecibir.Location = new System.Drawing.Point(23, 27);
            this.barraRecibir.Name = "barraRecibir";
            this.barraRecibir.Size = new System.Drawing.Size(270, 23);
            this.barraRecibir.TabIndex = 24;
            // 
            // checkRecibir
            // 
            this.checkRecibir.AutoCheck = false;
            this.checkRecibir.AutoSize = true;
            this.checkRecibir.BackColor = System.Drawing.Color.White;
            this.checkRecibir.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRecibir.ForeColor = System.Drawing.Color.Red;
            this.checkRecibir.Location = new System.Drawing.Point(54, 110);
            this.checkRecibir.Name = "checkRecibir";
            this.checkRecibir.Size = new System.Drawing.Size(211, 21);
            this.checkRecibir.TabIndex = 26;
            this.checkRecibir.Text = "Archivo Recibido ✓ ✖";
            this.checkRecibir.UseVisualStyleBackColor = false;
            // 
            // lblBytesConstruccion
            // 
            this.lblBytesConstruccion.AutoSize = true;
            this.lblBytesConstruccion.Location = new System.Drawing.Point(20, 70);
            this.lblBytesConstruccion.Name = "lblBytesConstruccion";
            this.lblBytesConstruccion.Size = new System.Drawing.Size(118, 16);
            this.lblBytesConstruccion.TabIndex = 25;
            this.lblBytesConstruccion.Text = "Bytes Construidos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.barraProgreso);
            this.groupBox1.Controls.Add(this.lblBytesEnvio);
            this.groupBox1.Controls.Add(this.checkEnviado);
            this.groupBox1.Location = new System.Drawing.Point(657, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 163);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // barraProgreso
            // 
            this.barraProgreso.Location = new System.Drawing.Point(18, 33);
            this.barraProgreso.Name = "barraProgreso";
            this.barraProgreso.Size = new System.Drawing.Size(270, 23);
            this.barraProgreso.TabIndex = 1;
            // 
            // lblBytesEnvio
            // 
            this.lblBytesEnvio.AutoSize = true;
            this.lblBytesEnvio.Location = new System.Drawing.Point(15, 78);
            this.lblBytesEnvio.Name = "lblBytesEnvio";
            this.lblBytesEnvio.Size = new System.Drawing.Size(104, 16);
            this.lblBytesEnvio.TabIndex = 23;
            this.lblBytesEnvio.Text = "Bytes Enviados:";
            // 
            // checkEnviado
            // 
            this.checkEnviado.AutoCheck = false;
            this.checkEnviado.AutoSize = true;
            this.checkEnviado.BackColor = System.Drawing.Color.White;
            this.checkEnviado.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEnviado.ForeColor = System.Drawing.Color.Red;
            this.checkEnviado.Location = new System.Drawing.Point(55, 121);
            this.checkEnviado.Name = "checkEnviado";
            this.checkEnviado.Size = new System.Drawing.Size(205, 21);
            this.checkEnviado.TabIndex = 8;
            this.checkEnviado.Text = "Archivo Enviado ✓ ✖";
            this.checkEnviado.UseVisualStyleBackColor = false;
            // 
            // txtRutaEnviada
            // 
            this.txtRutaEnviada.Enabled = false;
            this.txtRutaEnviada.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaEnviada.Location = new System.Drawing.Point(636, 437);
            this.txtRutaEnviada.Name = "txtRutaEnviada";
            this.txtRutaEnviada.Size = new System.Drawing.Size(317, 52);
            this.txtRutaEnviada.TabIndex = 22;
            this.txtRutaEnviada.Text = "";
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Adobe Song Std L", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(332, 481);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(270, 87);
            this.txtRuta.TabIndex = 21;
            this.txtRuta.Text = "";
            // 
            // txtConversacion
            // 
            this.txtConversacion.Enabled = false;
            this.txtConversacion.Location = new System.Drawing.Point(28, 413);
            this.txtConversacion.Name = "txtConversacion";
            this.txtConversacion.ReadOnly = true;
            this.txtConversacion.Size = new System.Drawing.Size(276, 228);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(631, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Recibir Archivo:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnEnviarImagen
            // 
            this.btnEnviarImagen.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarImagen.Location = new System.Drawing.Point(369, 609);
            this.btnEnviarImagen.Name = "btnEnviarImagen";
            this.btnEnviarImagen.Size = new System.Drawing.Size(180, 44);
            this.btnEnviarImagen.TabIndex = 14;
            this.btnEnviarImagen.Text = "Enviar Archivo";
            this.btnEnviarImagen.UseVisualStyleBackColor = true;
            this.btnEnviarImagen.Click += new System.EventHandler(this.btnEnviarImagen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ruta Seleccionada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(341, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Selecciona Archivo a Enviar";
            // 
            // btnSeleccionarImagen
            // 
            this.btnSeleccionarImagen.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarImagen.Location = new System.Drawing.Point(357, 249);
            this.btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            this.btnSeleccionarImagen.Size = new System.Drawing.Size(226, 43);
            this.btnSeleccionarImagen.TabIndex = 9;
            this.btnSeleccionarImagen.Text = "Seleccionar Archivo";
            this.btnSeleccionarImagen.UseVisualStyleBackColor = true;
            this.btnSeleccionarImagen.Click += new System.EventHandler(this.btnSeleccionarImagen_Click);
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
            this.label3.Location = new System.Drawing.Point(656, 79);
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
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("MV Boli", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(413, 7);
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
            this.ClientSize = new System.Drawing.Size(1375, 703);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSend";
            this.Text = "Form of Send and Receive";
            this.Load += new System.EventHandler(this.frmSend_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLenght;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ProgressBar barraProgreso1;
        private System.Windows.Forms.Label lblBytesEnvio1;
        private System.Windows.Forms.CheckBox checkEnviado1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ProgressBar barraRecibir1;
        private System.Windows.Forms.CheckBox checkRecibir1;
        private System.Windows.Forms.Label lblBytesConstruccion1;
    }
}