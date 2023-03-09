using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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

namespace proyecto_ciclo_entrega_2 {
            
    class Program
    {
        public static void Main(string[] args)
        {
            // Usamos la instrucción try con 1 catch para conotrlar las excepciones dentro de la ejecución del proyecto
            try
            {
                // Propiedades de la nueva ventana
                Console.WindowHeight = 40;
                Console.WindowWidth = 170;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Title = "cinema UDB";

                // Cursor invisible.
                Console.CursorVisible = false;

                // Creamos la nueva ventana y la personalizamos
                int barra = 99;
                int porcentaje = 0;
                int numero_porcentaje = 35;

                Console.SetCursorPosition(150, 35);

                for (int i = 0; i < barra; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("█"); // Muestra ASCII 219 Dec y DB en Hex.
                    porcentaje++; // Incrementa valor.
                    numero_porcentaje++;
                    Propiedades.PrintAverage(numero_porcentaje, porcentaje);
                    Thread.Sleep(80); // 80 ms o 0.8 segundos.
                }

                // Restablecemos los valores luego de la pantalla de carga
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                // Cursor invisible.
                Console.CursorVisible = true;

                // Título reasignado luego del splash screen
                Console.Title = "cinema UDB";
                Console.Write("\n\t\t\t\t\t\t\t\t\t Proyecto - PrimeCinema");

                // Variable para evaluar la accion a realizar por el DO
                string accion;
                // Usamos la secuencia DO-WHILE para poder repetir la ejecución del programa y evitar la compilación repetitiva
                do
                {
                    // Declaración de las variables para uso del sistema
                    string usuario;
                    // Declaración de variable para la ruta del archivo de texto creado
                    var fileUser = "usuarios.txt";
                    var fileNameRegistros = "registros.txt";
                    var fileDocumento = "documento.txt";

                    // Solicitamos el nombre del usuario
                    Console.Write("\n\n\t\t\t Bienvenido, ingresa el nombre de su usuario : ");
                    usuario = Console.ReadLine().ToString();

                    // Evaluamos si el usuario está registrado:
                    if (File.ReadAllText(fileNameRegistros) == usuario) {

                        Console.Write("\n\n\t\t\t Ingresa la contraseña de su usuario : ");
                        // Llmamos el método con el cual ocultamos la contraseña
                        Propiedades.OcultarContra();
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\t\t\t\t\t\t\t\t ¡¡¡ El usuario no se encuentra registrado !!! ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        string accion_usuario1;
                        Console.Write("\n\n");
                        Console.Write("\n\t\t\t ¿Qué acción desea realizar?");
                        Console.Write("\n\n\n");
                        Console.Write("\n\t\t\t\t (1). Registrarme en el sistema ");
                        Console.Write("\n");
                        Console.Write("\n\t\t\t\t (2). Salir del registro ");
                        Console.Write("\n");
                        Console.Write("\n\t\t\t\t (3). Ayuda y soporte ");
                        Console.Write("\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n\t\t\t\t\t Digite el número de la opcción que desea... ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        accion_usuario1 = Console.ReadLine();

                        switch (accion_usuario1)
                        {
                            case "1":
                                Console.Clear();
                                Console.Write("\n\t\t\t\t\t\t\t\t Registro de usuarios - PrimeCinema");
                                // Variables para el registro del nuevo usuario
                                string user, passwordUser, nombre, residencia, correo;
                                int documento, telefono;
                                
                                // Validamos si el nombre del usuario que se quiere registrar ya existe:
                                bool evaluador_usuario;
                                do {
                                    // Solicitamos datos
                                    Console.Write("\n");
                                    Console.Write("\n\t\t\t --> Ingrese el nombre del nuevo usuario: ");
                                    user = Console.ReadLine().ToString();

                                    if (File.ReadAllText(fileUser) == user)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\n\t\t\t El nombre ingresado ya ha sido utilizado ");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        evaluador_usuario = false;
                                    } else { evaluador_usuario = true; }
                                } while (evaluador_usuario == false);
                                // Ingresamos el nombre al archivo:
                                // File.WriteAllText(fileUser, usuario);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\n\t\t\t --> Ingresa tu nombre completo: ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                nombre = Console.ReadLine().ToString();

                                bool evaluador_documento;
                                do {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("\n\t\t\t --> Ingresa tu número de Identificación: ");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    documento = int.Parse(Console.ReadLine());
                                    if (File.ReadAllText(fileDocumento) == documento.ToString())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n\t\t\t El documento ingresado se encuentra ya registrado! ");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        evaluador_documento = false;
                                    } else
                                    { evaluador_documento = true; }
                                } while (evaluador_documento == false);

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\n\t\t\t --> Ingrese la dirección de residencia: ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                residencia = Console.ReadLine().ToString();

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\n\t\t\t --> Ingrese tu celular personal: ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                telefono = int.Parse(Console.ReadLine());

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\n\t\t\t --> Ingrese tu correo Eletrónico: ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                correo = Console.ReadLine().ToString();

                                Console.Write("\n\t\t\t Ingresa una contraseña para su usuario");
                                Console.Write("\n");
                                Console.Write("\n\t\t\t\t Sugerencia :");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\t\t\t\t Ingresa una contraseña que sea fácil de recordar solo para ti! ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                // Contraseña del usuario
                                Console.Write("\n");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("\n\t\t\t --> Digite su nueva contraseña: ");
                                Propiedades.OcultarContra();
                                Console.ForegroundColor = ConsoleColor.Black;
                                passwordUser = Console.ReadLine().ToString();

                                Console.Write("\n\t\t\t El usuario se está ingresando al sistema... ");
                                for (int i = 0; i < 75; i++)
                                {
                                    Console.Write("*");
                                    System.Threading.Thread.Sleep(30);
                                }
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("\n");
                                Console.Write("\n\t\t\t Usuario ingresado satisfactoriamente !");
                                Console.ForegroundColor = ConsoleColor.Black;

                                break;
                            case "2":
                                /* 
                                 * 
                                 * Sin niguna operación para que el programa salte 
                                 * al while que aún se está corriendo y poder realizar otra operación
                                 * 
                                 */
                                break;
                            case "3":
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();

                                Console.Write("\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n\t\t\t\t\t\t\t\t Soporte y contácto - PrimeCinema");
                                Console.Write("\n\t\t _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n");
                                Console.Write("\n\t\t\t Para recibir soporte o reportar errores puedes escribirnos al correo: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n\t\t\t soporte_primeCinema@gmail.com");
                                Console.Write("\n");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t\t\t Para consultarnos o dudas puedes escribirnos al correo: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n\t\t\t consultas_primeCinema@gmail.com");
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\t\t\t La opcción ingresada no es válida");
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                        }
                    }

                    // Evaluamos si el usuario quiere realizar otra operación
                    Console.Write("\n\n\t\t\t ¿Dese realizar otra acción? : ");
                    accion = Console.ReadLine();
                    // Limpiamos la consola
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    // Asignamos de nuevo título de la nueva ventana
                    Console.Write("\n\t\t\t\t\t\t\t\t\t Proyecto - PrimeCinema");
                    Console.Write("\n");
                } while (accion == "SI" || accion == "Si" || accion == "si");
            }
            catch (Exception ex)
            {
                Console.Write("\n\t\t\t " + ex.Message);
            }

            // Pestaña para mostrar los colaboradores
            Console.Write("\n\n\n\n\n\n");
            Console.Write("\n\t\t _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.Write("\n\n\t\t\t\t\t\t\t\t Este programa fue desarrollado por: ");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\t\t\t\t\t\t\t\t (1).  Nelson José Almendares Ruiz ");
            Console.Write("\n\t\t\t\t\t\t\t\t (2).  Diego Alexander López Morataya ");
            Console.Write("\n\t\t\t\t\t\t\t\t (3).  Emanuel Edgardo Luna Villanueva ");
            Console.Write("\n\t\t\t\t\t\t\t\t (4).  David Alejandro Rodríguez Ferrufino ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\t\t _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

            // Mensaje de finalización del programa
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("\n");
            Console.Write("\n\t\t --> Fin de la ejecución del programa....");
            Console.Write("\n\t\t --> Pulse cualquier tecla....");
            // Esperamos una respuesta del usuario
            Console.ReadKey();
        }
    }
}
