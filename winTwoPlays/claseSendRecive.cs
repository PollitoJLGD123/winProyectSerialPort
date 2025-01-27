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

        public delegate void DelegadoLLegoArchivo(object oo,Boolean llego);
        public event DelegadoLLegoArchivo LlegoImagen;

        public delegate void DelegadoPorcentaje(object oo, float cantidad, float bytes_actuales, float total);
        public event DelegadoPorcentaje PorcentajeImagen;

        public delegate void DelegadoAvisarArchivo(object oo, string ruta);
        public event DelegadoAvisarArchivo AvisarImagen;


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

                puerto.Read(TramaRecibida, 0, 1024);  //Leemos lo que se encuentre en el puerto en la trama recibida

                string primer_caracter = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 1);//Identificar que accion se hara

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
                    puerto.Write(TramaEnvio, 0, TramaEnvio.Length);  //Contenido
                    puerto.Write(tramaRelleno, 0, 1019 - TramaEnvio.Length);  //Relleno para asegurar el disparador
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
                int LongMensRec = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 4)); // "0005" -> 5

                mensaje_recibir = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);   //Extraccion del mensaje

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

        protected virtual void OnLlegoImagen(Boolean llego)
        {
            if (LlegoImagen != null)
                LlegoImagen(this, llego);
        }
        protected virtual void porcentajeImagen(float cantidad,float bytes_actuales,float total)
        {
            if(PorcentajeImagen != null)
            {
                PorcentajeImagen(this, cantidad,bytes_actuales,total);
            }
        }

        protected virtual void avisarImagen(string ruta)
        {
            if (AvisarImagen != null)
                AvisarImagen(this, ruta);
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
                byte[] bytesImagen = File.ReadAllBytes(rutita);  //Obtenemos los bytes del archivo de la ruta puesta       
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
                enviarInformacionCompleta.WaitOne();    //Esperamos a que se envie la informacion para poder continuar

                byte[] TramCabaceraEnvioArchivo = new byte[5];

                TramCabaceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("A0001");

                int tamaño_imagen = archivoEnviar.bytes.Length;

                int cantidad_exacta = 1019 *  ((int)( tamaño_imagen / 1019));

                for (int i = 0; i < tamaño_imagen; i += 1019)
                {
                    int size = Math.Min(1019, archivoEnviar.bytes.Length - i);

                    byte[] TramaEnvio2 = Enumerable.Repeat((byte)'@', 1019).ToArray();//Rellena todo el arreglo con @

                    archivoEnviar.Avance += size;

                    Array.Copy(archivoEnviar.bytes, i, TramaEnvio2, 0, size);

                    while (BufferSalidaVacio == false)
                    {
                        //esperamos a q el buffer se vacie, para evitar sobreescritura
                    }
                    lock (puertoLock)
                    {
                        puerto.Write(TramCabaceraEnvioArchivo, 0, 5); // Cabecera -> A0001
                        puerto.Write(TramaEnvio2, 0, 1019);            // Contenido, AQUI ACTIVA EL DISPARADOR LLEVANDONOS AL: CONSTRUIRARHCIVO
                    }

                    if (i == 0)
                    {
                        if (tamaño_imagen < 1019)
                        {
                            porcentajeImagen(100, archivoEnviar.Avance, tamaño_imagen);
                        }
                        else
                        {
                            porcentajeImagen(0, 0, tamaño_imagen);  // Delegado para mostrar el porcentaje de la imagen enviada 
                        }     
                        
                    }
                    else
                    {
                        porcentajeImagen(((float) i / (float)cantidad_exacta) * 100, archivoEnviar.Avance, tamaño_imagen); // Delegado para mostrar el porcentaje de la imagen enviada
                    }

                }
                OnLlegoImagen(true);
                MessageBox.Show("Archivo enviado correctamente.");
            }
            catch(Exception ex)
            {
                OnLlegoImagen(false);
                MessageBox.Show(ex.Message);
            }
        }

        public void InicioConstruirArchivo()
        {
            try
            {
                //"I0123456789 - 011 - pollito.txt
                int peso_imagen = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 10));  //  0000002050 -> 2050

                int longitud_extension = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 11, 3));  // 004

                string name_archivo = ASCIIEncoding.UTF8.GetString(TramaRecibida, 14, longitud_extension);  // .txt  .pdf  .docx

                byte[] bytes = new byte[peso_imagen];

                Console.WriteLine("Peso imagen : "+ peso_imagen);

                String ruta_temp = $"D:/ZZZ{name_archivo}";  // Ruta en la que vamos a Guardar el archivo

                if (File.Exists(ruta_temp))
                {
                    File.Delete(ruta_temp); // Evitamos problemas de sobreescritura
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
                    EscribiendoArchivo.Write(TramaRecibida, 5, 1019);//Llenamos los datos del archivo que se esta pasando
                    archivoRecibir.Avance += 1019;                    
                }
                else
                {
                    EscribiendoArchivo.Write(TramaRecibida, 5, bytesRestantes); //Lenamos los ultimos datos del archivo
                    archivoRecibir.Avance += bytesRestantes;

                    avisarImagen(archivoRecibir.Nombre);            //cuando se termina se activa el delegado para enviar la ruta al frame

                    EscribiendoArchivo.Close();
                    FlujoArchivoRecibir.Close();
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error 1: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                OnLlegoImagen(false);
                MessageBox.Show("Error 2: " + ex.Message);
            }
        }

        private void enviarInformacion()//  I (TIPO)- 0123456789 (TAMAÑO) - RELLENO
        {
            try
            {
                int tama = archivoEnviar.bytes.Length;                                  // Tamaño de la imagen:  2050

                string palabra_extension = Path.GetFileName(archivoEnviar.Nombre);      // .txt  .pdf .docx

                int tama_virtual = Convert.ToString(tama).Length;                       // "2050"  -> 4
                
                string info = ConstruirCabecera("I", tama, 10);                         //"I0000002050"

                int tama_extension = palabra_extension.Length;                          // ".txt" -> 4

                info += tama_extension.ToString("D3") + palabra_extension;              //"I0000002050" - "011" - ".txt"

                TramaCabeceraInfo = ASCIIEncoding.UTF8.GetBytes(info);

                TramaInformacion = Enumerable.Repeat((byte)'@', 1024).ToArray(); 

                Array.Copy(TramaCabeceraInfo, 0, TramaInformacion, 0, info.Length);


                Thread procesoEnviarInformacion = new Thread(() =>
                {
                    try
                    {
                        lock (puertoLock)
                        {
                            puerto.Write(TramaInformacion, 0, 1024); //ACTIVA EL DISPARADOR LO QUE NOS LLEVA A: INICIOCONSTRUIRARHCIVO
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
