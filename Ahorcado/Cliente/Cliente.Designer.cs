namespace Cliente
{
    partial class Cliente
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
            this.grupo_Datos = new System.Windows.Forms.GroupBox();
            this.lbl_Servidor = new System.Windows.Forms.Label();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.txt_Puerto = new System.Windows.Forms.TextBox();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.lb_Puerto = new System.Windows.Forms.Label();
            this.lb_Multiplicador = new System.Windows.Forms.Label();
            this.lb_Score = new System.Windows.Forms.Label();
            this.grupo_Nivel = new System.Windows.Forms.GroupBox();
            this.rb_Dificil = new System.Windows.Forms.RadioButton();
            this.rb_Medio = new System.Windows.Forms.RadioButton();
            this.rb_Facil = new System.Windows.Forms.RadioButton();
            this.pic_Imagen = new System.Windows.Forms.PictureBox();
            this.lb_Vidas = new System.Windows.Forms.Label();
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.grupo_Datos.SuspendLayout();
            this.grupo_Nivel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo_Datos
            // 
            this.grupo_Datos.Controls.Add(this.lbl_Servidor);
            this.grupo_Datos.Controls.Add(this.lbl_Usuario);
            this.grupo_Datos.Controls.Add(this.btn_Conectar);
            this.grupo_Datos.Controls.Add(this.txt_Puerto);
            this.grupo_Datos.Controls.Add(this.txt_Direccion);
            this.grupo_Datos.Controls.Add(this.txt_Usuario);
            this.grupo_Datos.Controls.Add(this.lb_Puerto);
            this.grupo_Datos.Location = new System.Drawing.Point(16, 118);
            this.grupo_Datos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grupo_Datos.Name = "grupo_Datos";
            this.grupo_Datos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grupo_Datos.Size = new System.Drawing.Size(340, 155);
            this.grupo_Datos.TabIndex = 0;
            this.grupo_Datos.TabStop = false;
            this.grupo_Datos.Text = "Datos del Usuario:";
            // 
            // lbl_Servidor
            // 
            this.lbl_Servidor.AutoSize = true;
            this.lbl_Servidor.Location = new System.Drawing.Point(8, 64);
            this.lbl_Servidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Servidor.Name = "lbl_Servidor";
            this.lbl_Servidor.Size = new System.Drawing.Size(128, 17);
            this.lbl_Servidor.TabIndex = 8;
            this.lbl_Servidor.Text = "Direccion Servidor:";
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Location = new System.Drawing.Point(8, 31);
            this.lbl_Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(115, 17);
            this.lbl_Usuario.TabIndex = 7;
            this.lbl_Usuario.Text = "Nombre Usuario:";
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(176, 119);
            this.btn_Conectar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(156, 28);
            this.btn_Conectar.TabIndex = 6;
            this.btn_Conectar.Text = "CONECTAR";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // txt_Puerto
            // 
            this.txt_Puerto.Location = new System.Drawing.Point(176, 87);
            this.txt_Puerto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Puerto.Name = "txt_Puerto";
            this.txt_Puerto.Size = new System.Drawing.Size(155, 22);
            this.txt_Puerto.TabIndex = 5;
            this.txt_Puerto.Text = "8080";
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Location = new System.Drawing.Point(176, 55);
            this.txt_Direccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(155, 22);
            this.txt_Direccion.TabIndex = 4;
            this.txt_Direccion.Text = "192.168.200.5";
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(176, 23);
            this.txt_Usuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(155, 22);
            this.txt_Usuario.TabIndex = 3;
            this.txt_Usuario.Text = "Christian";
            // 
            // lb_Puerto
            // 
            this.lb_Puerto.AutoSize = true;
            this.lb_Puerto.Location = new System.Drawing.Point(8, 96);
            this.lb_Puerto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Puerto.Name = "lb_Puerto";
            this.lb_Puerto.Size = new System.Drawing.Size(140, 17);
            this.lb_Puerto.TabIndex = 2;
            this.lb_Puerto.Text = "Puerto de Conexion: ";
            // 
            // lb_Multiplicador
            // 
            this.lb_Multiplicador.AutoSize = true;
            this.lb_Multiplicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lb_Multiplicador.Location = new System.Drawing.Point(372, 138);
            this.lb_Multiplicador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Multiplicador.Name = "lb_Multiplicador";
            this.lb_Multiplicador.Size = new System.Drawing.Size(42, 31);
            this.lb_Multiplicador.TabIndex = 4;
            this.lb_Multiplicador.Text = "1x";
            // 
            // lb_Score
            // 
            this.lb_Score.AutoSize = true;
            this.lb_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lb_Score.Location = new System.Drawing.Point(369, 92);
            this.lb_Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Score.Name = "lb_Score";
            this.lb_Score.Size = new System.Drawing.Size(170, 46);
            this.lb_Score.TabIndex = 5;
            this.lb_Score.Text = "Score: 0";
            // 
            // grupo_Nivel
            // 
            this.grupo_Nivel.Controls.Add(this.rb_Dificil);
            this.grupo_Nivel.Controls.Add(this.rb_Medio);
            this.grupo_Nivel.Controls.Add(this.rb_Facil);
            this.grupo_Nivel.Location = new System.Drawing.Point(16, 15);
            this.grupo_Nivel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grupo_Nivel.Name = "grupo_Nivel";
            this.grupo_Nivel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grupo_Nivel.Size = new System.Drawing.Size(340, 96);
            this.grupo_Nivel.TabIndex = 1;
            this.grupo_Nivel.TabStop = false;
            this.grupo_Nivel.Text = "Nivel de Juego:";
            // 
            // rb_Dificil
            // 
            this.rb_Dificil.AutoSize = true;
            this.rb_Dificil.Location = new System.Drawing.Point(93, 55);
            this.rb_Dificil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_Dificil.Name = "rb_Dificil";
            this.rb_Dificil.Size = new System.Drawing.Size(127, 21);
            this.rb_Dificil.TabIndex = 2;
            this.rb_Dificil.TabStop = true;
            this.rb_Dificil.Text = "Nivel Avanzado";
            this.rb_Dificil.UseVisualStyleBackColor = true;
            // 
            // rb_Medio
            // 
            this.rb_Medio.AutoSize = true;
            this.rb_Medio.Location = new System.Drawing.Point(197, 27);
            this.rb_Medio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_Medio.Name = "rb_Medio";
            this.rb_Medio.Size = new System.Drawing.Size(130, 21);
            this.rb_Medio.TabIndex = 1;
            this.rb_Medio.TabStop = true;
            this.rb_Medio.Text = "Nivel Intermedio";
            this.rb_Medio.UseVisualStyleBackColor = true;
            // 
            // rb_Facil
            // 
            this.rb_Facil.AutoSize = true;
            this.rb_Facil.Location = new System.Drawing.Point(12, 27);
            this.rb_Facil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_Facil.Name = "rb_Facil";
            this.rb_Facil.Size = new System.Drawing.Size(93, 21);
            this.rb_Facil.TabIndex = 0;
            this.rb_Facil.TabStop = true;
            this.rb_Facil.Text = "Nivel Facil";
            this.rb_Facil.UseVisualStyleBackColor = true;
            // 
            // pic_Imagen
            // 
            this.pic_Imagen.Location = new System.Drawing.Point(871, 92);
            this.pic_Imagen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pic_Imagen.Name = "pic_Imagen";
            this.pic_Imagen.Size = new System.Drawing.Size(228, 181);
            this.pic_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Imagen.TabIndex = 2;
            this.pic_Imagen.TabStop = false;
            // 
            // lb_Vidas
            // 
            this.lb_Vidas.AutoSize = true;
            this.lb_Vidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.lb_Vidas.ForeColor = System.Drawing.Color.Crimson;
            this.lb_Vidas.Location = new System.Drawing.Point(364, 15);
            this.lb_Vidas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Vidas.Name = "lb_Vidas";
            this.lb_Vidas.Size = new System.Drawing.Size(418, 76);
            this.lb_Vidas.TabIndex = 3;
            this.lb_Vidas.Text = "♥♥♥♥♥";
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Location = new System.Drawing.Point(16, 281);
            this.btn_Iniciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(340, 28);
            this.btn_Iniciar.TabIndex = 8;
            this.btn_Iniciar.Text = "Inciar Juego";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.btn_Iniciar_Click);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 556);
            this.Controls.Add(this.btn_Iniciar);
            this.Controls.Add(this.lb_Score);
            this.Controls.Add(this.lb_Multiplicador);
            this.Controls.Add(this.lb_Vidas);
            this.Controls.Add(this.pic_Imagen);
            this.Controls.Add(this.grupo_Nivel);
            this.Controls.Add(this.grupo_Datos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.grupo_Datos.ResumeLayout(false);
            this.grupo_Datos.PerformLayout();
            this.grupo_Nivel.ResumeLayout(false);
            this.grupo_Nivel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grupo_Datos;
        private System.Windows.Forms.Label lb_Puerto;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.TextBox txt_Puerto;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.GroupBox grupo_Nivel;
        private System.Windows.Forms.RadioButton rb_Dificil;
        private System.Windows.Forms.RadioButton rb_Medio;
        private System.Windows.Forms.RadioButton rb_Facil;
        private System.Windows.Forms.PictureBox pic_Imagen;
        private System.Windows.Forms.Label lb_Vidas;
        private System.Windows.Forms.Label lb_Multiplicador;
        private System.Windows.Forms.Label lb_Score;
        private System.Windows.Forms.Label lbl_Servidor;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_Iniciar;
    }
}
