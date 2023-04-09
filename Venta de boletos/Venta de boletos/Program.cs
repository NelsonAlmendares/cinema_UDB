using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
int salir =0; //Variable usada para saber si continuar el programa o no
double total_venta; //Variable para calcular el total vendido
int accion_compra;//Variable usada para el switch entre las diferentes opciones
string sucursal_ele; //Una variable para guardar la sucursal elegida por el usuario
int numS, numH; //Una variable para guardar el número de la sucursal la otra para guardar el número de la hora elegida
string peli_ele, horario_ele; //Una variable para guardar la pelicula elegida otra para el horario elegido
int sala_ele; //variable para guardar el número de sala
string continuar_asientos = "si"; //Variables para el while al momento de seleccionar butacas
string liberar_butacas = "no"; //Variable para la decision de liberar todas las butacas
int fila, numTE, numA, columna; //Variables para guardar la fila y columna de la butaca como el numero de boletos de adultos y tercera edad
string[,,,,] informacion_Asientos = new string[10, 6, 3, 5, 11]; //Matriz usada para guardar el estado de los asientos en cada uno de los horarios y salas
informacion_Asientos = llenarMat(informacion_Asientos);
while (salir == 0)
{
    //Menú usado para decidir metodo de busqueda
    Console.WriteLine("\n\n\t\t\tBusqueda de funciones: ");
    Console.WriteLine("\t\t\t1. Busqueda por sucursal ");
    Console.WriteLine("\t\t\t2. Busqueda por pelicula ");
    Console.Write("\t\t\tDigite 1 o 2 dependiendo que opción quiere realizar: ");
    accion_compra = int.Parse(Console.ReadLine()); //Le damos un valor a la variable para el switch
    Console.Clear();
    switch (accion_compra)
    {
        case 1: //Eleccion por sala
            Console.Write("\n\n");
            mostrarvectorString(Sucursales); //Mostramos todas las sucursales
            Console.Write("\n\t\t\tIngrese sucursal elegida: "); //Pedimos al usuario elegir una sucursal
            sucursal_ele = Console.ReadLine();
            if (buscarvector(sucursal_ele, Sucursales))
            {
                numS = buscadornum(sucursal_ele, Sucursales); //Buscamos cual es el número de la sucursal
                Console.Clear();
                switch (numS)
                {
                    case 1: //En el caso que la sucursal sea la sucursal n°1
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: "); //Mostramos al usuario las salas disponibles
                        mostrarvectorInt(Salas_S1);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: "); //El usuario selecciona una
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");//Mostramos la pelicula disponible en esa sala con su formato
                        Console.Write("\t\t\t" + Pelicula_S1[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }//Verificamos si la pelicula está en 3D
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula"); //Confirmamos la selccion 
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S1); //Mostramos los horarios
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S1); //Verificamos en que parte del arreglo esta guardado el horario seleccionado
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }//Mostramos los precios segun el tipo de formato
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: "); //Confirmamos el número de boletos de adultos y tercera edad
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos); //Mostramos los asientos disponibles
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|"; //Cambiamos el estado de la butaca a ocupado
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: "); //Preguntamos si el usuario quiere escoger más butacas
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos); //Mostramos los asientos disponibles
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?"); //Verificamos si el usuario quiere liberar todas las butacas
                            liberar_butacas = Console.ReadLine(); 
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE); //Calculamos el total de venta
                        }
                        break;
                    case 2:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S2);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S2[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S2);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S2);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 3:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S3);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S3[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S3);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S3);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 4:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S4);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S4[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S4);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S4);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 5:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S5);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S5[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S5);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S5);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 6:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S6);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S6[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S6);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S6);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 7:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S7);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S7[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S7);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S7);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 8:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S8);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S8[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S8);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S8);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 9:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S9);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S9[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S9);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S9);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                    case 10:
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLas salas disponibles son las siguientes: ");
                        mostrarvectorInt(Salas_S10);
                        Console.Write("\n\t\t\tIngrese una sala entre las salas disponibles: ");
                        sala_ele = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("\n\n");
                        Console.WriteLine("\t\t\tLa pelicula disponible en esta sala es la siguiente: ");
                        Console.Write("\t\t\t" + Pelicula_S10[sala_ele] + " disponible en el formato ");
                        if (buscarvector(nombre_Pelicula3D))
                        {
                            Console.Write("3D");
                        }
                        else
                        {
                            Console.Write("2D");
                        }
                        Console.Write("\n\t\t\tDigite si en el caso que quiera comprar boletos para esta pelicula");
                        peli_ele = Console.ReadLine();
                        peli_ele.ToLower();
                        Console.Clear();
                        if (peli_ele == "si")
                        {
                            Console.Write("\n\n");
                            mostrarfila(sala_ele, Horarios_S10);
                            Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                            horario_ele = Console.ReadLine();
                            numH = buscadornumMat(horario_ele, sala_ele, Horarios_S10);
                            Console.Clear();
                            Console.Write("\n\n");
                            if (buscarvector(nombre_Pelicula3D))
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                            }
                            else
                            {
                                Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                                Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                            }
                            Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                            numTE = int.Parse(Console.ReadLine());
                            Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                            numA = int.Parse(Console.ReadLine());
                            while (continuar_asientos == "si")
                            {
                                Console.Write("\n\n");
                                mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                                Console.Write("\n\t\t\tElija la fila de la butaca: ");
                                fila = int.Parse(Console.ReadLine());
                                columna = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                                continuar_asientos = Console.ReadLine().ToLower();
                                Console.Clear();
                            }
                            Console.Write("\n\n");
                            mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                            Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                            liberar_butacas = Console.ReadLine();
                            if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                            Console.Clear();
                            total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                        }
                        break;
                }
                break;
            } //Verificamos si la sucursal elegida existe
            else { Console.WriteLine("\n\t\t\tLa sucursal digitada no existe"); }
            Console.ReadKey(); //Dejamos al usuario decidir cuando continuar 
            break;
        case 2: //Eleccion por pelicula
            Console.Write("\n\n");
            mostrarvectorString(nombre_Peliculas3D); //Mostramos todas las peliculas 3D
            Console.Write("\n");
            mostrarvectorString(nombre_PeliculasTD); //Mostramos todas las peliculas TD
            Console.Write("\n\t\t\tSeleccione la pelicula que desea ver: "); //Solicitamos la pelicula que desea visualizar
            peli_ele = Console.ReadLine();
            Console.ReadKey();
            Console.Clear();
            Console.Write("\n\n");
            mostrar_peli_sucursal(peli_ele, Pelicula_S1,1,Sucursales); //Mostramos las sucursales en las que la pelicula esta disponible junto con su sala
            mostrar_peli_sucursal(peli_ele, Pelicula_S2,2,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S3,3,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S4,4,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S5,5,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S6,6,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S7,7,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S8,8,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S9,9,Sucursales);
            mostrar_peli_sucursal(peli_ele, Pelicula_S10,10,Sucursales);
            Console.Write("\n\t\t\tSeleccione una sucursal: "); //Le pedimos al usuario que sucursal quiere atender
            sucursal_ele = Console.ReadLine();
            numS = buscadornum(sucursal_ele, Sucursales);
            Console.Write("\n\t\t\tSeleccione una sala: "); //Le pedimos al usuario que sala quiere anteder
            sala_ele = int.Parse(Console.ReadLine());
            switch (numS) //Mismo proceso que con el otro metodo solo que ya conocemos la sala
            {
                case 1:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S1);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S1);                   
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 2:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S2);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S2);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 3:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S3);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S3);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 4:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S4);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S4);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 5:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S5);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S5);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 6:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S6);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S6);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 7:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S7);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S7);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 8:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S8);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S8);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 9:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S9);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S9);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
                case 10:
                    Console.Write("\n\n");
                    mostrarfila(sala_ele, Horarios_S10);
                    Console.Write("\n\t\t\tElija uno de los horarios disponibles: ");
                    horario_ele = Console.ReadLine();
                    numH = buscadornumMat(horario_ele, sala_ele, Horarios_S10);
                    Console.Clear();
                    Console.Write("\n\n");
                    if (buscarvector(nombre_Pelicula3D))
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $5.60");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $6.55");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tPrecio de boleto de tercera edad: $3.90");
                        Console.WriteLine("\t\t\tPrecio de boleto de adultos: $5.00");
                    }
                    Console.Write("\n\t\t\tDigite número de boletos de tercera edad: ");
                    numTE = int.Parse(Console.ReadLine());
                    Console.Write("\n\n\t\t\tDigite número de boletos para adultos: ");
                    numA = int.Parse(Console.ReadLine());
                    while (continuar_asientos == "si")
                    {
                        Console.Write("\n\n");
                        mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                        Console.Write("\n\t\t\tElija la fila de la butaca: ");
                        fila = int.Parse(Console.ReadLine());
                        columna = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Red;
                        informacion_Asientos[numS, sala_ele, numH, fila, columna] = "|*|";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\t\t\tSi desea seleccionar otro asiento digite si: ");
                        continuar_asientos = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    Console.Write("\n\n");
                    mostrar_Asientos(numS, sala_ele, numH, informacion_Asientos);
                    Console.Write("\n\t\t\t¿Desea regresar todas las butacas a un estado disponible (responda si en minusculas)?");
                    liberar_butacas = Console.ReadLine();
                    if (liberar_butacas == "si") { liberar_sala(numS, sala_ele, numH, informacion_Asientos); }
                    Console.Clear();
                    total_venta = pagar(buscarvector(nombre_Pelicula3D), numA, numTE);
                    break;
            }
            break;
    }
    Console.Write("\t\t\tDigite 0 si quiere continuar: "); //Le preguntamos al usuario si quiere realizar otra operación
    salir = int.Parse(Console.ReadLine());
}
static void mostrar_peli_sucursal(string peli_ele, string[] Pelicula_Sx,int num, string[] Sucursales)
{
    for (int i = 0; i<Pelicula_Sx.Length;i++) //Recorremos todo el vector con las peliculas disponibles en la Sucursal X
    {
        if (peli_ele == Pelicula_Sx[i]) //Verificamos si la pelicula elegida esta siendo proyectada
        {
            Console.WriteLine("\t\t\tLa pelicula esta disponible en la sucursal " + Sucursales[num - 1] + " en la sala " + (i + 1)); //En cuyo caso le informamos al usuario
        }
    }
}
static void mostrarvectorString(string[] Vector)
{
    Console.Write("\t\t\t||");
    for (int i =0;i<Vector.Length; i++) //Recorremos todo el vector
    {
        Console.Write(Vector[i] + "||"); //Escribimos la información guardada en el vector
    }
}
static void mostrarvectorInt(int[] Vector) //Mismo proceso que mostrar el vector string pero diferente tipo de vector
{
    Console.Write("\t\t\t||");
    for (int i = 0; i < Vector.Length; i++)
    {
        Console.Write(Vector[i] + "||");
    }
}
static bool buscarvector(string buscado, string[] Vector)
{
    bool found=false; //Creamos un bool que vamos a regresar al usuario
    for (int i=0;i<Vector.Length;i++) //Recorremos todo el vector
    {
        found = Vector[i].Equals(buscado); //Verificamos si el elemento buscado es igual a el elemento seleccionado del vector
    }
    return found;
} 
static int buscadornum(string buscado, string[] Vector)
{
    int ret = 0;
    for (int i = 0; i < Vector.Length; i++) //Recorremos el vector
    {
        if(Vector[i].Equals(buscado)) //Verificamos si el elemento buscado es igual al elemento seleccionado del vector 
        {
            ret = i+1; //Seleccionamos el numero de Sucursal 
        }
    }
    return ret;
}
static void mostrarfila(int n, string[,] Mat)
{
    Console.Write("\t\t\t||");
    for (int i = 0; i < Mat.GetLength(1); i++) //Recorremos la matriz con la fila seleccionada de manera fija 
    {
        Console.Write(Mat[n, i]+"||"); //Escribimos la fila
    }
}
static int buscadornumMat(string buscado,int f, string[,] Mat)
{   
    int ret = 10;
    for (int i = 0; i<Mat.GetLength(1); i++) //Recorremos la matriz con el numero de fila fijo
    {
        if (buscado == Mat[f,i]) { ret = i; } //Regresamos el índice donde se guarda el elemento de la matriz que coincide con el elemento buscado
    }
    return ret;
}
static void mostrar_Asientos(int a, int b, int c, string[,,,,] Mat)
{
    for (int i = 0; i < Mat.GetLength(3); i++) //Recorremos la matriz imprimiendo cada elemento para una sucursal, sala y hora determinada
    {
        for (int j = 0; j < Mat.GetLength(4); j++)
        {
            Console.Write("\t\t\t" + Mat[a, b, c, i, j]);
        }
        Console.Write("\n");
    }
}
static string[,,,,] llenarMat(string[,,,,] Mat)
{
    for (int i =0; i<10; i++)
    {
       for (int j=0;j<6;j++)
        {
           for(int k = 0;k<3;k++)
            {
               for (int l = 0; l < 5; l++)
                {
                   for (int p = 0; p < 11; p++)
                    {
                        if ((l==0)&&(p>0)) //Si estamos en la primera fila escribo el número de columnas para ayudar la visualización del usuario
                        {
                            Mat[i, j, k, l,p] = "|"+p.ToString()+"|";
                        }
                        else if((p==0)&&(l>0)) //Si estamos en la primera columna escribo el número de filas para ayudar la visualización del usuario
                        {
                            Mat[i, j, k, l, p] = l.ToString();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Mat[i, j, k, l, p] = "|*|"; //Escribimos que el estado de la butaca es disponible
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                }
            }
        }
    }
    return Mat;
}
static string[,,,,] liberar_sala(int a,int b, int c, string[,,,,] Mat) //Funcion para regresar todas las butacas de una cierta sucursal, sala y horario al estado desocupado
{
    for (int i = 0; i < Mat.GetLength(3); i++)
    {
        for (int j = 0; j < Mat.GetLength(4); j++)
        {
            if ((i == 0) && (j > 0))
            {
                Mat[a, b, c, i, j] = "|" + j.ToString() + "|";
            }
            else if ((i == 0) && (j > 0))
            {
                Mat[a, b, c, i, j] = i.ToString();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Mat[a, b, c, i, j] = "|*|";
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
    return Mat;
}
static double pagar(bool formato3D,int a,int te)
{
    int opc;
    double total_venta;
    if (formato3D)
    {total_venta = a * 6.55 + te * 5.60;} //Calculamos el total de venta si la pelicula es 3d
    else { total_venta = a * 5 + te * 3.9; } //Calculamos el total de venta si la pelicula es 2d
    Console.WriteLine("\n\n\t\t\tSu total a pagar es el siguiente:");
    if (formato3D) //Si la pelicula es en 3D
    {
        Console.WriteLine("\t\t\t" + a + " boletos de adultos en el formato 3D = " + 6.55 * a);//informamos el número de boletos para adultos y su precio total
        Console.WriteLine("\t\t\t" + te + " boletos para la tercera edad en el formato 3D = " + 6.55 * te);//informamos el número de boletos para personas de la tercera edad y su precio total
    }
    else //Si la pelicula es en 2D
    {
        Console.WriteLine("\t\t\t" + a + " boletos de adultos en el formato 3D = " + 5 * a);
        Console.WriteLine("\t\t\t" + te + " boletos para la tercera edad en el formato 3D = " + 3.9 * te);
    }
    Console.WriteLine("\t\t\t¿Que método de pago desea utilizar?");//Preguntamos el metodo de pago
    Console.WriteLine("\t\t\t1. Efectivo ");
    Console.WriteLine("\t\t\t2. Tarjeta ");
    Console.Write("\t\t\tSeleccione una de las opciones: ");
    opc = int.Parse(Console.ReadLine());
    calculo_del_cambio(opc,total_venta); //Calculamos el cambio
    return total_venta;
}
static void calculo_del_cambio(int opc,double total_venta)
{
    double dinero_entregado; //Variable para guardar el total entregado
    switch(opc)
    {
        case 1:
            Console.WriteLine("\t\t\tCALCULO DEL CAMBIO");
            Console.Write("\t\t\tDigite la cantidad de dinero entregado: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            dinero_entregado = double.Parse(Console.ReadLine()); //Preguntamos el total entregado
            Console.ForegroundColor= ConsoleColor.Black;
            Console.Write("\t\t\tEl cambio a entregar es $"+(dinero_entregado-total_venta)); //Calculamos el cambi
            break;
        case 2:
            Console.Write("\t\t\tIngrese número de tarjeta de credito: ");//Pedimos n° de la tarjeta de credito
            OcultarContra(); 
            break;
    }
}
static void OcultarContra()
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