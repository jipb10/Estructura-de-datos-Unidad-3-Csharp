using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa19__Cola_numeros_flotantes
{
    class Program
    {
        class Colas
        {
            int Max, Frente, Final, Apuntador;
            float[] cola;
            public Colas(int tamaño)
            {
                Max = tamaño;
                Frente = -1;
                Final = -1;
                cola = new float[tamaño];
                Console.WriteLine("La cola ha sido creada ");
                Console.WriteLine("Presione <enter> para continuar ");

            }
            public void Push(float elemento)
            {
                if (Frente==0 && Final==Max-1)
                {
                    Console.WriteLine("\nLa cola esta llena");
                }
                else
                {
                    if (Frente==-1)
                    {
                        Frente = 0;
                        Final = 0;

                    }
                    else
                    {
                        Final = Final + 1;
                    }
                    cola[Final] = elemento;

                    Console.WriteLine("Se agrego un elemento");
                }
            }
            public void Pop()
            {
                if (Frente!=-1)
                {
                    Console.WriteLine("Eliminado el dato : {0}", cola[Frente]);
                    cola[Frente] = 0;

                    if (Frente == Final)
                    {
                        Frente = -1;
                        Final = -1;
                    }
                    else
                    {
                        Frente = Frente + 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa cola esta vacia");
                }
                
            }
            
            public void Recorrido()
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    do
                    {
                        Console.WriteLine("Elemento : " + cola[Apuntador] + " Posicion : " + Apuntador);
                        
                        Apuntador = Apuntador + 1;
                    } while (Apuntador <= Final);
                }
                else
                {
                    Console.WriteLine("La cola esta vacia ");
                    
                }
            }

            public void Busqueda(float elemento)
            {
                if (Frente!=-1)
                {
                    Apuntador = Frente;
                    do
                    {
                        if (elemento==cola[Apuntador])
                        {
                            Console.WriteLine("Dato encontrado en la posicion : " + Apuntador);
                            Console.ReadKey();
                            return;
                        }
                        Apuntador = Apuntador + 1;
                    } while (Apuntador<=Final);
                    Console.WriteLine("Dato : " + elemento+ " no encontrado en la cola");
                }
                else
                {
                    Console.WriteLine("La cola esta vacia");
                }
            }
            //destructor de la clase
            ~Colas()
            {
                Console.WriteLine("Memoria de clase colas liberada ");
            }
        }
        static void Main(string[] args)
        {
            char opc;
            Colas cola= null;
            Stopwatch s = new Stopwatch();
            Random r = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine(" COLA NUMEROS FLOTANTES ");
                Console.WriteLine("\na) Crear la cola");
                Console.WriteLine("b) Insertar un elemento");
                Console.WriteLine("c) Eliminar un dato");
                Console.WriteLine("d) Recorrer la cola");
                Console.WriteLine("e) Buscar un elemento");
                Console.WriteLine("f) Salir del programa");
                s.Start();
                Console.Write("\nIngrese una opcion : ");
                opc = char.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 'a':
                        Console.Write("Ingrese el tamaño de la cola : ");
                        int tamaño = int.Parse(Console.ReadLine());
                        cola = new Colas(tamaño);
                        break;
                    case 'b':
                        float num = r.Next(0, 10);
                        cola.Push(num);
                        break;
                    case 'c':
                        cola.Pop();
                        break;
                    case 'd':
                        cola.Recorrido();
                        break;
                    case 'e':
                        Console.Write("Ingrese el elemento que desea buscar : ");
                        float elem = float.Parse(Console.ReadLine());
                        cola.Busqueda(elem);
                        break;
                    case 'f':
                        s.Stop();
                        Console.WriteLine("CERRANDO PROGRAMA...");
                        Console.WriteLine($"\nTiempo : {s.Elapsed.TotalMilliseconds} ms");
                        Console.WriteLine("\nMemoria Utilizada : " + GC.GetTotalMemory(true) + " " + "bytes");
                        break;
                    default:
                        Console.WriteLine("INGRESE UNA OPCION VALIDA...");
                        break;
                }
                Console.ReadKey();
            } while (opc!='f');
        }
    }
}
