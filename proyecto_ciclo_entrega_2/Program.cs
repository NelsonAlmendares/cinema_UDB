using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ciclo_entrega_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Tabulación de 3 espacios para todo el contenido                  *
             * Los títulos deben de estar centrados                             *
             * Color de letra para notificaciones (VERDE)                       *
             * Color de alarta para errores y excepciones (ROJO)                *
             * Se usará UPPER CAMEL CASE para el nombramiento de las variables  *
             * Se usará SNAKE CASE para el nombreamiento de funciones           *
             * 
             */

            // Creamos la nueva ventana y la personalizamos
            Console.WindowHeight = 40;
            Console.WindowWidth = 170;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            // Título de la nueva ventana
            Console.Title = "cinema UDB";
            Console.Write("\n\t\t\t\t\t\t\t\t\t Proyecto - PrimeCinema");

            // Usamos la instrucción try con 1 catch para conotrlar las excepciones dentro de la ejecución del proyecto
            try
            {
                // Variable para evaluar la accion a realizar por el DO
                string accion;
                // Usamos la secuencia DO-WHILE para poder repetir la ejecución del programa y evitar la compilación repetitiva
                do
                {
                    // Declaración de las variables 
                    string usuario;

                    // Solicitamos el nombre del usuario
                    Console.Write("\n\n\t\t\t Bienvenido, ingresa el nombre de su usuario : ");
                    usuario = Console.ReadLine();
                    // Evaluamos los usuarios que están registrados:
                    if (usuario == "")
                    {

                    }

                    // Evaluamos si el usuario quiere realizar otra operación
                    Console.Write("\n\n\t\t\t ¿Dese realizar otra acción? : ");

                    accion = Console.ReadLine();
                } while (accion == "SI" || accion == "Si" || accion == "si");
            }
            catch (Exception ex)
            {
                Console.Write("\n\t\t\t " + ex.Message);
            }

            // Pestaña para mostrar los colaboradores
            Console.Write("\n\t\t _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.Write("\n\t\t\t\t\t\t\t\t Este programa fue desarrollado por: ");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\t\t\t\t\t\t\t\t (1).  Nelson José Almendares Ruiz ");
            Console.Write("\n\t\t\t\t\t\t\t\t (2).  Diego Alexander López Morataya ");
            Console.Write("\n\t\t\t\t\t\t\t\t (3).  Emanuel Edgardo Luna Villanueva ");
            Console.Write("\n\t\t\t\t\t\t\t\t (4).  David Alejandro Rodríguez Ferrufino ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\t\t _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

            // Mensaje de finalización del programa
            Console.Write("\n");
            Console.Write("\n\t\t --> Fin de la ejecución del programa....");
            Console.Write("\n\t\t --> Pulse cualquier tecla....");
            // Esperamos una respuesta del usuario
            Console.ReadKey();
        }
    }
}
