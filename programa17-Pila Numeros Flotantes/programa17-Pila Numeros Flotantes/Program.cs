using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace programa17_Pila_Numeros_Flotantes
{
    class Program
    {

        public class Pilas
        {
            public int max, top, apuntador;
            public float[] Pila;

            public Pilas(int tamaño)
            {
                max = tamaño;
                top = -1;
                Pila = new float[tamaño];
                Console.WriteLine("La pila ha sido creada con exito.");
                Console.WriteLine("Presione <enter> para continuar.");
                Console.ReadKey();
            }

            //metodos de la clase

            public void Push(float elemento)
            {
                if (top!=max-1)
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
                if (top!=-1)
                {
                    Console.WriteLine("\nDato a eliminar : " + Pila[top]);
                    Pila[top] = 0;
                    top = top - 1;

                }
                else
                {
                    Console.WriteLine("\nLa pila esta vacia ");
                }
            }

            public void Recorrido()
            {
                if (top!=-1)
                {
                    apuntador = top;
                    do
                    {
                      Console.WriteLine("Elemento : " + Pila[apuntador] + " posicion : " + apuntador);
                        apuntador = apuntador - 1;
                    } while (apuntador!=-1);
                }

                else
                {
                    Console.WriteLine("La pila esta vacia ");
                }
            }

            public void Busqueda(float elemento)
            {
                if (top!=-1)
                {
                    apuntador = top;
                    do
                    {
                        if (Pila[apuntador]==elemento)
                        {
                            Console.WriteLine("El dato " + elemento + " fue encontrado en la posicion " + apuntador);
                            return;
                        }
                        else
                        {
                            apuntador = apuntador - 1;
                        }

                    } while (apuntador!=-1);


                    Console.WriteLine("El dato " + elemento + " no se encontro en la pila ");

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
            Pilas pilas=null;
            char opc;
            int tamaño;
            Stopwatch s = new Stopwatch();
            
            do
            {
                
                Console.Clear();
                Console.WriteLine("PILA NUMEROS FLOTANTES");
                Console.WriteLine("\na) Crear la pila");
                Console.WriteLine("b) Insertar un elemento");
                Console.WriteLine("c) Eliminar un dato");
                Console.WriteLine("d) Recorrer la pila");
                Console.WriteLine("e) Buscar un elemento");
                Console.WriteLine("f) Salir del programa");
                s.Start();
                Console.Write("\nIngrese una opcion valida : ");
                opc = char.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 'a':
                        
                        Console.Write("Ingrese el tamaño de la pila : ");
                        tamaño = int.Parse(Console.ReadLine());
                        pilas = new Pilas(tamaño);
                        Console.ReadKey();
                        break;

                    case 'b':
                        Console.WriteLine("Ingrese el elemento para agregar a la pila : ");
                        float num = float.Parse(Console.ReadLine());
                        pilas.Push(num);
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
                        float numero = float.Parse(Console.ReadLine());
                        pilas.Busqueda(numero);
                        Console.ReadKey();
                        break;
                    case 'f':
                        s.Stop();
                        Console.WriteLine("Cerrando programa...");
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
