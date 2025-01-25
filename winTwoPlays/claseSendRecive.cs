using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace winTwoPlays
{
    public class claseSendRecive
    {

        private SerialPort puerto;

        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        byte[] TramaEnvio;
        byte[] TramCabaceraEnvio;
        byte[] tramaRelleno;

        byte[] TramaRecibida;

        private classArchivo arhivoEnviar;
        private FileStream FlujoArchivoEnviar;
        private BinaryReader LeyendoArchivo;


        private classArchivo arhivoRecibir;
        private FileStream FlujoArchivoRecibir;
        private BinaryWriter EscribiendoArchivo;

        private Boolean BufferSalidaVacio;


        Thread procesoVerificaSalida;
        Thread procesoEnviarMensaje;
        Thread procesoRecibirMensaje;

        String mensaje_recibir;

        public claseSendRecive() 
        {
            TramaEnvio = new byte[1024];
            TramCabaceraEnvio = new byte[5];
            tramaRelleno = new byte[1024];

            TramaRecibida = new byte[1024];

            for (int i = 0; i <= 1023; i++)
            { tramaRelleno[i] = 64; }
        }

        public void Inicializar(string nombrePuerto,int baud,int data_bits, 
            StopBits stop_bits, Parity parity_bits)
        {
            puerto = new SerialPort(nombrePuerto, baud, parity_bits, data_bits, stop_bits);
            puerto.ReceivedBytesThreshold = 1024;
            puerto.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            puerto.Open();

            BufferSalidaVacio = true;
            //procesoVerificaSalida = new Thread(VerificandoSalida);
            //procesoVerificaSalida.Start();

            arhivoEnviar = new classArchivo();
            arhivoRecibir = new classArchivo();

            MessageBox.Show("Puerto Encendido: " + puerto.PortName);
        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {
            if (puerto.BytesToRead >= 1024)
            {
                puerto.Read(TramaRecibida, 0, 1024);

                string TAREA = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 1);

                switch (TAREA)
                {
                    case "M":
                        procesoRecibirMensaje = new Thread(RecibiendoMensaje);
                        procesoRecibirMensaje.Start();
                        break;

                    case "A":
                        //procesoConstruyeArchivo = new Thread(ConstruirArchivo);
                        //.Start();
                        //ConstruirArchivo();
                        break;
                    case "I":
                        break;
                    default:
                        MessageBox.Show("trama no reconocida");
                        break;
                }
            }
        }

        public void enviarMensaje(string message)
        {
            string lreal = message.Length.ToString();
            string longMenString = "";

            Console.WriteLine(message);
            Console.WriteLine(lreal);

            TramaEnvio = ASCIIEncoding.UTF8.GetBytes(message);

            // message = pollito123 -> 10 caracteres (pero el numero es 2 contando la longitud del numero 10
            //                                          como string)

            Console.WriteLine(TramaEnvio);

            if (lreal.Length == 1)
                longMenString = "M000" + message.Length.ToString();
            if (lreal.Length == 2)
                longMenString = "M00" + message.Length.ToString();
            if (lreal.Length == 3)
                longMenString = "M0" + message.Length.ToString();

            Console.WriteLine(longMenString);

            TramCabaceraEnvio = ASCIIEncoding.UTF8.GetBytes(longMenString);

            procesoEnviarMensaje = new Thread(MetodoEnviando);
            procesoEnviarMensaje.Start();
        }

        private void MetodoEnviando()
        {
            puerto.Write(TramCabaceraEnvio, 0, 5);
            puerto.Write(TramaEnvio, 0, TramaEnvio.Length);
            puerto.Write(tramaRelleno, 0, 1019 - TramaEnvio.Length);
        }

        private void RecibiendoMensaje()
        {
            string cabecera_mensaje = ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 4);
            //M - 000L
            //M - 00LL
            //M - 0LLL
            int LongMensRec = Convert.ToInt16(cabecera_mensaje);

            mensaje_recibir = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);
            //mensaje como tal

            OnLlegoMensaje();

        }

        protected virtual void OnLlegoMensaje()
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, mensaje_recibir);
        }

        private void VerificandoSalida()
        {
            while (true)
            {
                if (puerto.BytesToWrite > 0)
                    BufferSalidaVacio = false;
                else
                    BufferSalidaVacio = true;
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

    }
}
