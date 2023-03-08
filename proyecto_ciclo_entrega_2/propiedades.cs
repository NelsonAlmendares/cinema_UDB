using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ciclo_entrega_2
{
    class Propiedades : Program
    {
        // Función para ocultar una contraseña por medio de la consola
        public static void OcultarContra()
        {
            // Creamos una lista para almacenar la clave
            List<string> lstClave = new List<string>();
            while (true)
            {
                // Capturamos la entrada de datos del teclado
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (tecla.Key == ConsoleKey.Backspace)
                {
                    if (lstClave.Count() > 0)
                    {
                        lstClave.RemoveAt(lstClave.Count - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    lstClave.Add(Convert.ToString(tecla.KeyChar));
                    Console.Write("*");
                }
            }
            string strDato = "";
            for (int i = 0; i < lstClave.Count(); i++)
            {
                strDato += lstClave[i];
            }
            // Mostrar la contraseña (NO NECESARIO) pero por si acaso
            // Console.WriteLine("\n La contraseña es : " + strDato);
        }

        // Funcion para cargar el porcentaje y la barra
        public static void PrintAverage(int numero_porcentaje, int porcentaje) {
            Console.SetCursorPosition(150, 35);
            Console.Write("Cargado: " + (porcentaje).ToString() + " %");
            Console.SetCursorPosition(numero_porcentaje, 30);
        }
    }
}
