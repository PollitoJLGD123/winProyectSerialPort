using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace winTwoPlays
{
    internal class claseSendRecive
    {

        private SerialPort puerto;

        public claseSendRecive() 
        { 

        }

        public void Inicializar(string nombrePuerto)
        {
            puerto = new SerialPort(nombrePuerto, 57600, Parity.Even, 8, StopBits.Two);
            puerto.ReceivedBytesThreshold = 1024; //bytes del bufer de entrada
            puerto.DataReceived += new SerialDataReceivedEventHandler(dataReceived);


        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {

        }

        public void enviarMensaje(string message)
        {

        }


    }
}
