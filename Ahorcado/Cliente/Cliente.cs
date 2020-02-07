using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Media;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System;


namespace Cliente
{
    public partial class Cliente : Form
    {
        //string[] sonido_Nuevo = new string[5] { "new_1.wav", "new_2.wav", "new_3.wav", "new_4.wav", "new_5.wav" };
        //string[] sonido_Correcto = new string[3] { "correct_1.wav", "correct_3.wav", "correct_3.wav" };
        //string[] sonido_Perdida = new string[3] { "lose_1.wav", "lose_2.wav", "lose_3.wav" };
        //string[] sonido_Victoria = new string[3] { "win_1.wav", "win_2.wav", "win_3.wav" };
        //WMPLib.WindowsMediaPlayer sonido_Inicio = new WMPLib.WindowsMediaPlayer();
        //WMPLib.WindowsMediaPlayer sonido_Inicio_2 = new WMPLib.WindowsMediaPlayer();
        Label[] palara_Escogida_Pantalla = new Label[32];
        string[] palabra_Escogida = new string[110000];
        ASCIIEncoding asen = new ASCIIEncoding();
        //SoundPlayer sonidos = new SoundPlayer();
        Random palabra_Aleatoria = new Random();
        List<Label> labels = new List<Label>();
        Button[] boton_Letra = new Button[27];
        string longitud_palabra;
        int multiplicador = 1;
        string confirmacion;
        int aciertos = 0;
        int dificultad;
        string palabra;
        string nombre;
        bool ignore;
        int stage;
        int vidas;
        int score;
        
        public Cliente()
        {
            InitializeComponent();
            Paint += muñeco;
        }

