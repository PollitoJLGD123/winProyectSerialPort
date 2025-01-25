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

            //BufferSalidaVacio = true;
            //procesoVerificaSalida = new Thread(VerificandoSalida);
            //procesoVerificaSalida.Start();

            //arhivoEnviar = new classArchivo();
            //arhivoRecibir = new classArchivo();

            MessageBox.Show("Puerto Encendido: " + puerto.PortName);

        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {

        }

        public void enviarMensaje(string message)
        {

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
