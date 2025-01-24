using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace winTwoPlays
{
    internal class claseSendRecive
    {

        private SerialPort puerto;
        byte[] tramaContenido, tramaRelleno, tramaCabecera;
        private string mensRecibido;
        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        public claseSendRecive() 
        { 

        }

        public void Inicializar(string nombrePuerto)
        {
            puerto = new SerialPort(nombrePuerto, 57600, Parity.Even, 8, StopBits.Two);
            //puerto.ReceivedBytesThreshold = 100; //bytes del bufer de entrada
            puerto.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            puerto.Open();
        }

        private void dataReceived(object o, SerialDataReceivedEventArgs sd)
        {
            mensRecibido = puerto.ReadExisting();
            MessageBox.Show(mensRecibido);
        }

        protected virtual void OnLlegoMensaje()
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, mensRecibido);
        }

        public void enviarMensaje(string message)
        {
            puerto.ReceivedBytesThreshold = message.Length;
            //MessageBox.Show(message);
            byte[] tramaContenidoMensaje = new byte[message.Length-1];
            int longitud = message.Length;
            tramaContenidoMensaje = ASCIIEncoding.UTF8.GetBytes(message);
            enviandoMensaje(tramaContenidoMensaje,longitud);




            /*mensaje = message;
            int longitud = message.Length;
            String longitudCadena = "";
            if(longitud == 1)
            {
                longitudCadena = "00" + Convert.ToString(longitud);
            }
            if (longitud == 2)
            {
                longitudCadena = "0" + Convert.ToString(longitud);
            }
            else
            {
                longitudCadena = Convert.ToString(longitud);
            }

            tramaCabecera = ASCIIEncoding.UTF8.GetBytes(longitudCadena);*/

        }

        public void enviandoMensaje(byte[] tramaC,int longitud)
        {
            puerto.Write(tramaC, 0, longitud);
        }

        public void Recibir()
        {
            string mensRecibido = puerto.ReadExisting();
            MessageBox.Show(mensRecibido);
        }

    }
}
