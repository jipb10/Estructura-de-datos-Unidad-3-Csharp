using System;
using System.Diagnostics;

namespace programa18__Pila_Nombres_Personas
{
    class Program
    {
        class Pilas
        {
            public int max, top, apuntador;
            public string[] Pila;

            public Pilas(int tamaño)
            {
                max = tamaño;
                top = -1;
                Pila = new string[tamaño];
                Console.WriteLine("La pila ha sido creada con exito.");
                Console.WriteLine("Presione <enter> para continuar.");
                Console.ReadKey();
            }

            public void Push(string elemento)
            {
                if (top != max - 1)
                {
                    top = top + 1;
                    Pila[top] = elemento;
                    Console.WriteLine("Se agrego un elemento a la pila");
                }
                else
                {
                    Console.WriteLine("La pila esta llena ");
                    Console.ReadKey();
                }

                
            }

            public void Pop()
            {
                if (top != -1)
                {
                    Console.WriteLine("\nDato a eliminar : " + Pila[top]);
                    Pila[top] = null;
                    top = top - 1;

                }
                else
                {
                    Console.WriteLine("\nLa pila esta vacia ");
                }
            }

            public void Recorrido()
            {
                if (top != -1)
                {
                    apuntador = top;
                    do
                    {
                        Console.WriteLine("Elemento : " + Pila[apuntador]+ " posicion : " + apuntador);
                        apuntador = apuntador - 1;
                    } while (apuntador != -1);
                }

                else
                {
                    Console.WriteLine("La pila esta vacia ");
                }
            }

            public void Busqueda(string elemento)
            {
                if (top != -1)
                {
                    apuntador = top;
                    do
                    {
                        if (Pila[apuntador] == elemento)
                        {
                            Console.WriteLine("El dato : " + elemento + " fue encontrado en la posicion : " + apuntador);
                            return;
                        }
                        else
                        {
                            apuntador = apuntador - 1;
                        }

                    } while (apuntador != -1);


                    Console.WriteLine("El dato : " + elemento +  " no se encontro en la pila ");

                }

                else
                {
                    Console.WriteLine("La pila esta vacia ");
                }
            }
            //Destructor de la clase
            ~Pilas()
            {
                Console.WriteLine("Memoria de Pilas liberada ");
            }
        }
        static void Main(string[] args)
        {
            char opc;
            Pilas pilas=null;
            Stopwatch s = new Stopwatch();
            do
            {
                Console.Clear();
                Console.WriteLine("PILA NOMBRES PERSONAS");
                Console.WriteLine("\na) Crear la pila ");
                Console.WriteLine("b) Insertar un elemento ");
                Console.WriteLine("c) Eliminar un dato ");
                Console.WriteLine("d) Recorrer la pila ");
                Console.WriteLine("e) Buscar un elemento ");
                Console.WriteLine("f) Salir del programa ");
                s.Start();
                Console.Write("\nIngrese una opcion valida : ");
                opc = char.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 'a':
                        Console.Write("Ingrese el tamaño de la pila : ");
                        int tamaño = int.Parse(Console.ReadLine());
                        pilas = new Pilas(tamaño);
                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.Write("Ingrese el elemento para agregar a la pila : ");
                        string nom = Console.ReadLine();
                        pilas.Push(nom);
                        Console.ReadKey();
                        break;
                    case 'c':
                        pilas.Pop();
                        Console.ReadKey();
                        break;
                    case 'd':
                        pilas.Recorrido();
                        Console.ReadKey();
                        break;
                    case 'e':
                        Console.WriteLine("Ingrese el elemento que desea buscar : ");
                        string nombre = Console.ReadLine();
                        pilas.Busqueda(nombre);
                        Console.ReadKey();
                        break;
                    case 'f':
                        Console.WriteLine("\nCERRANDO PROGRAMA...");
                        s.Stop();
                        Console.WriteLine($"\nTiempo: {s.Elapsed.TotalMilliseconds} ms");
                        Console.WriteLine("\nMemoria Utilizada : " + GC.GetTotalMemory(true) + " " + "bytes");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("INGRESE UNA OPCION VALIDA...");
                        Console.ReadKey();
                        break;

                }

            } while (opc!='f');
        }
    }
}
