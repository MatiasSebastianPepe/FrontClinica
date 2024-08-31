namespace Front
{
    partial class Detalles
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalles));
            this.nombreDet = new System.Windows.Forms.Label();
            this.telefonoDet = new System.Windows.Forms.Label();
            this.correoDet = new System.Windows.Forms.Label();
            this.fechaNacimientoDet = new System.Windows.Forms.Label();
            this.antecedentesDet = new System.Windows.Forms.Label();
            this.consultaDet = new System.Windows.Forms.Label();
            this.fotoPerfil = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
            this.idVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetallesDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agregaBtnDet = new System.Windows.Forms.Button();
            this.editaBtnDet = new System.Windows.Forms.Button();
            this.deleteBtnDet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descripcionVisita = new System.Windows.Forms.TextBox();
            this.fechaVisita = new System.Windows.Forms.TextBox();
            this.idDet = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.fotoVisita1 = new System.Windows.Forms.PictureBox();
            this.fotoVisita2 = new System.Windows.Forms.PictureBox();
            this.fotoVisita3 = new System.Windows.Forms.PictureBox();
            this.fotoVisita4 = new System.Windows.Forms.PictureBox();
            this.fotoVisita5 = new System.Windows.Forms.PictureBox();
            this.fotoVisita6 = new System.Windows.Forms.PictureBox();
            this.addImg = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita6)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreDet
            // 
            this.nombreDet.AutoSize = true;
            this.nombreDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreDet.Location = new System.Drawing.Point(82, 40);
            this.nombreDet.Name = "nombreDet";
            this.nombreDet.Size = new System.Drawing.Size(76, 19);
            this.nombreDet.TabIndex = 0;
            this.nombreDet.Text = "Nombre:";
            // 
            // telefonoDet
            // 
            this.telefonoDet.AutoSize = true;
            this.telefonoDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoDet.Location = new System.Drawing.Point(300, 40);
            this.telefonoDet.Name = "telefonoDet";
            this.telefonoDet.Size = new System.Drawing.Size(81, 19);
            this.telefonoDet.TabIndex = 1;
            this.telefonoDet.Text = "Teléfono:";
            // 
            // correoDet
            // 
            this.correoDet.AutoSize = true;
            this.correoDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correoDet.Location = new System.Drawing.Point(500, 40);
            this.correoDet.Name = "correoDet";
            this.correoDet.Size = new System.Drawing.Size(61, 18);
            this.correoDet.TabIndex = 2;
            this.correoDet.Text = "Correo:";
            // 
            // fechaNacimientoDet
            // 
            this.fechaNacimientoDet.AutoSize = true;
            this.fechaNacimientoDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoDet.Location = new System.Drawing.Point(800, 40);
            this.fechaNacimientoDet.Name = "fechaNacimientoDet";
            this.fechaNacimientoDet.Size = new System.Drawing.Size(161, 18);
            this.fechaNacimientoDet.TabIndex = 3;
            this.fechaNacimientoDet.Text = "Fecha de Nacimiento:";
            // 
            // antecedentesDet
            // 
            this.antecedentesDet.AutoSize = true;
            this.antecedentesDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antecedentesDet.Location = new System.Drawing.Point(14, 100);
            this.antecedentesDet.Name = "antecedentesDet";
            this.antecedentesDet.Size = new System.Drawing.Size(108, 18);
            this.antecedentesDet.TabIndex = 4;
            this.antecedentesDet.Text = "Antecedentes:";
            // 
            // consultaDet
            // 
            this.consultaDet.AutoSize = true;
            this.consultaDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaDet.Location = new System.Drawing.Point(14, 150);
            this.consultaDet.Name = "consultaDet";
            this.consultaDet.Size = new System.Drawing.Size(116, 18);
            this.consultaDet.TabIndex = 5;
            this.consultaDet.Text = "Consulta Inicial:";
            // 
            // fotoPerfil
            // 
            this.fotoPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoPerfil.Location = new System.Drawing.Point(1087, 40);
            this.fotoPerfil.Name = "fotoPerfil";
            this.fotoPerfil.Size = new System.Drawing.Size(150, 150);
            this.fotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPerfil.TabIndex = 6;
            this.fotoPerfil.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.button1.Location = new System.Drawing.Point(1087, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cambiar Foto";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewDetalles
            // 
            this.dataGridViewDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idVisita,
            this.Fecha,
            this.DetallesDGV});
            this.dataGridViewDetalles.Location = new System.Drawing.Point(440, 250);
            this.dataGridViewDetalles.Name = "dataGridViewDetalles";
            this.dataGridViewDetalles.Size = new System.Drawing.Size(626, 235);
            this.dataGridViewDetalles.TabIndex = 8;
            // 
            // idVisita
            // 
            this.idVisita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idVisita.HeaderText = "Id Visita";
            this.idVisita.Name = "idVisita";
            this.idVisita.Width = 50;
            // 
            // Fecha
            // 
            this.Fecha.FillWeight = 39.85828F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // DetallesDGV
            // 
            this.DetallesDGV.FillWeight = 130.2868F;
            this.DetallesDGV.HeaderText = "Detalles";
            this.DetallesDGV.Name = "DetallesDGV";
            // 
            // agregaBtnDet
            // 
            this.agregaBtnDet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.agregaBtnDet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregaBtnDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregaBtnDet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.agregaBtnDet.Location = new System.Drawing.Point(17, 400);
            this.agregaBtnDet.Name = "agregaBtnDet";
            this.agregaBtnDet.Size = new System.Drawing.Size(100, 35);
            this.agregaBtnDet.TabIndex = 9;
            this.agregaBtnDet.Text = "Agregar";
            this.agregaBtnDet.UseVisualStyleBackColor = false;
            this.agregaBtnDet.Click += new System.EventHandler(this.agregaBtnDet_Click);
            // 
            // editaBtnDet
            // 
            this.editaBtnDet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(50)))));
            this.editaBtnDet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editaBtnDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editaBtnDet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.editaBtnDet.Location = new System.Drawing.Point(123, 400);
            this.editaBtnDet.Name = "editaBtnDet";
            this.editaBtnDet.Size = new System.Drawing.Size(100, 34);
            this.editaBtnDet.TabIndex = 10;
            this.editaBtnDet.Text = "Editar";
            this.editaBtnDet.UseVisualStyleBackColor = false;
            this.editaBtnDet.Click += new System.EventHandler(this.editaBtnDet_Click);
            // 
            // deleteBtnDet
            // 
            this.deleteBtnDet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.deleteBtnDet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtnDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtnDet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.deleteBtnDet.Location = new System.Drawing.Point(229, 400);
            this.deleteBtnDet.Name = "deleteBtnDet";
            this.deleteBtnDet.Size = new System.Drawing.Size(100, 34);
            this.deleteBtnDet.TabIndex = 11;
            this.deleteBtnDet.Text = "Eliminar";
            this.deleteBtnDet.UseVisualStyleBackColor = false;
            this.deleteBtnDet.Click += new System.EventHandler(this.deleteBtnDet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Fecha de la Consulta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Detalles:";
            // 
            // descripcionVisita
            // 
            this.descripcionVisita.Location = new System.Drawing.Point(109, 284);
            this.descripcionVisita.Multiline = true;
            this.descripcionVisita.Name = "descripcionVisita";
            this.descripcionVisita.Size = new System.Drawing.Size(313, 22);
            this.descripcionVisita.TabIndex = 16;
            // 
            // fechaVisita
            // 
            this.fechaVisita.Location = new System.Drawing.Point(229, 250);
            this.fechaVisita.Multiline = true;
            this.fechaVisita.Name = "fechaVisita";
            this.fechaVisita.Size = new System.Drawing.Size(193, 22);
            this.fechaVisita.TabIndex = 17;
            // 
            // idDet
            // 
            this.idDet.AutoSize = true;
            this.idDet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idDet.Location = new System.Drawing.Point(13, 40);
            this.idDet.Name = "idDet";
            this.idDet.Size = new System.Drawing.Size(31, 19);
            this.idDet.TabIndex = 18;
            this.idDet.Text = "ID:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.button2.Location = new System.Drawing.Point(1087, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 34);
            this.button2.TabIndex = 19;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fotoVisita1
            // 
            this.fotoVisita1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fotoVisita1.Location = new System.Drawing.Point(46, 500);
            this.fotoVisita1.Name = "fotoVisita1";
            this.fotoVisita1.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita1.TabIndex = 20;
            this.fotoVisita1.TabStop = false;
            this.fotoVisita1.Click += new System.EventHandler(this.fotoVisita1_Click);
            // 
            // fotoVisita2
            // 
            this.fotoVisita2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita2.Location = new System.Drawing.Point(246, 500);
            this.fotoVisita2.Name = "fotoVisita2";
            this.fotoVisita2.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita2.TabIndex = 21;
            this.fotoVisita2.TabStop = false;
            // 
            // fotoVisita3
            // 
            this.fotoVisita3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita3.Location = new System.Drawing.Point(446, 500);
            this.fotoVisita3.Name = "fotoVisita3";
            this.fotoVisita3.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita3.TabIndex = 22;
            this.fotoVisita3.TabStop = false;
            // 
            // fotoVisita4
            // 
            this.fotoVisita4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita4.Location = new System.Drawing.Point(646, 500);
            this.fotoVisita4.Name = "fotoVisita4";
            this.fotoVisita4.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita4.TabIndex = 23;
            this.fotoVisita4.TabStop = false;
            // 
            // fotoVisita5
            // 
            this.fotoVisita5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita5.Location = new System.Drawing.Point(846, 500);
            this.fotoVisita5.Name = "fotoVisita5";
            this.fotoVisita5.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita5.TabIndex = 24;
            this.fotoVisita5.TabStop = false;
            // 
            // fotoVisita6
            // 
            this.fotoVisita6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fotoVisita6.Location = new System.Drawing.Point(1046, 500);
            this.fotoVisita6.Name = "fotoVisita6";
            this.fotoVisita6.Size = new System.Drawing.Size(170, 170);
            this.fotoVisita6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoVisita6.TabIndex = 25;
            this.fotoVisita6.TabStop = false;
            // 
            // addImg
            // 
            this.addImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.addImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addImg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.addImg.Location = new System.Drawing.Point(17, 321);
            this.addImg.Name = "addImg";
            this.addImg.Size = new System.Drawing.Size(199, 35);
            this.addImg.TabIndex = 26;
            this.addImg.Text = "Agregar Imagenes";
            this.addImg.UseVisualStyleBackColor = false;
            this.addImg.Click += new System.EventHandler(this.addImg_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.button4.Location = new System.Drawing.Point(17, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 35);
            this.button4.TabIndex = 27;
            this.button4.Text = "Mostrar Imagenes";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(186)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.button3.Location = new System.Drawing.Point(1087, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Guardar Foto";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.addImg);
            this.Controls.Add(this.fotoVisita6);
            this.Controls.Add(this.fotoVisita5);
            this.Controls.Add(this.fotoVisita4);
            this.Controls.Add(this.fotoVisita3);
            this.Controls.Add(this.fotoVisita2);
            this.Controls.Add(this.fotoVisita1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.idDet);
            this.Controls.Add(this.fechaVisita);
            this.Controls.Add(this.descripcionVisita);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteBtnDet);
            this.Controls.Add(this.editaBtnDet);
            this.Controls.Add(this.agregaBtnDet);
            this.Controls.Add(this.dataGridViewDetalles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fotoPerfil);
            this.Controls.Add(this.consultaDet);
            this.Controls.Add(this.antecedentesDet);
            this.Controls.Add(this.fechaNacimientoDet);
            this.Controls.Add(this.correoDet);
            this.Controls.Add(this.telefonoDet);
            this.Controls.Add(this.nombreDet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Detalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del Paciente";
            ((System.ComponentModel.ISupportInitialize)(this.fotoPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoVisita6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreDet;
        private System.Windows.Forms.Label telefonoDet;
        private System.Windows.Forms.Label correoDet;
        private System.Windows.Forms.Label fechaNacimientoDet;
        private System.Windows.Forms.Label antecedentesDet;
        private System.Windows.Forms.Label consultaDet;
        private System.Windows.Forms.PictureBox fotoPerfil;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewDetalles;
        private System.Windows.Forms.Button agregaBtnDet;
        private System.Windows.Forms.Button editaBtnDet;
        private System.Windows.Forms.Button deleteBtnDet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descripcionVisita;
        private System.Windows.Forms.TextBox fechaVisita;
        private System.Windows.Forms.Label idDet;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox fotoVisita1;
        private System.Windows.Forms.PictureBox fotoVisita2;
        private System.Windows.Forms.PictureBox fotoVisita3;
        private System.Windows.Forms.PictureBox fotoVisita4;
        private System.Windows.Forms.PictureBox fotoVisita5;
        private System.Windows.Forms.PictureBox fotoVisita6;
        private System.Windows.Forms.Button addImg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetallesDGV;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
    }
}
