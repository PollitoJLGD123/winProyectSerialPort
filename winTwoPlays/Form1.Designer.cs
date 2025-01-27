namespace winTwoPlays
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPuerto2 = new System.Windows.Forms.Label();
            this.checkConectado2 = new System.Windows.Forms.CheckBox();
            this.lblEstado2 = new System.Windows.Forms.Label();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnIngresar2 = new System.Windows.Forms.Button();
            this.barraProgreso2 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPuerto1 = new System.Windows.Forms.Label();
            this.checkConectado1 = new System.Windows.Forms.CheckBox();
            this.lblEstado1 = new System.Windows.Forms.Label();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.barraProgreso1 = new System.Windows.Forms.ProgressBar();
            this.comboParityBits = new System.Windows.Forms.ComboBox();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.comboBaud = new System.Windows.Forms.ComboBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.comboParityBits);
            this.panel1.Controls.Add(this.comboStopBits);
            this.panel1.Controls.Add(this.comboDataBits);
            this.panel1.Controls.Add(this.comboBaud);
            this.panel1.Controls.Add(this.comboPort);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnConectar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 692);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPuerto2);
            this.groupBox2.Controls.Add(this.checkConectado2);
            this.groupBox2.Controls.Add(this.lblEstado2);
            this.groupBox2.Controls.Add(this.btnClose2);
            this.groupBox2.Controls.Add(this.btnIngresar2);
            this.groupBox2.Controls.Add(this.barraProgreso2);
            this.groupBox2.Location = new System.Drawing.Point(484, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 280);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // lblPuerto2
            // 
            this.lblPuerto2.AutoSize = true;
            this.lblPuerto2.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto2.Location = new System.Drawing.Point(21, 18);
            this.lblPuerto2.Name = "lblPuerto2";
            this.lblPuerto2.Size = new System.Drawing.Size(85, 23);
            this.lblPuerto2.TabIndex = 32;
            this.lblPuerto2.Text = "Puerto 2:";
            // 
            // checkConectado2
            // 
            this.checkConectado2.AutoSize = true;
            this.checkConectado2.Enabled = false;
            this.checkConectado2.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConectado2.Location = new System.Drawing.Point(98, 103);
            this.checkConectado2.Name = "checkConectado2";
            this.checkConectado2.Size = new System.Drawing.Size(157, 21);
            this.checkConectado2.TabIndex = 8;
            this.checkConectado2.Text = "Conectado ✓ ✖";
            this.checkConectado2.UseVisualStyleBackColor = true;
            // 
            // lblEstado2
            // 
            this.lblEstado2.AutoSize = true;
            this.lblEstado2.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado2.ForeColor = System.Drawing.Color.Red;
            this.lblEstado2.Location = new System.Drawing.Point(143, 48);
            this.lblEstado2.Name = "lblEstado2";
            this.lblEstado2.Size = new System.Drawing.Size(65, 29);
            this.lblEstado2.TabIndex = 30;
            this.lblEstado2.Text = "OFF";
            // 
            // btnClose2
            // 
            this.btnClose2.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose2.Location = new System.Drawing.Point(202, 188);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(93, 43);
            this.btnClose2.TabIndex = 25;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // btnIngresar2
            // 
            this.btnIngresar2.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar2.Location = new System.Drawing.Point(40, 188);
            this.btnIngresar2.Name = "btnIngresar2";
            this.btnIngresar2.Size = new System.Drawing.Size(94, 43);
            this.btnIngresar2.TabIndex = 17;
            this.btnIngresar2.Text = "Ingresar";
            this.btnIngresar2.UseVisualStyleBackColor = true;
            this.btnIngresar2.Click += new System.EventHandler(this.btnIngresar2_Click);
            // 
            // barraProgreso2
            // 
            this.barraProgreso2.Location = new System.Drawing.Point(25, 139);
            this.barraProgreso2.Name = "barraProgreso2";
            this.barraProgreso2.Size = new System.Drawing.Size(289, 23);
            this.barraProgreso2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPuerto1);
            this.groupBox1.Controls.Add(this.checkConectado1);
            this.groupBox1.Controls.Add(this.lblEstado1);
            this.groupBox1.Controls.Add(this.btnClose1);
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.barraProgreso1);
            this.groupBox1.Location = new System.Drawing.Point(484, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 261);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // lblPuerto1
            // 
            this.lblPuerto1.AutoSize = true;
            this.lblPuerto1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto1.Location = new System.Drawing.Point(21, 18);
            this.lblPuerto1.Name = "lblPuerto1";
            this.lblPuerto1.Size = new System.Drawing.Size(85, 23);
            this.lblPuerto1.TabIndex = 32;
            this.lblPuerto1.Text = "Puerto 1:";
            // 
            // checkConectado1
            // 
            this.checkConectado1.AutoSize = true;
            this.checkConectado1.Enabled = false;
            this.checkConectado1.Font = new System.Drawing.Font("Lucida Handwriting", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConectado1.Location = new System.Drawing.Point(98, 103);
            this.checkConectado1.Name = "checkConectado1";
            this.checkConectado1.Size = new System.Drawing.Size(157, 21);
            this.checkConectado1.TabIndex = 8;
            this.checkConectado1.Text = "Conectado ✓ ✖";
            this.checkConectado1.UseVisualStyleBackColor = true;
            // 
            // lblEstado1
            // 
            this.lblEstado1.AutoSize = true;
            this.lblEstado1.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado1.ForeColor = System.Drawing.Color.Red;
            this.lblEstado1.Location = new System.Drawing.Point(143, 48);
            this.lblEstado1.Name = "lblEstado1";
            this.lblEstado1.Size = new System.Drawing.Size(65, 29);
            this.lblEstado1.TabIndex = 30;
            this.lblEstado1.Text = "OFF";
            // 
            // btnClose1
            // 
            this.btnClose1.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.Location = new System.Drawing.Point(202, 188);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(93, 43);
            this.btnClose1.TabIndex = 25;
            this.btnClose1.Text = "Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(40, 188);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(94, 43);
            this.btnIngresar.TabIndex = 17;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // barraProgreso1
            // 
            this.barraProgreso1.Location = new System.Drawing.Point(25, 139);
            this.barraProgreso1.Name = "barraProgreso1";
            this.barraProgreso1.Size = new System.Drawing.Size(289, 23);
            this.barraProgreso1.TabIndex = 1;
            // 
            // comboParityBits
            // 
            this.comboParityBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParityBits.FormattingEnabled = true;
            this.comboParityBits.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None"});
            this.comboParityBits.Location = new System.Drawing.Point(162, 345);
            this.comboParityBits.Name = "comboParityBits";
            this.comboParityBits.Size = new System.Drawing.Size(195, 24);
            this.comboParityBits.TabIndex = 29;
            // 
            // comboStopBits
            // 
            this.comboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStopBits.FormattingEnabled = true;
            this.comboStopBits.Items.AddRange(new object[] {
            "Two",
            "One"});
            this.comboStopBits.Location = new System.Drawing.Point(155, 293);
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.Size = new System.Drawing.Size(195, 24);
            this.comboStopBits.TabIndex = 28;
            // 
            // comboDataBits
            // 
            this.comboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataBits.FormattingEnabled = true;
            this.comboDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.comboDataBits.Location = new System.Drawing.Point(155, 245);
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.Size = new System.Drawing.Size(195, 24);
            this.comboDataBits.TabIndex = 27;
            // 
            // comboBaud
            // 
            this.comboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBaud.FormattingEnabled = true;
            this.comboBaud.Items.AddRange(new object[] {
            "9600",
            "4800",
            "2400"});
            this.comboBaud.Location = new System.Drawing.Point(155, 189);
            this.comboBaud.Name = "comboBaud";
            this.comboBaud.Size = new System.Drawing.Size(195, 24);
            this.comboBaud.TabIndex = 1;
            // 
            // comboPort
            // 
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(155, 148);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(195, 24);
            this.comboPort.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "PARITY BITS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "DATA BITS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "STOP BITS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "BAUD RATE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "COM PORT:";
            // 
            // label8
            // 
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(127, 477);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 176);
            this.label8.TabIndex = 16;
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(53, 399);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(124, 43);
            this.btnConectar.TabIndex = 14;
            this.btnConectar.Text = "Open";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnEnviarImagen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Configuración:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(171, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection Serial Port";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 691);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "git ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label8;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.CheckBox checkConectado1;
        private System.Windows.Forms.ProgressBar barraProgreso1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboPort;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.ComboBox comboBaud;
        private System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.ComboBox comboParityBits;
        private System.Windows.Forms.ComboBox comboStopBits;
        private System.Windows.Forms.Label lblEstado1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPuerto1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPuerto2;
        private System.Windows.Forms.CheckBox checkConectado2;
        private System.Windows.Forms.Label lblEstado2;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnIngresar2;
        private System.Windows.Forms.ProgressBar barraProgreso2;
    }
}

