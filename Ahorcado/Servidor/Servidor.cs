using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using System;

namespace Servidor
{
    public partial class Servidor : Form
    {
        delegate void ActualizarListBoxCallback(string texto);
        string[] palabra_Escogida = new string[110000];
        Random palabra_Aleatoria = new Random();
        private ArrayList Puertos;
        string palabra_escogida;
        IPAddress direccionIP;
        string nombre_cliente;
        string palabra_enviar;
        int posicion_palabra;
        int longitud_palabra;
        string confirmacion;
        string palabra;
        int x = 0;

        public Servidor()
        {
            InitializeComponent();
        }

        private void Servidor_Load(object sender, EventArgs e)
        {
            lst_Clientes.Items.Add("Esperando Clientes...");
            IPAddress[] direccionesIP = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress direccionServidor = direccionesIP[0];
            foreach (IPAddress ip in direccionesIP)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (!ip.Equals("127.0.0.1"))
                    {
                        direccionServidor = ip;
                    }
                }
            }
            direccionIP = IPAddress.Parse(direccionServidor.ToString());
            lbl_Servidor.Text = "Direccion_IP_Servidor: " + direccionServidor;
            Puertos = new ArrayList();
            Thread hiloEscucha = new Thread(new ThreadStart(escuchar_Cliente));
            hiloEscucha.Start();
            Thread hiloEscucha_respuesta = new Thread(new ThreadStart(escuchar_Cliente_Respuesta));
            hiloEscucha_respuesta.Start();
        }

        private void ActualizarListBox_Clientes(string texto)
        {
            x++;
            if (x == 1)
            {
                lst_Clientes.Items.Add("Cliente: " + texto + " se ha unido");
            }
        }

        private void ActualizarListBox_Mensajes(string texto)
        {
            lst_Clientes.Items.Add(texto);
        }

        public void manipulacion_Hilo_Respuesta()
        {
            Socket manipuladorSocket = (Socket)Puertos[Puertos.Count - 1];
            NetworkStream flujoRed_Principal = new NetworkStream(manipuladorSocket);
            int bytesLeidos = 0;
            int tamanioBloque = 1024;
            Byte[] data_2 = new Byte[tamanioBloque];
            lock (this)
            {
                while (true)
                {
                    try
                    {
                        bytesLeidos = flujoRed_Principal.Read(data_2, 0, tamanioBloque);
                        if (bytesLeidos == 0)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Se ha producido un error...");
                    }
                }
                string recibido = Encoding.ASCII.GetString(data_2);
                TcpClient cliente_2 = new TcpClient(obtenerIP(manipuladorSocket), 8989);
                ASCIIEncoding asen= new ASCIIEncoding();
                string comprobar_letra = comprobacion_letra(recibido);
                char letra_2 = comprobar_letra[0];
                switch (letra_2)
                {
                    case '&':
                        {
                            confirmacion = "OK";
                            break;
                        }
                    case '%':
                        {
                            confirmacion = "NO";
                            break;
                        }
                }
                string respuesta_letra = confirmacion;
                byte[] outStream_2 = asen.GetBytes(respuesta_letra + ":");
                NetworkStream flujoRed_2 = cliente_2.GetStream();
                flujoRed_2.Write(outStream_2, 0, outStream_2.GetLength(0));
                flujoRed_2.Close();
                manipuladorSocket = null;
                flujoRed_Principal.Close();
            }
            if (this.lst_Clientes.InvokeRequired)
            {
                lst_Clientes.Invoke(new ActualizarListBoxCallback(this.ActualizarListBox_Mensajes),
                            new object[] { "Se recibio la letra correctamente..." });
            }
            manipuladorSocket = null;
        }
         
        public void escuchar_Cliente()
        {
            TcpListener escuchador = new TcpListener(direccionIP, 10000);
            escuchador.Start();
            while (true)
            {
                Socket manipuladorSocket = escuchador.AcceptSocket();
                if (manipuladorSocket.Connected)
                {
                    if (this.lst_Clientes.InvokeRequired)
                    {
                        lst_Clientes.Invoke(new ActualizarListBoxCallback(this.ActualizarListBox_Clientes), new object[] { nombre_cliente });
                        lock (this)
                        {
                            Puertos.Add(manipuladorSocket);
                        }
                        ThreadStart manipuladorInicialHilo = new ThreadStart(manipulacion_Hilo);
                        Thread manipuladorHilo = new Thread(manipuladorInicialHilo);
                        manipuladorHilo.Start();
                    }
                }
            }
        }

        public void escuchar_Cliente_Respuesta()
        {
            TcpListener escuchador = new TcpListener(direccionIP, 12345);
            escuchador.Start();
            while (true)
            {
                Socket manipuladorSocket = escuchador.AcceptSocket();
                if (manipuladorSocket.Connected)
                {
                    if (this.lst_Clientes.InvokeRequired)
                    {
                        lst_Clientes.Invoke(new ActualizarListBoxCallback(this.ActualizarListBox_Clientes), new object[] { nombre_cliente });
                        lock (this)
                        {
                            Puertos.Add(manipuladorSocket);
                        }
                        ThreadStart manipuladorInicialHilo = new ThreadStart(manipulacion_Hilo_Respuesta);
                        Thread manipuladorHilo = new Thread(manipuladorInicialHilo);
                        manipuladorHilo.Start();
                    }
                }
            }
        }

        public void manipulacion_Hilo()
        {
            metodo_seleccionador_Palabra();
            Socket manipuladorSocket = (Socket)Puertos[Puertos.Count - 1];
            NetworkStream flujoRed_Principal = new NetworkStream(manipuladorSocket);
            int bytesLeidos = 0;
            int tamanioBloque = 1024;
            Byte[] data = new Byte[tamanioBloque];
            lock (this)
            {
                while (true)
                {
                    try
                    {
                        bytesLeidos = flujoRed_Principal.Read(data, 0, tamanioBloque);
                        if (bytesLeidos == 0)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Se ha producido un error...");
                    }
                }
                string recibido = Encoding.ASCII.GetString(data);
                TcpClient cliente = new TcpClient(obtenerIP(manipuladorSocket), 8080);
                ASCIIEncoding asen = new ASCIIEncoding();
                string iniciar_Juego = iniciar_Partida(recibido);
                char letra = iniciar_Juego[0];
                switch (letra)
                {
                    case '$':
                        {
                            longitud_palabra = palabra_enviar.Length;
                            palabra_escogida = palabra_enviar;
                            break;
                        }
                }
                string respuestaDelServidor = palabra_escogida;
                byte[] outStream = asen.GetBytes(respuestaDelServidor + ":");
                NetworkStream flujoRed = cliente.GetStream();
                flujoRed.Write(outStream, 0, outStream.GetLength(0));
                flujoRed.Close();
                manipuladorSocket = null;
                flujoRed_Principal.Close();
            }
            manipuladorSocket = null;
        }

        public string obtenerIP(Socket socketCliente)
        {
            char[] delimit = new char[] { ':' };
            string direccionSocket = socketCliente.RemoteEndPoint.ToString();
            string[] substr = direccionSocket.Split(delimit);
            string ipCliente = substr[0];
            return ipCliente;
        }

        private string ObternerNombreCliente(string nombre)
        {
            char[] delimit = new char[] { ':' };
            string[] substr = nombre.Split(delimit);
            string idDelCliente = substr[0].ToString();
            nombre_cliente = nombre;
            return nombre;
        }

        private string iniciar_Partida(string respuestaDelCliente)
        {
            char[] delimit = new char[] { ':' };
            string[] substr = respuestaDelCliente.Split(delimit);
            string idDelCliente = substr[0].ToString();
            return idDelCliente;
        }

        private void metodo_seleccionador_Palabra()
        {
            FileStream fs = new FileStream(@"CADENA RECURSOS", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            int k = 0;
            while (!sr.EndOfStream)
            {
                palabra_Escogida[k] = sr.ReadLine();
                k++;
            }
            posicion_palabra = palabra_Aleatoria.Next(0, k);
            palabra = palabra_Escogida[posicion_palabra];
            palabra_enviar = palabra;
            longitud_palabra = palabra.Length;
            fs.Close();
        }

        private string comprobacion_letra(string letra_recibida)
        {
            char[] delimit = new char[] { ':' };
            string[] substr = letra_recibida.Split(delimit);
            string idDelCliente = substr[0].ToString();
            if (palabra_enviar.Contains(idDelCliente))
            {
                return "&";
            }
            else
            {
                return "%";
            }
        }
    }
}