        private void muñeco(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (rb_Facil.Checked == true)
            {
                if (stage >= 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 150, 190, 210, 190);
                }
                if (stage >= 2)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
                }
                if (stage >= 3)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
                }
                if (stage >= 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
                }
                if (stage >= 5)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
                }
                if (stage >= 6)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);
                }
                if (stage >= 7)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
                }
                if (stage >= 8)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
                }
                if (stage >= 9)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
                }
                if (stage >= 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
                }
            }
            if (rb_Medio.Checked == true)
            {
                if (stage >= 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
                }
                if (stage >= 2)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
                }
                if (stage >= 3)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
                }
                if (stage >= 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);
                }
                if (stage >= 5)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
                }
                if (stage >= 6)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
                }
                if (stage >= 7)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
                }
                if (stage >= 8)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
                }
                
            }
            if (rb_Dificil.Checked == true)
            {
                if (stage >= 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
                }
                if (stage >= 2)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
                }
                if (stage >= 3)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);  
                }
                if (stage >= 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
                }
                if (stage >= 5)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
                }
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            lb_Multiplicador.Visible = false;
            btn_Iniciar.Enabled = false;
            pic_Imagen.Visible = false; 
            lb_Score.Visible = false;
            lb_Vidas.Visible = false;
            rb_Facil.Checked = true;
        }

        private void letra_Click(object sender, EventArgs e)
        {
            Button letra_Presionada = sender as Button;
            int indice = 0;
            bool existe = false;
            TcpClient cliente = new TcpClient(txt_Direccion.Text, 12345);
            ASCIIEncoding asen = new ASCIIEncoding();
            char caracter = Convert.ToChar(letra_Presionada.Text.ToLower());
            byte[] buffer = asen.GetBytes(caracter + ":");
            NetworkStream flujoRed = cliente.GetStream();
            flujoRed.Write(buffer, 0, buffer.GetLength(0));
            flujoRed.Close();
            Thread hiloEscucha = new Thread(new ThreadStart(escuchar_Servidor_respuesta));
            hiloEscucha.Start();
            if (confirmacion == "OK")
            {
                foreach (char caracteres in palabra)
                {
                    if (caracteres == Convert.ToChar(letra_Presionada.Text.ToLower()))
                    {
                        palara_Escogida_Pantalla[indice].Text = letra_Presionada.Text;
                        aciertos++;
                        existe = true;
                        score += 8 * multiplicador;
                        multiplicador += 1;
                        letra_Presionada.Visible = false;
                        //sonido_Inicio_2.URL = sonido_Correcto[palabra_Aleatoria.Next(sonido_Correcto.Length)];
                        //sonidos.SoundLocation = @"CADENA RECURSOS";
                        //sonidos.Play();
                    }
                    indice++;
                }
            }
            if (confirmacion == "NO")
            {
                if (!existe)
                {
                    vidas = vidas - 1;
                    lb_Vidas.Text = lb_Vidas.Text.Substring(0, lb_Vidas.Text.Length - 1);
                    multiplicador = 1;
                    //sonidos.SoundLocation = @"CADENA RECURSOS";
                    //sonidos.Play();
                    stage += !labels.Any(lbl => lbl.Text == letra_Presionada.Text) ? 1 : 0;
                    ignore = labels.All(lbl => lbl.Text != " ") || stage == vidas;
                    Invalidate();
                }
                else
                {
                    //sonidos.SoundLocation = @"CADENA RECURSOS";
                    //sonidos.Play();
                }
            }
            if (vidas == 0)
            {
                //sonido_Inicio.controls.stop();
                //sonido_Inicio_2.URL = sonido_Perdida[palabra_Aleatoria.Next(sonido_Perdida.Length)];
                DialogResult continuar = MessageBox.Show("PERDIO." + Environment.NewLine + "La palabra era: " + palabra + Environment.NewLine + "DESEA JUGAR OTRA VEZ?", "Aviso", MessageBoxButtons.YesNo);
                if (continuar == DialogResult.Yes)
                {
                    for (int i = 0; i < palara_Escogida_Pantalla.Length; i++)
                    {
                        this.Controls.Remove(palara_Escogida_Pantalla[i]);
                    }
                    score = 0;
                    aciertos = 0;
                    multiplicador = 1;
                    metodo_Vidas();
                    //sonido_Inicio.controls.stop();
                    //sonido_Inicio_2.URL = sonido_Nuevo[palabra_Aleatoria.Next(sonido_Nuevo.Length)];
                    btn_Iniciar_Click(sender, e);
                    string word = "Borrar_Muñeco";
                    foreach (char c in word)
                    {
                        Label lbl = new Label();
                        lbl.Text = " ";
                        lbl.Tag = c.ToString();
                        labels.Add(lbl);
                    }
                    stage = 0;
                    this.Invalidate();
                }
                else
                {
                   try
                   {
                       Application.Exit();
                   }
                    catch
                   {
                       Application.Exit();
                   }
                }
            }
            indice = 0;
            if (aciertos == palabra.Length)
            {
                //sonido_Inicio.controls.stop();
                //sonido_Inicio_2.URL = sonido_Victoria[palabra_Aleatoria.Next(sonido_Victoria.Length)];
                DialogResult continuar = MessageBox.Show("GANO." +  Environment.NewLine + "DESEA JUGAR OTRA VEZ?", "Aviso", MessageBoxButtons.YesNo);
                if (continuar == DialogResult.Yes)
                {
                    for (int i = 0; i < palara_Escogida_Pantalla.Length; i++)
                    {
                        this.Controls.Remove(palara_Escogida_Pantalla[i]);
                    }
                    aciertos = 0;
                    metodo_Vidas();
                    //sonido_Inicio.controls.stop();
                    //sonido_Inicio_2.URL = sonido_Nuevo[palabra_Aleatoria.Next(sonido_Nuevo.Length)];
                    btn_Iniciar_Click(sender, e); string word = "Borrar_Muñeco";
                    foreach (char c in word)
                    {
                        Label lbl = new Label();
                        lbl.Text = " ";
                        lbl.Tag = c.ToString();
                        labels.Add(lbl);
                    }
                    stage = 0;
                    this.Invalidate();
                }
                else
                {
                    try
                    {
                        Application.Exit();
                    }
                    catch
                    {
                        Application.Exit();
                    }
                }
            }
            lb_Score.Text = "Score: " + score.ToString();
            lb_Multiplicador.Text = multiplicador.ToString() + "x";
            lb_Multiplicador.Font = new Font(this.Font.FontFamily, multiplicador * 6 + 10);
        }

        private void creacion_Botones_Abecedario()
        {
            for (int i = 0; i < 26; i++)
            {
                boton_Letra[i] = new Button();
                boton_Letra[i].Top = 400;
                boton_Letra[i].Left = i * 30 + 10;
                boton_Letra[i].Text = Convert.ToChar(65 + i).ToString();
                boton_Letra[i].Size = new Size(30, 30);
                boton_Letra[i].Font = new Font(this.Font.FontFamily, 16);
                boton_Letra[i].Click += new System.EventHandler(letra_Click);
                this.Controls.Add(boton_Letra[i]);
            }
            for (int i = 26; i < 27; i++)
            {
                boton_Letra[i] = new Button();
                boton_Letra[i].Top = 400;
                boton_Letra[i].Left = i * 30 + 10;
                boton_Letra[i].Text = Convert.ToChar(32).ToString();
                boton_Letra[i].Size = new Size(30, 30);
                boton_Letra[i].Font = new Font(this.Font.FontFamily, 16);
                boton_Letra[i].Click += new System.EventHandler(letra_Click);
                this.Controls.Add(boton_Letra[i]);
            }
            for (int i = 0; i < palara_Escogida_Pantalla.Length; i++)
            {
                palara_Escogida_Pantalla[i] = new Label();
            }
        }

        public void escuchar_Servidor_respuesta()
        {
            try
            {
                TcpListener escuchador = new TcpListener(8989);
                escuchador.Start();
                Socket manipuladorSocket = escuchador.AcceptSocket();
                if (manipuladorSocket.Connected)
                {
                    NetworkStream flujoRed = new NetworkStream(manipuladorSocket);
                    int bytesLeidos = 0;
                    int tamanioBloque = 30;
                    Byte[] data = new Byte[tamanioBloque];
                    lock (this)
                    {
                        while (true)
                        {
                            bytesLeidos = flujoRed.Read(data, 0, tamanioBloque);
                            if (bytesLeidos == 0)
                            {
                                break;
                            }
                        }
                    }
                    flujoRed.Flush();
                    lock (this)
                    {
                        confirmacion = Encoding.ASCII.GetString(data);
                    }
                    char[] delimit_1 = new char[] { ':' };
                    string[] vectorLlegada_1 = confirmacion.Split(delimit_1);
                    string longitud_1 = vectorLlegada_1[0];
                    confirmacion = longitud_1;
                }
                escuchador.Stop();
                manipuladorSocket = null;
            }
            catch (Exception)
            {
                //Nada
            }
        }

        private void seleccion_Dificultad()
        {
            if (rb_Facil.Checked == true)
            {
                dificultad = 1;
            }
            if (rb_Medio.Checked == true)
            {
                dificultad = 2;
            }
            if (rb_Dificil.Checked == true)
            {
                dificultad = 3;
            }
        }

        public void escuchar_Servidor()
        {
            try
            {
                TcpListener escuchador = new TcpListener(8080);
                escuchador.Start();
                Socket manipuladorSocket = escuchador.AcceptSocket();
                if (manipuladorSocket.Connected)
                {
                    NetworkStream flujoRed = new NetworkStream(manipuladorSocket);
                    int bytesLeidos = 0;
                    int tamanioBloque = 30;
                    Byte[] data = new Byte[tamanioBloque];
                    lock (this)
                    {
                        while (true)
                        {
                            bytesLeidos = flujoRed.Read(data, 0, tamanioBloque);
                            if (bytesLeidos == 0)
                            {
                                break;
                            }
                        }
                    }
                    flujoRed.Flush();
                    lock (this)
                    {
                        longitud_palabra = Encoding.ASCII.GetString(data);
                    }
                    char[] delimit = new char[] { ':' };
                    string[] vectorLlegada = longitud_palabra.Split(delimit);
                    string longitud = vectorLlegada[0];
                    longitud_palabra = longitud;
                }
                escuchador.Stop();
                manipuladorSocket = null;
            }
            catch (Exception)
            {
                MessageBox.Show("El seridor no se encuentra disponible.");
            }
        }

        private void metodo_lineas()
        {
            palabra = longitud_palabra;
            for (int i = 0; i < palabra.Length; i++)
            {
                palara_Escogida_Pantalla[i].Top = 340;
                palara_Escogida_Pantalla[i].Left = i * 40 + 230;
                palara_Escogida_Pantalla[i].Text = "__";
                palara_Escogida_Pantalla[i].Size = new Size(40, 40);
                palara_Escogida_Pantalla[i].Font = new Font(this.Font.FontFamily, 20);
                this.Controls.Add(palara_Escogida_Pantalla[i]);
            }
        }

        private void metodo_Vidas()
        {
            if (dificultad == 1)
            {
                vidas = 10;
                lb_Vidas.Text = "♥♥♥♥♥♥♥♥♥♥";
            }
            if (dificultad == 2)
            {
                vidas = 8;
                lb_Vidas.Text = "♥♥♥♥♥♥♥♥";
            }
            if (dificultad == 3)
            {
                vidas = 5;
                lb_Vidas.Text = "♥♥♥♥♥";
            }
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            if (txt_Direccion.Text == "" || txt_Puerto.Text == "" || txt_Puerto.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos.");
            }
            else
            {
                try
                {
                    TcpClient cliente = new TcpClient(txt_Direccion.Text, 10000);
                    ASCIIEncoding asen = new ASCIIEncoding();
                    nombre = txt_Usuario.Text;
                    byte[] buffer = asen.GetBytes(nombre + ":" + '*');
                    NetworkStream flujoRed = cliente.GetStream();
                    flujoRed.Write(buffer, 0, buffer.GetLength(0));
                    flujoRed.Close();
                    Thread hiloEscucha = new Thread(new ThreadStart(escuchar_Servidor));
                    hiloEscucha.Start();
                    grupo_Nivel.Enabled = false;
                    grupo_Datos.Enabled = false;
                    btn_Iniciar.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("El Servidor no se encuentra disponible.");
                }
            }
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            TcpClient cliente = new TcpClient(txt_Direccion.Text, 10000);
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] buffer = asen.GetBytes('$' + ":" + '*');
            NetworkStream flujoRed = cliente.GetStream();
            flujoRed.Write(buffer, 0, buffer.GetLength(0));
            flujoRed.Close();
            Thread hiloEscucha = new Thread(new ThreadStart(escuchar_Servidor));
            hiloEscucha.Start();
            //sonido_Inicio.URL = @"CADENA SONIDO";
            pic_Imagen.Image = Image.FromFile(@"CADENA RECURSOS");
            creacion_Botones_Abecedario();
            seleccion_Dificultad();
            metodo_lineas();
            metodo_Vidas();
            lb_Multiplicador.Visible = true;
            btn_Iniciar.Enabled = false;
            pic_Imagen.Visible = true;
            lb_Score.Visible = true;
            lb_Vidas.Visible = true;
            grupo_Datos.Visible = false;
            grupo_Nivel.Visible = false;
            btn_Iniciar.Visible = false;
        }
    }
}