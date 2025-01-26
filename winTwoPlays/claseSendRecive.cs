using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace winTwoPlays
{
    public class claseSendRecive
    {

        public SerialPort puerto;

        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        byte[] TramaEnvio;
        byte[] TramCabaceraEnvio;
        byte[] tramaRelleno;

        byte[] TramaRecibida;

        byte[] TramaCabeceraInfo;
        byte[] TramaInformacion;

        private classArchivo archivoEnviar;


        private classArchivo archivoRecibir;
        private FileStream FlujoArchivoRecibir;
        private BinaryWriter EscribiendoArchivo;

        private Boolean BufferSalidaVacio;


        Thread procesoVerificaSalida;
        Thread procesoEnviarMensaje;
        Thread procesoRecibirMensaje;

        Thread procesoEnvioArchivo;
        Thread procesoConstruyeArchivo;

        String mensaje_recibir;

        private readonly object puertoLock = new object();

        private ManualResetEvent enviarInformacionCompleta = new ManualResetEvent(false);

        public claseSendRecive() 
        {
            TramaEnvio = new byte[1024];
            TramCabaceraEnvio = new byte[5];
            tramaRelleno = Enumerable.Repeat((byte)'@', 1024).ToArray();
            TramaRecibida = new byte[1024];
        }

        public void Inicializar(string nombrePuerto,int baud,int data_bits, 
            StopBits stop_bits, Parity parity_bits)
        {
            puerto = new SerialPort(nombrePuerto, baud, parity_bits, data_bits, stop_bits);
            puerto.ReceivedBytesThreshold = 1024;
            //puerto.ReadBufferSize = 4096; // Tamaño del buffer de lectura
            //puerto.WriteBufferSize = 4096; // Tamaño del buffer de escritura

            puerto.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            puerto.Open();

            BufferSalidaVacio = true;
            procesoVerificaSalida = new Thread(VerificandoSalida);
            procesoVerificaSalida.Start();


            MessageBox.Show("Puerto Encendido: " + puerto.PortName);
        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {

            if (puerto.BytesToRead >= 1024)
            {
                Console.WriteLine("Cantidad de lectura" + puerto.BytesToRead);

                puerto.Read(TramaRecibida, 0, 1024);

                string primer_caracter = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 1);

                Console.WriteLine("Sobra esto" + puerto.BytesToRead);

                switch (primer_caracter)
                {
                    case "M":
                        procesoRecibirMensaje = new Thread(RecibiendoMensaje);
                        procesoRecibirMensaje.Start();
                        break;
                    case "A":
                        ConstruirArchivo();
                        break;
                    case "I":
                        InicioConstruirArchivo();
                        break;
                    default:
                        MessageBox.Show("trama no reconocida");
                        break;
                }
            }
        }

        public void enviarMensaje(string message)
        {
            try
            {
                string longMessageString = ConstruirCabecera("M",message.Length,4);

                TramCabaceraEnvio = ASCIIEncoding.UTF8.GetBytes(longMessageString);

                TramaEnvio = ASCIIEncoding.UTF8.GetBytes(message);

                procesoEnviarMensaje = new Thread(MetodoEnviando);
                procesoEnviarMensaje.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void MetodoEnviando()
        {
            try
            {
                lock (puertoLock)
                {
                    puerto.Write(TramCabaceraEnvio, 0, 5);
                    puerto.Write(TramaEnvio, 0, TramaEnvio.Length);
                    puerto.Write(tramaRelleno, 0, 1019 - TramaEnvio.Length);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RecibiendoMensaje()
        {

            try
            { // 0 1 2 3 4 5 6 7 8
                string cabecera_mensaje = ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 4);
                int LongMensRec = Convert.ToInt32(cabecera_mensaje);

                mensaje_recibir = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);

                OnLlegoMensaje();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected virtual void OnLlegoMensaje()
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, mensaje_recibir);
        }

        private void VerificandoSalida()
        {
            while (puerto.IsOpen)
            {
                BufferSalidaVacio = puerto.BytesToWrite > 0 ?  false :  true;
            }
        }


        public void IniciaEnvioArchivo(String rutita)
        {
            try
            {
                byte[] bytesImagen = File.ReadAllBytes(rutita);
                archivoEnviar = new classArchivo(rutita, bytesImagen, 0);

                enviarInformacion();

                procesoEnvioArchivo = new Thread(EnviandoArchivo);
                procesoEnvioArchivo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnviandoArchivo()
        {
            try
            {
                int Z = 0;
                enviarInformacionCompleta.WaitOne();
                
                byte[] TramCabaceraEnvioArchivo = new byte[5];

                TramCabaceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("A0001");

                int chunkSize = 1019;

                for (int i = 0; i < archivoEnviar.bytes.Length; i += chunkSize)
                {
                    int size = Math.Min(chunkSize, archivoEnviar.bytes.Length - i);

                    byte[] TramaEnvio2 = Enumerable.Repeat((byte)'@', chunkSize).ToArray();

                    Array.Copy(archivoEnviar.bytes, i, TramaEnvio2, 0, size);

                    while (BufferSalidaVacio == false)
                    {//esperamos
                    }
                    lock (puertoLock)
                    {
                        puerto.Write(TramCabaceraEnvioArchivo, 0, 5); // "A0001"
                        puerto.Write(TramaEnvio2, 0, 1019);            // 012345

                        Z += puerto.BytesToRead;
                    }

                    Console.WriteLine("Dentro:" + Z);
                }
                Console.WriteLine("Fuera: " + Z);
                MessageBox.Show("Archivo enviado correctamente.");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InicioConstruirArchivo()
        {
            try
            {

                string cabecera_info = ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 7); //"I0021101 2 .TXT

                int longitud_extension = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 8, 1));

                string extension = ASCIIEncoding.UTF8.GetString(TramaRecibida, 9, longitud_extension);

                int peso_imagen = Convert.ToInt32(cabecera_info);

                byte[] bytes = new byte[peso_imagen];

                Console.WriteLine("Peso imagen : "+ peso_imagen);

                String ruta_temp = $"E:/Probando/Recibir/archivo_8{extension}";

                if (File.Exists(ruta_temp))
                {
                    File.Delete(ruta_temp);
                }

                FlujoArchivoRecibir = new FileStream(ruta_temp, FileMode.Create, FileAccess.Write);
                EscribiendoArchivo = new BinaryWriter(FlujoArchivoRecibir);
                archivoRecibir = new classArchivo(ruta_temp, bytes, 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConstruirArchivo()
        {
            try
            {
                int bytesRestantes = archivoRecibir.bytes.Length - archivoRecibir.Avance;

                if (bytesRestantes > 1019)
                {
                    EscribiendoArchivo.Write(TramaRecibida, 5, 1019);
                    archivoRecibir.Avance += 1019;
                }
                else
                {
                    EscribiendoArchivo.Write(TramaRecibida, 5, bytesRestantes);
                    archivoRecibir.Avance += bytesRestantes;

                    MessageBox.Show("Se acabo de construir el archivo");
                    EscribiendoArchivo.Close();
                    FlujoArchivoRecibir.Close();
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error al escribir el archivo: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void enviarInformacion()
        {
            try
            {
                int tama = archivoEnviar.bytes.Length;

                string extension = Path.GetExtension(archivoEnviar.Nombre); //.txt 3

                //"I0000120 - 4 - .txt

                int tama_virtual = Convert.ToString(tama).Length;
                string info = ConstruirCabecera("I", tama, 7);

                int tama_extension = extension.Length;

                info += Convert.ToString(tama_extension) + extension; 

                TramaCabeceraInfo = ASCIIEncoding.UTF8.GetBytes(info);

                TramaInformacion = Enumerable.Repeat((byte)'@', 1024).ToArray(); 

                Array.Copy(TramaCabeceraInfo, 0, TramaInformacion, 0, info.Length);


                Thread procesoEnviarInformacion = new Thread(() =>
                {
                    try
                    {
                        lock (puertoLock)
                        {
                            puerto.Write(TramaInformacion, 0, 1024);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error en enviandoInformacion: {ex.Message}");
                    }
                });

                procesoEnviarInformacion.Start();
                enviarInformacionCompleta.Set();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Boolean EstaAbierto()
        {
            return puerto.IsOpen;
        }

        public void cerrarPuerto()
        {
            puerto.Close();
        }

        private string ConstruirCabecera(string identificador, int longitud,int cantidad)
        {
            return identificador + longitud.ToString($"D{cantidad}"); 
            // formato de 4 dig 0112
        }

    }
}
