using System;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
namespace winTwoPlays
{
    public class claseSendRecive
    {

        public SerialPort puerto;

        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        public delegate void DelegadoPorcentaje(object oo, float cantidad, float bytes_actuales, float total, int id);
        public event DelegadoPorcentaje PorcentajeImagen;

        public delegate void DelegadoAvisarArchivo(object oo, string ruta);
        public event DelegadoAvisarArchivo AvisarImagen;

        public delegate void DelegadoPorcentajeRecibir(object oo, float cantidad, float bytes_actuales, float total, int id);
        public event DelegadoPorcentajeRecibir PorcentajeImagenRecibir;

        public delegate void DelegadoAvisarForm1(object oo, int archivo_acabo);
        public event DelegadoAvisarForm1 AvisarForm1;


        byte[] TramaEnvio;
        byte[] TramCabaceraEnvio;
        byte[] tramaRelleno;

        byte[] TramaRecibida;

        byte[] TramaCabeceraInfo;
        byte[] TramaInformacion;

        private classArchivo archivoEnviar;
        private classArchivo archivoRecibir;

        private classArchivo[] archivosEnviar;
        private classArchivo[] archivosRecibir;

        private Boolean BufferSalidaVacio;

        Thread procesoVerificaSalida;
        Thread procesoEnviarMensaje;
        Thread procesoEnvioArchivo;

        private readonly object puertoLock = new object();

        private ManualResetEvent enviarInformacionCompleta = new ManualResetEvent(false);

        public claseSendRecive() 
        {
            TramaEnvio = new byte[1024];
            TramCabaceraEnvio = new byte[5];
            tramaRelleno = Enumerable.Repeat((byte)'@', 1024).ToArray();
            TramaRecibida = new byte[1024];

            archivosEnviar = new classArchivo[5];
            archivosRecibir = new classArchivo[5];
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


            Console.WriteLine("Puerto Encendido: " + puerto.PortName);
        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {

            if (puerto.BytesToRead >= 1024)
            {
                //Console.WriteLine("Cantidad de lectura" + puerto.BytesToRead); 

                puerto.Read(TramaRecibida, 0, 1024);  //Leemos lo que se encuentre en el puerto en la trama recibida

                string primer_caracter = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 1);//Identificar que accion se hara

                switch (primer_caracter)
                {
                    case "M":
                        RecibiendoMensaje();
                        break;
                    case "A":
                        ConstruirArchivo(); 
                        break;
                    case "I":
                        InicioConstruirArchivo();
                        break;
                    case "L":
                        AvisarLLegoForm1();
                        break;
                    default:
                        MessageBox.Show("trama no reconocida");
                        break;
                }
            }
        }

        public void AvisarLLegoForm1()
        {

            int orden = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 3, 2));

            Console.WriteLine("se ejecutó el metodo de L");

            archivosEnviar[orden] = null;

