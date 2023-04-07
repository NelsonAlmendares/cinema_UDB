using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Class_List;
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
namespace proyecto_2 {
    class Program {
        public static void Main(string[] args) {
            // Usamos la instrucción try con 1 catch para conotrlar las excepciones dentro de la ejecución del proyecto
            try {
                // Instanciamos el acceso a las fucniones y procedimientos
                Functions.Propiedades function = new Functions.Propiedades();
                Developers Dev_Info = new Developers();
                Switch_Case_3.Case_3 Case = new Switch_Case_3.Case_3();

                // Propiedades de la nueva ventana
                Console.WindowHeight = 40;
                Console.WindowWidth = 170;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Title = "cinema UDB";

                // Cursor invisible.
                Console.CursorVisible = false;

                // Creamos la barra
                int barra = 100;
                int porcentaje = 0;
                int numero_porcentaje = 35;
                Console.SetCursorPosition(150, 35);
                for (int i = 0; i < barra; i++) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("█"); // Muestra ASCII 219 Dec y DB en Hex.
                    porcentaje++; // Incrementa valor.
                    numero_porcentaje++;
                    function.PrintAverage(numero_porcentaje, porcentaje);
                    Thread.Sleep(70); // 70 ms o 0.7 segundos.
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
                do {    
                    // Declaración de las variables para uso del sistema
                    string usuario;
                    // Declaración de variable para la ruta del archivo de texto creado
                    var fileUser = "usuarios.txt";
                    var fileNameRegister = "registros.txt";
                    var fileDocumentRegister = "documento.txt";
                    var filePasswordRegister = "password.txt";
                    var fileEmailRegister = "correo.txt";
                    var filePhoneRegister = "telefono.txt";

                    // Solicitamos el nombre del 
                    Console.Write("\n\n\t\t\t Bienvenido, ingresa el nombre de su usuario : ");
                    usuario = Console.ReadLine().ToString();
                    // Evalluamos si el usuario está registrado:
                    if (File.ReadAllText(fileNameRegister) == usuario) {

                        Console.Write("\n\n\t\t\t Ingresa la contraseña de su usuario : ");
                        // Llmamos el método con el cual ocultamos la contraseña
                        function.OcultarContra();
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
                                    if (File.ReadAllText(fileDocumentRegister) == documento.ToString())
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
                                Console.ForegroundColor = ConsoleColor.Black;
                                function.OcultarContra();
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

                                // Creamos espacios para poder leer los textos que se ingresen
                                StringBuilder us = new StringBuilder("Added :");
                                StringBuilder nm = new StringBuilder("Added :");
                                StringBuilder dc = new StringBuilder("Added :");
                                StringBuilder pwd = new StringBuilder("Added :");
                                StringBuilder em = new StringBuilder("Added: ");
                                StringBuilder tl = new StringBuilder("Added: ");

                                us.AppendLine(File.ReadAllText(fileUser));
                                nm.AppendLine(File.ReadAllText(fileNameRegister));
                                dc.AppendLine(File.ReadAllText(fileDocumentRegister));
                                pwd.AppendLine(File.ReadAllText(filePasswordRegister));
                                em.AppendLine(File.ReadAllText(fileEmailRegister));
                                tl.AppendLine(File.ReadAllText(filePhoneRegister));

                                us.AppendLine("new: " + user);
                                nm.AppendLine("new: " + nombre);
                                dc.AppendLine("new: " + documento);
                                pwd.AppendLine("new: " + passwordUser);
                                em.AppendLine("new: " + correo);
                                tl.AppendLine("new:" + telefono);

                                // Ingresamos el nombre al archivo:
                                File.WriteAllText(fileUser, us.ToString());
                                File.WriteAllText(fileNameRegister, nm.ToString());
                                File.WriteAllText(fileDocumentRegister, dc.ToString());
                                File.WriteAllText(filePasswordRegister, pwd.ToString());
                                File.WriteAllText(fileEmailRegister, em.ToString());
                                File.WriteAllText(filePhoneRegister, tl.ToString());
                                break;
                            case "2":
                                /*  
                                 * Sin niguna operación para que el programa salte 
                                 * al while que aún se está corriendo y poder realizar otra operación
                                 */
                                break;
                            case "3":
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();
                                Case.Switch_Case_3();
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

                // Pestaña para mostrar los colaboradores
                Dev_Info.MostrarInformacion();

                // Mensaje de finalización del programa
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                Console.Write("\n");
                Console.Write("\n\t\t --> Fin de la ejecución del programa....");
                Console.Write("\n\t\t --> Pulse cualquier tecla....");
                // Esperamos una respuesta del usuario
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("\n\t\t\t " + ex.Message);
            }
        }
    }
}