            if (AvisarForm1 != null)
            {
                AvisarForm1(this,orden); ////corregimos luegoooooooooo
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
                int LongMensRec = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 4)); // "M0012" -> 5

                string mensaje_recibir = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);   //Extraccion del mensaje

                OnLlegoMensaje(mensaje_recibir);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected virtual void OnLlegoMensaje(string mensaje_recibir)
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, mensaje_recibir);
        }

        protected virtual void porcentajeImagen(float cantidad,float bytes_actuales,float total,int id)
        {
            if(PorcentajeImagen != null)
            {
                PorcentajeImagen(this, cantidad,bytes_actuales,total,id);
            }
        }

        protected virtual void avisarImagen(string ruta)
        {
            if (AvisarImagen != null)
                AvisarImagen(this, ruta);
        }

        protected virtual void porcentajeImagenRecibir(float cantidad, float bytes_actuales, float total,int id)
        {
            if (PorcentajeImagenRecibir != null)
            {
                PorcentajeImagenRecibir(this, cantidad, bytes_actuales, total,id);
            }
        }

        private void VerificandoSalida()
        {
            while (puerto.IsOpen)
            {
                BufferSalidaVacio = puerto.BytesToWrite > 0 ?  false :  true;
            }
        }


        public void IniciaEnvioArchivo(String rutita,int id, int orden) //ruta y 1
        {
            try
            {
                byte[] bytesImagen = File.ReadAllBytes(rutita);  //Obtenemos los bytes del archivo de la ruta puesta
                string nombre = rutita.Split('.')[0];
                string extension = rutita.Split('.')[1];
                string rutitaf = $"{nombre}{id}.{extension}";

                archivoEnviar = new classArchivo(rutitaf, bytesImagen, 0 , id, orden);

                archivosEnviar[orden] = archivoEnviar; //

                enviarInformacion(id,orden); // informacion del archivo

                procesoEnvioArchivo = new Thread(()=> EnviandoArchivo(id,orden));
                procesoEnvioArchivo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enviarInformacion(int id, int orden)//  "I-0001200000-011-pollito1.txt-0001"  
        {
            try
            {
                //classArchivo archivo_enviar = buscarArchivo(id, archivosEnviar);

                int tama = archivosEnviar[orden].bytes.Length;                                  // Tamaño de la imagen:  2050

                string palabra_extension = Path.GetFileName(archivosEnviar[orden].Nombre);      // pollito1.txt 

                int tama_virtual = Convert.ToString(tama).Length;                       // "2050"  -> 4

                string info = ConstruirCabecera("I", tama, 10);                         //"I0000002050"

                int tama_extension = palabra_extension.Length;                          //  pollito.txt  -> 11

                info += tama_extension.ToString("D3") + palabra_extension + id.ToString("D2") + orden.ToString("D2");      // 0001        //"I0000002050" - "011" - "pollito.txt"

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnviandoArchivo(int Id, int orden)
        {
            try
            {
                enviarInformacionCompleta.WaitOne();    //Esperamos a que se envie la informacion para poder continuar

                byte[] TramCabaceraEnvioArchivo = new byte[5];

                //classArchivo archivo_enviar = buscarArchivo(Id, archivosEnviar);

                TramCabaceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes($"A{Id.ToString("D2")}{orden.ToString("D2")}");

                int tamaño_imagen = archivosEnviar[orden].bytes.Length;

                int cantidad_exacta = 1019 * ((int)(tamaño_imagen / 1019)); //

                for (int i = 0; i < tamaño_imagen; i += 1019) //0, 1019, 2038
                {
                    int size = Math.Min(1019, archivosEnviar[orden].bytes.Length - i); // 1019,2

                    byte[] TramaEnvio2 = Enumerable.Repeat((byte)'@', 1019).ToArray();//Rellena todo el arreglo con @

                    archivosEnviar[orden].Avance += size;

                    Array.Copy(archivosEnviar[orden].bytes, i, TramaEnvio2, 0, size);

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
                            porcentajeImagen(100, archivosEnviar[orden].Avance, tamaño_imagen, orden);
                        }
                        else
                        {
                            porcentajeImagen(0, 0, tamaño_imagen, orden);  // Delegado para mostrar el porcentaje de la imagen enviada 
                        }

                    }
                    else
                    {
                        porcentajeImagen(((float)i / (float)cantidad_exacta) * 100, archivosEnviar[orden].Avance, tamaño_imagen,orden); // Delegado para mostrar el porcentaje de la imagen enviada
                    }

                }
                //MessageBox.Show("Archivo enviado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void InicioConstruirArchivo()
        {
            try
            {
                //I0123456789 - 011 - pollito1.txt - 0001
                int peso_imagen = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 10));  //  0123456789

                int longitud_extension = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 11, 3));  // 004

                string name_archivo = ASCIIEncoding.UTF8.GetString(TramaRecibida, 14, longitud_extension);  // pollito.txt

                int Id = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 14 + longitud_extension, 2)); // 0001

                int orden = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 16 + longitud_extension, 2));

                byte[] bytes = new byte[peso_imagen];

                Console.WriteLine("Peso imagen : "+ peso_imagen);

                String ruta_temp = $"E:/Probando/Recibir/{name_archivo}";  // Ruta en la que vamos a Guardar el archivo

                if (File.Exists(ruta_temp))
                {
                    File.Delete(ruta_temp); // Evitamos problemas de sobreescritura 
                }

                //pollito1.txt pollito2.txt luis3.txt  pollito4.txt aea5.txt

                //pollito.txt pollito1.txt luis.txt pollito2.txt aea.txt

                archivoRecibir = new classArchivo(ruta_temp, bytes, 0, Id,orden);
                //archivoRecibir.iniciarFlujo();
                archivosRecibir[orden] = archivoRecibir;
                archivosRecibir[orden].iniciarFlujo();

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
                int id = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 2)); // 0001
                int orden = Convert.ToInt32(ASCIIEncoding.UTF8.GetString(TramaRecibida, 3, 2));
                //classArchivo archivo_recibir = buscarArchivo(id, archivosRecibir);

                //pollito1.txt //pollito2.txt

                int bytesRestantes = archivosRecibir[orden].bytes.Length - archivosRecibir[orden].Avance;

                if (bytesRestantes > 1019)
                {
                    archivosRecibir[orden].EscribiendoArchivo.Write(TramaRecibida, 5, 1019);//Llenamos los datos del archivo que se esta pasando
                    archivosRecibir[orden].Avance += 1019;
                    porcentajeImagenRecibir(((float)archivosRecibir[orden].Avance / (float)archivosRecibir[orden].bytes.Length) * 100, archivosRecibir[orden].Avance, archivosRecibir[orden].bytes.Length, orden);

                }
                else
                {
                    archivosRecibir[orden].EscribiendoArchivo.Write(TramaRecibida, 5, bytesRestantes); //Lenamos los ultimos datos del archivo
                    archivosRecibir[orden].Avance += bytesRestantes;

                    porcentajeImagenRecibir(((float)archivosRecibir[orden].Avance / (float)archivosRecibir[orden].bytes.Length) * 100, archivosRecibir[orden].Avance, archivosRecibir[orden].bytes.Length, orden);

                    avisarImagen(archivosRecibir[orden].Nombre);            //cuando se termina se activa el delegado para enviar la ruta al frame

                    archivosRecibir[orden].EscribiendoArchivo.Close();
                    archivosRecibir[orden].FlujoArchivoRecibir.Close();

                    //envio de la trama que indica construccion total del archivo

                    byte[] tramaAvisar = ASCIIEncoding.UTF8.GetBytes($"L{id.ToString("D2")}{orden.ToString("D2")}"); 
                    byte[] tramax = Enumerable.Repeat((byte)'@', 1024).ToArray();

                    Array.Copy(tramaAvisar, 0, tramax, 0, tramaAvisar.Length);

                    Thread procesoEnviarAcabo = new Thread(() =>
                    {
                        try
                        {
                            lock (puertoLock)
                            {
                                puerto.Write(tramax, 0, tramax.Length);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error en enviandoInformacion: {ex.Message}");
                        }
                    });
                    procesoEnviarAcabo.Priority = ThreadPriority.Highest;
                    procesoEnviarAcabo.Start();
                    archivosRecibir[orden] = null;
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error 1: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 2: " + ex.Message);
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
            return identificador + longitud.ToString($"D{cantidad}"); //d4
            // "M0080"
            // formato de 4 dig 0112
        }

    }
}
